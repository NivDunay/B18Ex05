﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace B18Ex05.Checkers.View
{
	public partial class GameSettings : Form
	{
		private int m_PlayerSelectedBoardSize;

		public GameSettings()
		{
			InitializeComponent();
			ShowDialog();
		}

		private void radioButton_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
		{
			if (i_Sender is RadioButton radioButton && radioButton.Checked)
			{
				PlayerSelectedBoardSize = int.Parse(radioButton.Tag.ToString());
			}
		}

		public int PlayerSelectedBoardSize
		{
			get { return m_PlayerSelectedBoardSize; }
			set { m_PlayerSelectedBoardSize = value; }
		}

		private void checkBoxPlayerTwo_CheckedChanged(object i_Sender, EventArgs i_EventArgs)
		{
			if (i_Sender is CheckBox checkBox && checkBox.Checked)
			{
				removeText();
			}
			else
			{
				addText();
				errorProvider.SetError(textBoxPlayerTwoName, string.Empty);
			}
		}

		private void buttonDone_Click(object i_Sender, EventArgs i_EventArgs)
		{
			if (validateForm())
			{
				DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show("Please enter valid data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void textBoxPlayerName_TextChanged(object i_Sender, EventArgs i_EventArgs)
		{
			validateName(i_Sender as TextBox);
		}

		private bool validateName(TextBox i_PlayerName)
		{
			Regex nameValidation = new Regex("^[A-Za-z]{1,10}$");
			bool isNameValid = nameValidation.IsMatch(i_PlayerName.Text) || i_PlayerName.Text == "[Computer]";
			if (!isNameValid)
			{
				errorProvider.SetError(i_PlayerName, "Please enter a valid name!");
			}
			else
			{
				errorProvider.SetError(i_PlayerName, string.Empty);
			}

			return isNameValid;
		}

		private bool validateForm()
		{
			return validateName(textBoxPlayerOneName) && validateName(textBoxPlayerTwoName);
		}

		private void removeText()
		{
			textBoxPlayerTwoName.Text = string.Empty;
			textBoxPlayerTwoName.Enabled = true;
		}

		private void addText()
		{
			textBoxPlayerTwoName.Text = "[Computer]";
			textBoxPlayerTwoName.Enabled = false;
		}

		public bool IsPlayerTwoActive
		{
			get { return checkBoxPlayerTwo.Checked; }
		}

		public string PlayerOneName
		{
			get { return textBoxPlayerOneName.Text; }
			set { textBoxPlayerOneName.Text = value; }
		}

		public string PlayerTwoName
		{
			get { return textBoxPlayerTwoName.Text; }
			set { textBoxPlayerTwoName.Text = value; }
		}
	}
}
