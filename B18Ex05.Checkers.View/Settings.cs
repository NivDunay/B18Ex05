using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace B18Ex05.Checkers.View
{
	public class Settings : Form
	{
		private Label m_BoardSizeLabel;
		private Button m_DoneButton;
		private ErrorProvider m_ErrorProvider;
		private Label m_PlayerOneLabel;
		private TextBox m_PlayerOneNameTextBox;
		private int m_PlayerSelectedBoardSize;
		private Label m_PlayersLabel;
		private CheckBox m_PlayerTwoCheckBox;
		private TextBox m_PlayerTwoNameTextBox;
		private RadioButton m_RadioButton10X10;
		private RadioButton m_RadioButton6X6;
		private System.ComponentModel.IContainer components;
		private RadioButton m_RadioButton8X8;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_RadioButton6X6 = new System.Windows.Forms.RadioButton();
			this.m_RadioButton8X8 = new System.Windows.Forms.RadioButton();
			this.m_RadioButton10X10 = new System.Windows.Forms.RadioButton();
			this.m_BoardSizeLabel = new System.Windows.Forms.Label();
			this.m_PlayersLabel = new System.Windows.Forms.Label();
			this.m_PlayerOneLabel = new System.Windows.Forms.Label();
			this.m_PlayerOneNameTextBox = new System.Windows.Forms.TextBox();
			this.m_PlayerTwoCheckBox = new System.Windows.Forms.CheckBox();
			this.m_PlayerTwoNameTextBox = new System.Windows.Forms.TextBox();
			this.m_DoneButton = new System.Windows.Forms.Button();
			this.m_ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.m_ErrorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// m_RadioButton6X6
			// 
			this.m_RadioButton6X6.AutoSize = true;
			this.m_RadioButton6X6.BackColor = System.Drawing.SystemColors.Control;
			this.m_RadioButton6X6.Location = new System.Drawing.Point(24, 49);
			this.m_RadioButton6X6.Name = "m_RadioButton6X6";
			this.m_RadioButton6X6.Size = new System.Drawing.Size(59, 21);
			this.m_RadioButton6X6.TabIndex = 0;
			this.m_RadioButton6X6.TabStop = true;
			this.m_RadioButton6X6.Tag = "6";
			this.m_RadioButton6X6.Text = "6 x 6";
			this.m_RadioButton6X6.UseVisualStyleBackColor = false;
			this.m_RadioButton6X6.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// m_RadioButton8X8
			// 
			this.m_RadioButton8X8.AutoSize = true;
			this.m_RadioButton8X8.Location = new System.Drawing.Point(89, 49);
			this.m_RadioButton8X8.Name = "m_RadioButton8X8";
			this.m_RadioButton8X8.Size = new System.Drawing.Size(59, 21);
			this.m_RadioButton8X8.TabIndex = 1;
			this.m_RadioButton8X8.TabStop = true;
			this.m_RadioButton8X8.Tag = "8";
			this.m_RadioButton8X8.Text = "8 x 8";
			this.m_RadioButton8X8.UseVisualStyleBackColor = true;
			this.m_RadioButton8X8.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// m_RadioButton10X10
			// 
			this.m_RadioButton10X10.AutoSize = true;
			this.m_RadioButton10X10.Location = new System.Drawing.Point(155, 49);
			this.m_RadioButton10X10.Name = "m_RadioButton10X10";
			this.m_RadioButton10X10.Size = new System.Drawing.Size(75, 21);
			this.m_RadioButton10X10.TabIndex = 2;
			this.m_RadioButton10X10.TabStop = true;
			this.m_RadioButton10X10.Tag = "10";
			this.m_RadioButton10X10.Text = "10 x 10";
			this.m_RadioButton10X10.UseVisualStyleBackColor = true;
			this.m_RadioButton10X10.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// m_BoardSizeLabel
			// 
			this.m_BoardSizeLabel.AutoSize = true;
			this.m_BoardSizeLabel.Location = new System.Drawing.Point(21, 21);
			this.m_BoardSizeLabel.Name = "m_BoardSizeLabel";
			this.m_BoardSizeLabel.Size = new System.Drawing.Size(81, 17);
			this.m_BoardSizeLabel.TabIndex = 3;
			this.m_BoardSizeLabel.Text = "Board Size:";
			// 
			// m_PlayersLabel
			// 
			this.m_PlayersLabel.AutoSize = true;
			this.m_PlayersLabel.Location = new System.Drawing.Point(21, 89);
			this.m_PlayersLabel.Name = "m_PlayersLabel";
			this.m_PlayersLabel.Size = new System.Drawing.Size(59, 17);
			this.m_PlayersLabel.TabIndex = 4;
			this.m_PlayersLabel.Text = "Players:";
			// 
			// m_PlayerOneLabel
			// 
			this.m_PlayerOneLabel.AutoSize = true;
			this.m_PlayerOneLabel.Location = new System.Drawing.Point(30, 118);
			this.m_PlayerOneLabel.Name = "m_PlayerOneLabel";
			this.m_PlayerOneLabel.Size = new System.Drawing.Size(64, 17);
			this.m_PlayerOneLabel.TabIndex = 5;
			this.m_PlayerOneLabel.Text = "Player 1:";
			// 
			// m_PlayerOneNameTextBox
			// 
			this.m_PlayerOneNameTextBox.Location = new System.Drawing.Point(112, 118);
			this.m_PlayerOneNameTextBox.MaxLength = 10;
			this.m_PlayerOneNameTextBox.Name = "m_PlayerOneNameTextBox";
			this.m_PlayerOneNameTextBox.Size = new System.Drawing.Size(103, 22);
			this.m_PlayerOneNameTextBox.TabIndex = 6;
			this.m_PlayerOneNameTextBox.TextChanged += new System.EventHandler(this.PlayerNameTextBox_TextChanged);
			this.m_PlayerOneNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.playerNames_Validating);
			// 
			// m_PlayerTwoCheckBox
			// 
			this.m_PlayerTwoCheckBox.AutoSize = true;
			this.m_PlayerTwoCheckBox.Location = new System.Drawing.Point(33, 155);
			this.m_PlayerTwoCheckBox.Name = "m_PlayerTwoCheckBox";
			this.m_PlayerTwoCheckBox.Size = new System.Drawing.Size(86, 21);
			this.m_PlayerTwoCheckBox.TabIndex = 7;
			this.m_PlayerTwoCheckBox.Text = "Player 2:";
			this.m_PlayerTwoCheckBox.UseVisualStyleBackColor = true;
			this.m_PlayerTwoCheckBox.CheckedChanged += new System.EventHandler(this.onCheckBoxClicked);
			// 
			// m_PlayerTwoNameTextBox
			// 
			this.m_PlayerTwoNameTextBox.Enabled = false;
			this.m_PlayerTwoNameTextBox.Location = new System.Drawing.Point(112, 155);
			this.m_PlayerTwoNameTextBox.MaxLength = 10;
			this.m_PlayerTwoNameTextBox.Name = "m_PlayerTwoNameTextBox";
			this.m_PlayerTwoNameTextBox.Size = new System.Drawing.Size(103, 22);
			this.m_PlayerTwoNameTextBox.TabIndex = 8;
			this.m_PlayerTwoNameTextBox.Text = "[Computer]";
			this.m_PlayerTwoNameTextBox.TextChanged += new System.EventHandler(this.PlayerNameTextBox_TextChanged);
			this.m_PlayerTwoNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.playerNames_Validating);
			// 
			// m_DoneButton
			// 
			this.m_DoneButton.Location = new System.Drawing.Point(140, 200);
			this.m_DoneButton.Name = "m_DoneButton";
			this.m_DoneButton.Size = new System.Drawing.Size(75, 23);
			this.m_DoneButton.TabIndex = 9;
			this.m_DoneButton.Text = "Done";
			this.m_DoneButton.UseVisualStyleBackColor = true;
			this.m_DoneButton.Click += new System.EventHandler(this.doneButton_Click);
			// 
			// m_ErrorProvider
			// 
			this.m_ErrorProvider.ContainerControl = this;
			// 
			// Settings
			// 
			this.AcceptButton = this.m_DoneButton;
			this.ClientSize = new System.Drawing.Size(239, 244);
			this.ControlBox = false;
			this.Controls.Add(this.m_DoneButton);
			this.Controls.Add(this.m_PlayerTwoNameTextBox);
			this.Controls.Add(this.m_PlayerTwoCheckBox);
			this.Controls.Add(this.m_PlayerOneNameTextBox);
			this.Controls.Add(this.m_PlayerOneLabel);
			this.Controls.Add(this.m_PlayersLabel);
			this.Controls.Add(this.m_BoardSizeLabel);
			this.Controls.Add(this.m_RadioButton10X10);
			this.Controls.Add(this.m_RadioButton8X8);
			this.Controls.Add(this.m_RadioButton6X6);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "Settings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game Settings";
			((System.ComponentModel.ISupportInitialize)(this.m_ErrorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void removeText()
		{
			m_PlayerTwoNameTextBox.Text = string.Empty;
			m_PlayerTwoNameTextBox.Enabled = true;
		}

		private void addText()
		{
			m_PlayerTwoNameTextBox.Text = "[Computer]";
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
				m_ErrorProvider.SetError(m_PlayerTwoNameTextBox, string.Empty);
			}
		}

		private void doneButton_Click(object i_Sender, EventArgs i_EventArg)
		{
			if (validateForm())
			{
				Hide();
			}
			else
			{
				MessageBox.Show("Please enter valid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void radioButton_CheckedChanged(object i_Sender, EventArgs i_EventArg)
		{
			if (i_Sender is RadioButton radioButton && radioButton.Checked)
			{
				PlayerSelectedBoardSize = int.Parse(radioButton.Tag.ToString());
			}
		}

		private void playerNames_Validating(object i_Sender, System.ComponentModel.CancelEventArgs i_EventArgs)
		{
			TextBox playerName = i_Sender as TextBox;
			validateName(playerName);
		}

		private bool validateName(TextBox i_PlayerName)
		{
			Regex nameValidation = new Regex("^[A-Za-z]{1,10}$");
			bool isNameValid = nameValidation.IsMatch(i_PlayerName.Text) || i_PlayerName.Text == "[Computer]";
			if (!isNameValid)
			{
				m_ErrorProvider.SetError(i_PlayerName, "Please enter a valid name!");
			}
			else
			{
				m_ErrorProvider.SetError(i_PlayerName, string.Empty);
			}

			return isNameValid;
		}

		private bool validateForm()
		{
			return validateName(m_PlayerOneNameTextBox) && validateName(m_PlayerTwoNameTextBox);
		}

		public Settings()
		{
			InitializeComponent();
			m_ErrorProvider.ContainerControl = this;
			ShowDialog();
		}

		public bool IsPlayerTwoActive
		{
			get { return m_PlayerTwoCheckBox.Checked; }
		}

		public int PlayerSelectedBoardSize
		{
			get { return m_PlayerSelectedBoardSize; }
			set { m_PlayerSelectedBoardSize = value; }
		}

		public string PlayerOneName
		{
			get { return m_PlayerOneNameTextBox.Text; }
			set { m_PlayerOneNameTextBox.Text = value; }
		}

		public string PlayerTwoName
		{
			get { return m_PlayerTwoNameTextBox.Text; }
			set { m_PlayerTwoNameTextBox.Text = value; }
		}

		private void PlayerNameTextBox_TextChanged(object sender, EventArgs e)
		{
			validateName(sender as TextBox);
		}
	}
}