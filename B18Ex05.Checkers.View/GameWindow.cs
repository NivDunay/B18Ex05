using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B18Ex05.Checkers.View
{
	public delegate void GameWindowButtonSelectedEventHandler(Point i_Location);

	public delegate void StartNewGameEventHandler();

	public delegate void GetMoveEventHandler(Point i_Location, Point i_Destination);

	public partial class GameWindow : Form
	{
		private int m_GameWindowSize;
		private bool m_PlayerTwoActive;
		private GameSettings m_GameSettings;
		private GameWindowButton m_CurrentWindowButton;
		private GameWindowButton m_WindowButtonDestination;
		private List<GameWindowButton> m_ComputerLastActions;

		public event GetMoveEventHandler UserMoveSelect;

		public event StartNewGameEventHandler ResetGame;

		public event GameWindowButtonSelectedEventHandler WindowButtonSelect;

		public GameWindow()
		{
			initializeGameWindow();
		}

		public int GameWindowSize
		{
			get { return m_GameWindowSize; }
		}

		public string PlayerOneName
		{
			get { return m_GameSettings.PlayerOneName; }
			set { m_GameSettings.PlayerOneName = value; }
		}

		public string PlayerTwoName
		{
			get { return m_GameSettings.PlayerTwoName; }
			set { m_GameSettings.PlayerTwoName = value; }
		}

		public bool IsPlayerTwoActive
		{
			get { return m_PlayerTwoActive; }
		}

		private void initializeGameWindow()
		{
			m_ComputerLastActions = new List<GameWindowButton>();
			m_GameSettings = new GameSettings();
			if (m_GameSettings.DialogResult == DialogResult.OK)
			{
				m_GameWindowSize = m_GameSettings.PlayerSelectedWindowSize;
				m_PlayerTwoActive = m_GameSettings.IsPlayerTwoActive;
				createButtonMatrix();
				InitializeComponent();
				labelPlayerOneName.Text = m_GameSettings.PlayerOneName + ":";
				labelPlayerTwoName.Text = m_GameSettings.PlayerTwoName + ":";
				labelPlayerOneScore.Left = labelPlayerOneName.Right    + 5;
				labelPlayerTwoScore.Left = labelPlayerTwoName.Right    + 5;
			}
			else
			{
				DialogResult = DialogResult.Cancel;
				Close();
			}
		}

		private void createButtonMatrix()
		{
			for (int row = 0; row < m_GameWindowSize; row++)
			{
				for (int col = 0; col < m_GameWindowSize; col++)
				{
					GameWindowButton currentSquare = new GameWindowButton(new Point(col, row));
					if ((row % 2 == 0 && col % 2 == 0) || (row % 2 == 1 && col % 2 == 1))
					{
						currentSquare.Enabled = false;
						currentSquare.BackColor = Color.Gray;
					}

					currentSquare.Top = (row  * Constants.k_ButtonHeight) + Constants.k_ButtonStartY;
					currentSquare.Left = (col * Constants.k_ButtonWidth)  + Constants.k_ButtonStartX;
					currentSquare.Click += gameWindowButton_ButtonClicked;
					Controls.Add(currentSquare);
				}
			}
		}

		private void gameWindowButton_ButtonClicked(object i_Sender, EventArgs i_E)
		{
			GameWindowButton currentButton = i_Sender as GameWindowButton;
			if (m_CurrentWindowButton == null)
			{
				resetComputerActions();
				tryMakePlayerSelection(currentButton);
			}
			else if (m_CurrentWindowButton == currentButton)
			{
				undoPlayerSelection();
			}
			else
			{
				tryMakePlayerMove(currentButton);
			}
		}

		private void undoPlayerSelection()
		{
			swapButtonColor(m_CurrentWindowButton);
			m_CurrentWindowButton = null;
		}

		private void tryMakePlayerSelection(GameWindowButton i_CurrentButton)
		{
			try
			{
				OnWindowButtonSelected(i_CurrentButton);
				m_CurrentWindowButton = i_CurrentButton;
				swapButtonColor(i_CurrentButton);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void tryMakePlayerMove(GameWindowButton i_CurrentButton)
		{
			m_WindowButtonDestination = i_CurrentButton;
			onPieceMove();
			swapButtonColor(m_CurrentWindowButton);
			m_CurrentWindowButton = null;
			m_WindowButtonDestination = null;
		}

		private void resetComputerActions()
		{
			foreach (GameWindowButton computerAction in m_ComputerLastActions)
			{
				computerAction.BackColor = Color.White;
			}

			m_ComputerLastActions.Clear();
		}

		private void onPieceMove()
		{
			try
			{
				OnUserMoveSelected();
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		protected virtual void OnUserMoveSelected()
		{
			UserMoveSelect?.Invoke(m_CurrentWindowButton.ButtonLocation, m_WindowButtonDestination.ButtonLocation);
		}

		public void Game_ComputerPieceMoved(Point i_Location, Point i_Destination)
		{
			checkIfGameWindoeButtonExistsAndAddToList(i_Location);
			checkIfGameWindoeButtonExistsAndAddToList(i_Destination);
			markComputerMovesOnScreen();
		}

		private void markComputerMovesOnScreen()
		{
			foreach (GameWindowButton computerAction in m_ComputerLastActions)
			{
				computerAction.BackColor = Color.DarkRed;
			}
		}

		private void checkIfGameWindoeButtonExistsAndAddToList(Point i_ButtonLocation)
		{
			if (!m_ComputerLastActions.Contains(Controls[i_ButtonLocation.ToString()] as GameWindowButton))
			{
				m_ComputerLastActions.Add(Controls[i_ButtonLocation.ToString()] as GameWindowButton);
			}
		}

		private void swapButtonColor(GameWindowButton i_CurrentWindowButton)
		{
			if (i_CurrentWindowButton.BackColor == Color.White)
			{
				i_CurrentWindowButton.BackColor = Color.LightSkyBlue;
			}
			else if (i_CurrentWindowButton.BackColor == Color.LightSkyBlue)
			{
				i_CurrentWindowButton.BackColor = Color.White;
			}
		}

		protected virtual void OnWindowButtonSelected(GameWindowButton i_CurrentWindowButton)
		{
			WindowButtonSelect?.Invoke(i_CurrentWindowButton.ButtonLocation);
		}

		public void Game_PieceCreated(Point i_Location, char i_Symbol)
		{
			Controls[i_Location.ToString()].Text = i_Symbol.ToString();
		}

		public void Game_PieceMoved(Point i_Location, Point i_Destination)
		{
			Controls[i_Destination.ToString()].Text = Controls[i_Location.ToString()].Text;
			Controls[i_Location.ToString()].Text = string.Empty;
		}

		public void Game_PieceRemoved(Point i_Location)
		{
			Controls[i_Location.ToString()].Text = string.Empty;
		}

		public void Game_PieceMadeKing(Point i_Location, char i_Symbol)
		{
			Controls[i_Location.ToString()].Text = i_Symbol.ToString();
		}

		public void Game_GameOver(string i_WinnerName)
		{
			string gameResult = i_WinnerName != null ? i_WinnerName + " Won" : " Tie";
			DialogResult result = MessageBox.Show(string.Format("{0}! {1}Another Round?", gameResult, Environment.NewLine), "Game Over", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				OnResetGame();
			}
			else
			{
				MessageBox.Show("Thanks For Playing!", "Checkers", MessageBoxButtons.OK);
				Close();
			}
		}

		protected virtual void OnResetGame()
		{
			ResetGame?.Invoke();
		}

		public void Game_PlayerScoreChanged(string i_Player, string i_Score)
		{
			if (i_Player + ":" == labelPlayerOneName.Text)
			{
				labelPlayerOneScore.Text = i_Score;
			}
			else
			{
				labelPlayerTwoScore.Text = i_Score;
			}
		}
	}
}