using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace B18Ex05.Checkers.View
{
	public class GameBoard : Form 
	{
		private readonly int r_GameBoardSize;
		private Label m_PlayerOneName;
		private Label m_PlayerTwoName;

		public GameBoard(int i_GameBoardSize)
		{
			r_GameBoardSize = i_GameBoardSize;
			AutoSize = true;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			CreateButtonMatrix();
			initializeComponents();
		}

		private void initializeComponents()
		{
			m_PlayerOneName = new Label();
			m_PlayerOneName.Size = new Size(44, 13);
			m_PlayerOneName.Name = "PlayerOneLabel";
			Controls.Add(m_PlayerOneName);
			m_PlayerOneName.Location = new Point(this.ClientSize.Width / 4, Constants.k_LabelStartY);

			m_PlayerTwoName = new Label();
			m_PlayerTwoName.Size = new Size(55, 13);
			m_PlayerTwoName.Name = "PlayerTwoLabel";
			Controls.Add(m_PlayerTwoName);
			m_PlayerTwoName.Location = new Point((this.ClientSize.Width / 4) * 3, Constants.k_LabelStartY);
		}

		public int GameBoardSize
		{
			get
			{
				return r_GameBoardSize;
			}
		}

		public string PlayerOneName
		{
			get
			{
				return m_PlayerOneName.Text;
			}
			set
			{
				m_PlayerOneName.Text = value;
			}
		}

		public string PlayerTwoName
		{
			get
			{
				return m_PlayerTwoName.Text;
			}
			set
			{
				m_PlayerTwoName.Text = value;
			}
		}

		private void CreateButtonMatrix()
		{
			for (int row = 0; row < r_GameBoardSize; row++)
			{
				for (int col = 0; col < r_GameBoardSize; col++)
				{
					GameBoardSquare currentSquare = new GameBoardSquare(new Point(row, col));

					if((row % 2 == 0 && col % 2 == 0) || (row % 2 == 1 && col % 2 == 1))
					{
						currentSquare.Enabled = false;
						currentSquare.BackColor = Color.DarkGray;
					}

					currentSquare.Top = (row * Constants.k_ButtonHeight) + Constants.k_ButtonStartY;
					currentSquare.Left = (col * Constants.k_ButtonWidth) + Constants.k_ButtonStartX;
					Controls.Add(currentSquare);
				}
			}
		}
	}
}
