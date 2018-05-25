using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace B18Ex05.Checkers.View
{
	public class Settings : Form
	{
		private int m_PlayerSelectedBoardSize;
		private RadioButton RadioButton8x8;
		private RadioButton RadioButton10x10;
		private Label BoardSizeLabel;
		private Label PlayersLabel;
		private Label PlayerOneLabel;
		private TextBox PlayerOneNameTextBox;
		private CheckBox PlayerTwoCheckBox;
		private TextBox PlayerTwoNameTextBox;
		private Button DoneButton;
		private RadioButton RadioButton6x6;

		public Settings()
		{
			InitializeComponent();
			ShowDialog();
		}

		private void InitializeComponent()
		{
			this.RadioButton6x6 = new System.Windows.Forms.RadioButton();
			this.RadioButton8x8 = new System.Windows.Forms.RadioButton();
			this.RadioButton10x10 = new System.Windows.Forms.RadioButton();
			this.BoardSizeLabel = new System.Windows.Forms.Label();
			this.PlayersLabel = new System.Windows.Forms.Label();
			this.PlayerOneLabel = new System.Windows.Forms.Label();
			this.PlayerOneNameTextBox = new System.Windows.Forms.TextBox();
			this.PlayerTwoCheckBox = new System.Windows.Forms.CheckBox();
			this.PlayerTwoNameTextBox = new System.Windows.Forms.TextBox();
			this.DoneButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// RadioButton6x6
			// 
			this.RadioButton6x6.AutoSize = true;
			this.RadioButton6x6.BackColor = System.Drawing.SystemColors.Control;
			this.RadioButton6x6.Location = new System.Drawing.Point(24, 49);
			this.RadioButton6x6.Name = "RadioButton6x6";
			this.RadioButton6x6.Size = new System.Drawing.Size(48, 17);
			this.RadioButton6x6.TabIndex = 0;
			this.RadioButton6x6.TabStop = true;
			this.RadioButton6x6.Tag = "6";
			this.RadioButton6x6.Text = "6 x 6";
			this.RadioButton6x6.UseVisualStyleBackColor = false;
			this.RadioButton6x6.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// RadioButton8x8
			// 
			this.RadioButton8x8.AutoSize = true;
			this.RadioButton8x8.Location = new System.Drawing.Point(89, 49);
			this.RadioButton8x8.Name = "RadioButton8x8";
			this.RadioButton8x8.Size = new System.Drawing.Size(48, 17);
			this.RadioButton8x8.TabIndex = 1;
			this.RadioButton8x8.TabStop = true;
			this.RadioButton8x8.Tag = "8";
			this.RadioButton8x8.Text = "8 x 8";
			this.RadioButton8x8.UseVisualStyleBackColor = true;
			this.RadioButton8x8.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// RadioButton10x10
			// 
			this.RadioButton10x10.AutoSize = true;
			this.RadioButton10x10.Location = new System.Drawing.Point(155, 49);
			this.RadioButton10x10.Name = "RadioButton10x10";
			this.RadioButton10x10.Size = new System.Drawing.Size(60, 17);
			this.RadioButton10x10.TabIndex = 2;
			this.RadioButton10x10.TabStop = true;
			this.RadioButton10x10.Tag = "10";
			this.RadioButton10x10.Text = "10 x 10";
			this.RadioButton10x10.UseVisualStyleBackColor = true;
			this.RadioButton10x10.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// BoardSizeLabel
			// 
			this.BoardSizeLabel.AutoSize = true;
			this.BoardSizeLabel.Location = new System.Drawing.Point(21, 21);
			this.BoardSizeLabel.Name = "BoardSizeLabel";
			this.BoardSizeLabel.Size = new System.Drawing.Size(61, 13);
			this.BoardSizeLabel.TabIndex = 3;
			this.BoardSizeLabel.Text = "Board Size:";
			// 
			// PlayersLabel
			// 
			this.PlayersLabel.AutoSize = true;
			this.PlayersLabel.Location = new System.Drawing.Point(21, 89);
			this.PlayersLabel.Name = "PlayersLabel";
			this.PlayersLabel.Size = new System.Drawing.Size(44, 13);
			this.PlayersLabel.TabIndex = 4;
			this.PlayersLabel.Text = "Players:";
			// 
			// PlayerOneLabel
			// 
			this.PlayerOneLabel.AutoSize = true;
			this.PlayerOneLabel.Location = new System.Drawing.Point(30, 118);
			this.PlayerOneLabel.Name = "PlayerOneLabel";
			this.PlayerOneLabel.Size = new System.Drawing.Size(48, 13);
			this.PlayerOneLabel.TabIndex = 5;
			this.PlayerOneLabel.Text = "Player 1:";
			// 
			// PlayerOneNameTextBox
			// 
			this.PlayerOneNameTextBox.Location = new System.Drawing.Point(112, 118);
			this.PlayerOneNameTextBox.MaxLength = 20;
			this.PlayerOneNameTextBox.Name = "PlayerOneNameTextBox";
			this.PlayerOneNameTextBox.Size = new System.Drawing.Size(103, 20);
			this.PlayerOneNameTextBox.TabIndex = 6;
			// 
			// PlayerTwoCheckBox
			// 
			this.PlayerTwoCheckBox.AutoSize = true;
			this.PlayerTwoCheckBox.Location = new System.Drawing.Point(33, 155);
			this.PlayerTwoCheckBox.Name = "PlayerTwoCheckBox";
			this.PlayerTwoCheckBox.Size = new System.Drawing.Size(67, 17);
			this.PlayerTwoCheckBox.TabIndex = 7;
			this.PlayerTwoCheckBox.Text = "Player 2:";
			this.PlayerTwoCheckBox.UseVisualStyleBackColor = true;
			this.PlayerTwoCheckBox.CheckedChanged += new System.EventHandler(this.onCheckBoxClicked);
			// 
			// PlayerTwoNameTextBox
			// 
			this.PlayerTwoNameTextBox.Enabled = false;
			this.PlayerTwoNameTextBox.Location = new System.Drawing.Point(112, 155);
			this.PlayerTwoNameTextBox.MaxLength = 20;
			this.PlayerTwoNameTextBox.Name = "PlayerTwoNameTextBox";
			this.PlayerTwoNameTextBox.Size = new System.Drawing.Size(103, 20);
			this.PlayerTwoNameTextBox.TabIndex = 8;
			this.PlayerTwoNameTextBox.Text = "[Computer]";
			// 
			// DoneButton
			// 
			this.DoneButton.Location = new System.Drawing.Point(140, 200);
			this.DoneButton.Name = "DoneButton";
			this.DoneButton.Size = new System.Drawing.Size(75, 23);
			this.DoneButton.TabIndex = 9;
			this.DoneButton.Text = "Done";
			this.DoneButton.UseVisualStyleBackColor = true;
			this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
			// 
			// Settings
			// 
			this.ClientSize = new System.Drawing.Size(239, 244);
			this.Controls.Add(this.DoneButton);
			this.Controls.Add(this.PlayerTwoNameTextBox);
			this.Controls.Add(this.PlayerTwoCheckBox);
			this.Controls.Add(this.PlayerOneNameTextBox);
			this.Controls.Add(this.PlayerOneLabel);
			this.Controls.Add(this.PlayersLabel);
			this.Controls.Add(this.BoardSizeLabel);
			this.Controls.Add(this.RadioButton10x10);
			this.Controls.Add(this.RadioButton8x8);
			this.Controls.Add(this.RadioButton6x6);
			this.Name = "Settings";
			this.Text = "Game Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void removeText()
		{
			PlayerTwoNameTextBox.Text = "";
			PlayerTwoNameTextBox.Enabled = true;
		}

		private void addText()
		{
			PlayerTwoNameTextBox.Text = "[Computer]";
			PlayerTwoNameTextBox.Enabled = false;
		}

		private void onCheckBoxClicked(object i_Sender, EventArgs i_EventArg)
		{
			CheckBox checkBox = i_Sender as CheckBox;
			if (checkBox.Checked == true)
			{
				removeText();
			}
			else
			{
				addText();
			}
		}

		private void DoneButton_Click(object i_Sender, EventArgs i_EventArg)
		{
			this.Hide();
			GameBoard checkersGame = new GameBoard(m_PlayerSelectedBoardSize);
			checkersGame.PlayerOneName = PlayerOneNameTextBox.Text;
			checkersGame.PlayerTwoName = PlayerTwoNameTextBox.Text;
			checkersGame.ShowDialog();
			this.Close();
		}

		private void radioButton_CheckedChanged(object i_Sender, EventArgs i_EventArg)
		{
			RadioButton radioButton = i_Sender as RadioButton;
			if (radioButton.Checked)
			{
				m_PlayerSelectedBoardSize = int.Parse(radioButton.Tag.ToString());
			}
		}

		//private void textBox_TextChanged(object i_Sender, EventArgs i_EventArg)
		//{
		//	TextBox textBox = i_Sender as TextBox;
		//	if(textBox.Modified)
		//	{
		//		textBox.Text = textBox.
		//	}
		//}
	}
}
