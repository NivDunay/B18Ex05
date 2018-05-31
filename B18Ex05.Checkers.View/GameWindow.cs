using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B18Ex05.Checkers.View
{
	public delegate void GameWindowButtonSelected(Point i_Location);

	public delegate void StartNewGame();

	public delegate void GetMove(Point i_Location, Point i_Destination);

	public partial class GameWindow : Form
	{

		private int m_GameWindowSize;
		private bool m_PlayerTwoActive;
		private GameSettings m_GameSettings;
		private GameWindowButton m_CurrentWindowButton;
		private GameWindowButton m_WindowButtonDestination;
		private List<GameWindowButton> m_ComputerLastActions;

		public event GetMove                 UserMoveSelect;

		public event StartNewGame            ResetGame;

		public event GameWindowButtonSelected WindowButtonSelect;

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
				labelPlayerOneScore.Left = labelPlayerOneName.Right + 5;
				labelPlayerTwoScore.Left = labelPlayerTwoName.Right + 5;
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
					if (row % 2 == 0 && col % 2 == 0 || row % 2 == 1 && col % 2 == 1)
					{
						currentSquare.Enabled = false;
						currentSquare.BackColor = Color.Gray;
					}

					currentSquare.Top = row  * Constants.k_ButtonHeight + Constants.k_ButtonStartY;
					currentSquare.Left = col * Constants.k_ButtonWidth  + Constants.k_ButtonStartX;
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
				try
				{
					validateSelectedPiece(currentButton);
					m_CurrentWindowButton = currentButton;
					swapButtonColor(currentButton);
				}
				catch (ArgumentException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else if (m_CurrentWindowButton == currentButton)
			{
				swapButtonColor(m_CurrentWindowButton);
				m_CurrentWindowButton = null;
			}
			else
			{
				m_WindowButtonDestination = currentButton;
				onPieceMove();
				swapButtonColor(m_CurrentWindowButton);
				m_CurrentWindowButton = null;
				m_WindowButtonDestination = null;
			}
		}

		private void resetComputerActions()
		{
			foreach (GameWindowButton computerAction in m_ComputerLastActions)
			{
				swapButtonColor(computerAction);
			}

			m_ComputerLastActions.Clear();
		}

		private void onPieceMove()
		{
			try
			{
				UserMoveSelect?.Invoke(m_CurrentWindowButton.ButtonLocation, m_WindowButtonDestination.ButtonLocation);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}


		public void onComputerGamePieceMove(Point i_Location, Point i_Destination)
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
			i_CurrentWindowButton.BackColor = i_CurrentWindowButton.BackColor == Color.White ? Color.LightSkyBlue : Color.White;
		}

		private void validateSelectedPiece(GameWindowButton i_CurrentWindowButton)
		{
			WindowButtonSelect?.Invoke(i_CurrentWindowButton.ButtonLocation);
		}

		public void OnGameButtonCreated(Point i_Location, char i_Symbol)
		{
			Controls[i_Location.ToString()].Text = i_Symbol.ToString();
		}

		public void OnGameButtonMove(Point i_Location, Point i_Destination)
		{
			Controls[i_Destination.ToString()].Text = Controls[i_Location.ToString()].Text;
			Controls[i_Location.ToString()].Text = string.Empty;
		}

		public void OnGameButtonRemoved(Point i_Location)
		{
			Controls[i_Location.ToString()].Text = string.Empty;
		}

		public void OnGameButtonChangeSymbol(Point i_Location, char i_Symbol)
		{
			Controls[i_Location.ToString()].Text = i_Symbol.ToString();
		}

		public void OnGameOver(string i_PlayerName)
		{
			string gameResult = i_PlayerName != null ? i_PlayerName + " Won" : " Tie";
			DialogResult result = MessageBox.Show(string.Format("{0}! {1}Another Round?", gameResult, Environment.NewLine), "Game Over", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				ResetGame?.Invoke();
			}
			else
			{
				MessageBox.Show("Thanks For Playing!", "Checkers", MessageBoxButtons.OK);
				Close();
			}
		}

		public void OnScoreChanged(string i_Player, string i_Score)
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
