using System;
using System.Drawing;
using System.Windows.Forms;

namespace B18Ex05.Checkers.View
{
	public class GameBoard : Form
	{
		private readonly int   r_GameBoardSize;
		private          Label m_PlayerOneName;
		private          Label m_PlayerTwoName;
		private GameBoardSquare m_CurrentBoardSquare;

		public GameBoard(int i_GameBoardSize)
		{
			r_GameBoardSize = i_GameBoardSize;
			AutoSize        = true;
			AutoSizeMode    = AutoSizeMode.GrowAndShrink;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			createButtonMatrix();
			initializeComponents();
		}

		private void initializeComponents()
		{
			m_PlayerOneName = new Label
			{
				AutoSize = true,
				Name     = "PlayerOneLabel",
				Font     = new Font(Font, FontStyle.Bold),
				Location = new Point(ClientSize.Width / 9 * 2, Constants.k_LabelStartY)
			};
			Controls.Add(m_PlayerOneName);
			m_PlayerTwoName = new Label
			{
				AutoSize = true,
				Name     = "PlayerTwoLabel",
				Font     = new Font(Font, FontStyle.Bold),
				Location = new Point(ClientSize.Width / 9 * 6, Constants.k_LabelStartY)
			};
			Controls.Add(m_PlayerTwoName);
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

		private void createButtonMatrix()
		{
			for (int row = 0; row < r_GameBoardSize; row++)
			{
				for (int col = 0; col < r_GameBoardSize; col++)
				{
					GameBoardSquare currentSquare = new GameBoardSquare(new Point(row, col));
					if (row % 2 == 0 && col % 2 == 0 || row % 2 == 1 && col % 2 == 1)
					{
						currentSquare.Enabled   = false;
						currentSquare.BackColor = Color.Gray;
					}

					currentSquare.Top  = row * Constants.k_ButtonHeight + Constants.k_ButtonStartY;
					currentSquare.Left = col * Constants.k_ButtonWidth  + Constants.k_ButtonStartX;
					currentSquare.Click += gameBoardSquare_ButtonClicked;
					Controls.Add(currentSquare);
				}
			}
		}

		private void gameBoardSquare_ButtonClicked(object i_Sender, EventArgs i_EventArgs)
		{
			GameBoardSquare currentButton = i_Sender as GameBoardSquare;
			adjustButtonColor(currentButton);
		}

		private void adjustButtonColor(GameBoardSquare i_CurrentButton)
		{
			if (m_CurrentBoardSquare == null)
			{
				m_CurrentBoardSquare = i_CurrentButton;
			}
			else if (m_CurrentBoardSquare != i_CurrentButton)
			{
				swapButtonColour(m_CurrentBoardSquare);
				m_CurrentBoardSquare = i_CurrentButton;
			}
			else
			{
				m_CurrentBoardSquare = null;
			}

			swapButtonColour(i_CurrentButton);
		}

		private void swapButtonColour(GameBoardSquare i_CurrentBoardSquare)
		{
			i_CurrentBoardSquare.BackColor = i_CurrentBoardSquare.BackColor == Color.White ? Color.LightSkyBlue : Color.White;
		}
	}
}