using System;
using System.Drawing;
using System.Windows.Forms;

namespace B18Ex05.Checkers.View
{
	public delegate void GameBoardSquareSelected(Point i_Location);

	public delegate void StartNewGame();

	public delegate void GetMove(Point i_Location, Point i_Destination);

	public partial class GameWindow : Form
	{

		private int m_GameBoardSize;
		private bool m_PlayerTwoActive;
		private GameSettings m_GameSettings;
		private GameBoardSquare m_CurrentBoardSquare;
		private GameBoardSquare m_BoardSquareDestination;

		public event GetMove                 UserMoveSelcted;

		public event StartNewGame            ResetGame;

		public event GameBoardSquareSelected BoardSquareSelected;

		public GameWindow()
		{
			initializeGameWindow();
		}

		public int GameBoardSize
		{
			get { return m_GameBoardSize; }
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
			m_GameSettings = new GameSettings();
			if (m_GameSettings.DialogResult == DialogResult.OK)
			{
				m_GameBoardSize = m_GameSettings.PlayerSelectedBoardSize;
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
			for (int row = 0; row < m_GameBoardSize; row++)
			{
				for (int col = 0; col < m_GameBoardSize; col++)
				{
					GameBoardSquare currentSquare = new GameBoardSquare(new Point(col, row));
					if (row % 2 == 0 && col % 2 == 0 || row % 2 == 1 && col % 2 == 1)
					{
						currentSquare.Enabled = false;
						currentSquare.BackColor = Color.Gray;
					}

					currentSquare.Top = row  * Constants.k_ButtonHeight + Constants.k_ButtonStartY;
					currentSquare.Left = col * Constants.k_ButtonWidth  + Constants.k_ButtonStartX;
					currentSquare.Click += gameBoardSquare_ButtonClicked;
					Controls.Add(currentSquare);
				}
			}
		}

		private void gameBoardSquare_ButtonClicked(object i_Sender, EventArgs i_E)
		{
			GameBoardSquare currentButton = i_Sender as GameBoardSquare;
			if (m_CurrentBoardSquare == null)
			{
				try
				{
					validateSelectedPiece(currentButton);
					m_CurrentBoardSquare = currentButton;
					swapButtonColour(currentButton);
				}
				catch (ArgumentException ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else if (m_CurrentBoardSquare == currentButton)
			{
				swapButtonColour(m_CurrentBoardSquare);
				m_CurrentBoardSquare = null;
			}
			else
			{
				m_BoardSquareDestination = currentButton;
				onPieceMove();
				swapButtonColour(m_CurrentBoardSquare);
				m_CurrentBoardSquare = null;
				m_BoardSquareDestination = null;
			}
		}

		private void onPieceMove()
		{
			try
			{
				UserMoveSelcted?.Invoke(m_CurrentBoardSquare.BoardLocation, m_BoardSquareDestination.BoardLocation);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void swapButtonColour(GameBoardSquare i_CurrentBoardSquare)
		{
			i_CurrentBoardSquare.BackColor = i_CurrentBoardSquare.BackColor == Color.White ? Color.LightSkyBlue : Color.White;
		}

		private void validateSelectedPiece(GameBoardSquare i_CurrentButton)
		{
			BoardSquareSelected?.Invoke(i_CurrentButton.BoardLocation);
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
