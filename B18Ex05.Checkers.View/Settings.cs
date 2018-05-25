using System;
using System.Drawing;
using System.Windows.Forms;

namespace B18Ex05.Checkers.View
{
	public class Settings : Form
	{
		private int         m_PlayerSelectedBoardSize;
		private RadioButton m_RadioButton8X8;
		private RadioButton m_RadioButton10X10;
		private Label       m_BoardSizeLabel;
		private Label       m_PlayersLabel;
		private Label       m_PlayerOneLabel;
		private TextBox     m_PlayerOneNameTextBox;
		private CheckBox    m_PlayerTwoCheckBox;
		private TextBox     m_PlayerTwoNameTextBox;
		private Button      m_DoneButton;
		private RadioButton m_RadioButton6X6;

		public Settings()
		{
			initializeComponent();
			ShowDialog();
		}

		private void initializeComponent()
		{
			m_RadioButton6X6       = new RadioButton();
			m_RadioButton8X8       = new RadioButton();
			m_RadioButton10X10     = new RadioButton();
			m_BoardSizeLabel       = new Label();
			m_PlayersLabel         = new Label();
			m_PlayerOneLabel       = new Label();
			m_PlayerOneNameTextBox = new TextBox();
			m_PlayerTwoCheckBox    = new CheckBox();
			m_PlayerTwoNameTextBox = new TextBox();
			m_DoneButton           = new Button();
			SuspendLayout();
			// 
			// RadioButton6x6
			// 
			m_RadioButton6X6.AutoSize                =  true;
			m_RadioButton6X6.BackColor               =  SystemColors.Control;
			m_RadioButton6X6.Location                =  new Point(24, 49);
			m_RadioButton6X6.Name                    =  "m_RadioButton6X6";
			m_RadioButton6X6.Size                    =  new Size(48, 17);
			m_RadioButton6X6.TabIndex                =  0;
			m_RadioButton6X6.TabStop                 =  true;
			m_RadioButton6X6.Tag                     =  "6";
			m_RadioButton6X6.Text                    =  "6 x 6";
			m_RadioButton6X6.UseVisualStyleBackColor =  false;
			m_RadioButton6X6.CheckedChanged          += radioButton_CheckedChanged;
			// 
			// RadioButton8x8
			// 
			m_RadioButton8X8.AutoSize                =  true;
			m_RadioButton8X8.Location                =  new Point(89, 49);
			m_RadioButton8X8.Name                    =  "m_RadioButton8X8";
			m_RadioButton8X8.Size                    =  new Size(48, 17);
			m_RadioButton8X8.TabIndex                =  1;
			m_RadioButton8X8.TabStop                 =  true;
			m_RadioButton8X8.Tag                     =  "8";
			m_RadioButton8X8.Text                    =  "8 x 8";
			m_RadioButton8X8.UseVisualStyleBackColor =  true;
			m_RadioButton8X8.CheckedChanged          += radioButton_CheckedChanged;
			// 
			// RadioButton10x10
			// 
			m_RadioButton10X10.AutoSize                =  true;
			m_RadioButton10X10.Location                =  new Point(155, 49);
			m_RadioButton10X10.Name                    =  "m_RadioButton10X10";
			m_RadioButton10X10.Size                    =  new Size(60, 17);
			m_RadioButton10X10.TabIndex                =  2;
			m_RadioButton10X10.TabStop                 =  true;
			m_RadioButton10X10.Tag                     =  "10";
			m_RadioButton10X10.Text                    =  "10 x 10";
			m_RadioButton10X10.UseVisualStyleBackColor =  true;
			m_RadioButton10X10.CheckedChanged          += radioButton_CheckedChanged;
			// 
			// BoardSizeLabel
			// 
			m_BoardSizeLabel.AutoSize = true;
			m_BoardSizeLabel.Location = new Point(21, 21);
			m_BoardSizeLabel.Name     = "m_BoardSizeLabel";
			m_BoardSizeLabel.Size     = new Size(61, 13);
			m_BoardSizeLabel.TabIndex = 3;
			m_BoardSizeLabel.Text     = "Board Size:";
			// 
			// PlayersLabel
			// 
			m_PlayersLabel.AutoSize = true;
			m_PlayersLabel.Location = new Point(21, 89);
			m_PlayersLabel.Name     = "m_PlayersLabel";
			m_PlayersLabel.Size     = new Size(44, 13);
			m_PlayersLabel.TabIndex = 4;
			m_PlayersLabel.Text     = "Players:";
			// 
			// PlayerOneLabel
			// 
			m_PlayerOneLabel.AutoSize = true;
			m_PlayerOneLabel.Location = new Point(30, 118);
			m_PlayerOneLabel.Name     = "m_PlayerOneLabel";
			m_PlayerOneLabel.Size     = new Size(48, 13);
			m_PlayerOneLabel.TabIndex = 5;
			m_PlayerOneLabel.Text     = "Player 1:";
			// 
			// PlayerOneNameTextBox
			// 
			m_PlayerOneNameTextBox.Location  = new Point(112, 118);
			m_PlayerOneNameTextBox.MaxLength = 10;
			m_PlayerOneNameTextBox.Name      = "m_PlayerOneNameTextBox";
			m_PlayerOneNameTextBox.Size      = new Size(103, 20);
			m_PlayerOneNameTextBox.TabIndex  = 6;
			// 
			// PlayerTwoCheckBox
			// 
			m_PlayerTwoCheckBox.AutoSize                =  true;
			m_PlayerTwoCheckBox.Location                =  new Point(33, 155);
			m_PlayerTwoCheckBox.Name                    =  "m_PlayerTwoCheckBox";
			m_PlayerTwoCheckBox.Size                    =  new Size(67, 17);
			m_PlayerTwoCheckBox.TabIndex                =  7;
			m_PlayerTwoCheckBox.Text                    =  "Player 2:";
			m_PlayerTwoCheckBox.UseVisualStyleBackColor =  true;
			m_PlayerTwoCheckBox.CheckedChanged          += onCheckBoxClicked;
			// 
			// PlayerTwoNameTextBox
			// 
			m_PlayerTwoNameTextBox.Enabled   = false;
			m_PlayerTwoNameTextBox.Location  = new Point(112, 155);
			m_PlayerTwoNameTextBox.MaxLength = 10;
			m_PlayerTwoNameTextBox.Name      = "m_PlayerTwoNameTextBox";
			m_PlayerTwoNameTextBox.Size      = new Size(103, 20);
			m_PlayerTwoNameTextBox.TabIndex  = 8;
			m_PlayerTwoNameTextBox.Text      = "[Computer]";
			// 
			// DoneButton
			// 
			m_DoneButton.Location                =  new Point(140, 200);
			m_DoneButton.Name                    =  "m_DoneButton";
			m_DoneButton.Size                    =  new Size(75, 23);
			m_DoneButton.TabIndex                =  9;
			m_DoneButton.Text                    =  "Done";
			m_DoneButton.UseVisualStyleBackColor =  true;
			m_DoneButton.Click                   += doneButton_Click;
			// 
			// Settings
			// 
			ClientSize = new Size(239, 244);
			Controls.Add(m_DoneButton);
			Controls.Add(m_PlayerTwoNameTextBox);
			Controls.Add(m_PlayerTwoCheckBox);
			Controls.Add(m_PlayerOneNameTextBox);
			Controls.Add(m_PlayerOneLabel);
			Controls.Add(m_PlayersLabel);
			Controls.Add(m_BoardSizeLabel);
			Controls.Add(m_RadioButton10X10);
			Controls.Add(m_RadioButton8X8);
			Controls.Add(m_RadioButton6X6);
			Name = "Settings";
			Text = "Game Settings";
			ResumeLayout(false);
			PerformLayout();
		}

		private void removeText()
		{
			m_PlayerTwoNameTextBox.Text    = "";
			m_PlayerTwoNameTextBox.Enabled = true;
		}

		private void addText()
		{
			m_PlayerTwoNameTextBox.Text    = "[Computer]";
			m_PlayerTwoNameTextBox.Enabled = false;
		}

		private void onCheckBoxClicked(object i_Sender, EventArgs i_EventArg)
		{
			if (i_Sender is CheckBox checkBox && checkBox.Checked)
			{
				removeText();
			}
			else
			{
				addText();
			}
		}

		private void doneButton_Click(object i_Sender, EventArgs i_EventArg)
		{
			Hide();
			GameBoard checkersGame = new GameBoard(m_PlayerSelectedBoardSize)
			{
				PlayerOneName = m_PlayerOneNameTextBox.Text + ":",
				PlayerTwoName = m_PlayerTwoNameTextBox.Text + ":"
			};
			checkersGame.ShowDialog();
			Close();
		}

		private void radioButton_CheckedChanged(object i_Sender, EventArgs i_EventArg)
		{
			if (i_Sender is RadioButton radioButton && radioButton.Checked)
			{
				m_PlayerSelectedBoardSize = int.Parse(radioButton.Tag.ToString());
			}
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Settings
			// 
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Name = "Settings";
			this.ResumeLayout(false);

		}
	}
}