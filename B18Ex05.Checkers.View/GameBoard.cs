using System;
using System.Drawing;
using System.Windows.Forms;

namespace B18Ex05.Checkers.View
{
	public delegate void GetMove(Point i_Location, Point i_Destination);

	public delegate void StartNewGame();

	public class GameBoard : Form
	{
		private readonly int r_GameBoardSize;
		private readonly bool r_PlayerTwoActive;
		private Label m_PlayerOneName;
		private Label m_PlayerTwoName;
		private Label m_PlayerOneScore;
		private Label m_PlayerTwoScore;
		private GameBoardSquare m_CurrentBoardSquare;
		private GameBoardSquare m_BoardSquareDestination;
		public event GetMove      UserMoveSelcted;
		public event StartNewGame StartGame;
		private readonly Settings r_GameSettings;

		public GameBoard()
		{
			r_GameSettings = new Settings();
			r_GameBoardSize = r_GameSettings.PlayerSelectedBoardSize;
			r_PlayerTwoActive = r_GameSettings.IsPlayerTwoActive;
			createButtonMatrix();
			initializeComponents();
			r_GameSettings.Close();
		}

		private void initializeComponents()
		{
			AutoSize = true;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			StartPosition = FormStartPosition.CenterScreen;
			Font = new Font(Font, FontStyle.Bold);
			Text = "Checkers";
			m_PlayerOneName = new Label
			{
				AutoSize = true,
				Name = "PlayerOneLabel",
				Font = new Font(Font, FontStyle.Bold),
				Location = new Point(ClientSize.Width / 9 * 2, Constants.k_LabelStartY),
				Text = r_GameSettings.PlayerOneName
			};
			Controls.Add(m_PlayerOneName);
			m_PlayerOneScore = new Label
			{
				AutoSize = true,
				Name = "PlayerOneScoreLabel",
				Font = new Font(Font, FontStyle.Bold),
				Location = new Point(m_PlayerOneName.Location.X + m_PlayerOneName.Size.Width, Constants.k_LabelStartY),
				Text = ": 0"
			};
			Controls.Add(m_PlayerOneScore);
			m_PlayerTwoName = new Label
			{
				AutoSize = true,
				Name = "PlayerTwoLabel",
				Font = new Font(Font, FontStyle.Bold),
				Location = new Point(ClientSize.Width / 9 * 6, Constants.k_LabelStartY),
				Text = r_GameSettings.PlayerTwoName
			};
			Controls.Add(m_PlayerTwoName);
			m_PlayerTwoScore = new Label
			{
				AutoSize = true,
				Name = "PlayerTwoScoreLabel",
				Font = new Font(Font, FontStyle.Bold),
				Location = new Point(m_PlayerTwoName.Location.X + m_PlayerTwoName.Size.Width, Constants.k_LabelStartY),
				Text = ": 0"
			};
			Controls.Add(m_PlayerTwoScore);
		}

		public int GameBoardSize
		{
			get { return r_GameBoardSize; }
		}

		public string PlayerOneName
		{
			get { return m_PlayerOneName.Text; }
			set { m_PlayerOneName.Text = value; }
		}

		public string PlayerTwoName
		{
			get { return m_PlayerTwoName.Text; }
			set { m_PlayerTwoName.Text = value; }
		}

		public bool IsPlayerTwoActive
		{
			get { return r_PlayerTwoActive; }
		}

		private void createButtonMatrix()
		{
			for (int row = 0; row < r_GameBoardSize; row++)
			{
				for (int col = 0; col < r_GameBoardSize; col++)
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

		private void onPieceMove()
		{
			UserMoveSelcted?.Invoke(m_CurrentBoardSquare.BoardLocation, m_BoardSquareDestination.BoardLocation);
		}

		private void gameBoardSquare_ButtonClicked(object i_Sender, EventArgs i_EventArgs)
		{
			GameBoardSquare currentButton = i_Sender as GameBoardSquare;
			if (m_CurrentBoardSquare == null)
			{
				m_CurrentBoardSquare = currentButton;
				swapButtonColour(currentButton);
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

		private void swapButtonColour(GameBoardSquare i_CurrentBoardSquare)
		{
			i_CurrentBoardSquare.BackColor = i_CurrentBoardSquare.BackColor == Color.White ? Color.LightSkyBlue : Color.White;
		}

		public void NewGamePieceCreatedHandler(Point i_Location, char i_Symbol)
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

		public void OnIllegalMove()
		{
			MessageBox.Show("Illegal move selected!", "Error");
		}

		public void OnGameOver(string i_PlayerName)
		{
			string gameResult = i_PlayerName != null ? i_PlayerName + " Won" : " Tie";
			DialogResult result = MessageBox.Show(string.Format("{0}! {1}Another Round?", gameResult, Environment.NewLine), "Game Over", MessageBoxButtons.YesNo);
			if (result == DialogResult.Yes)
			{
				StartGame?.Invoke();
			}
			else
			{
				MessageBox.Show("Thanks For Playing!", "Checkers", MessageBoxButtons.OK);
				Close();
			}
		}

		public void OnScoreChanged(string i_Player, string i_Score)
		{
			if (i_Player == m_PlayerOneName.Text)
			{
				m_PlayerOneScore.Text = ": " + i_Score;
			}
			else
			{
				m_PlayerTwoScore.Text = ": " + i_Score;
			}
		}
	}
}