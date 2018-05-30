namespace B18Ex05.Checkers.View
{
	partial class GameWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
			this.labelPlayerOneName = new System.Windows.Forms.Label();
			this.labelPlayerTwoName = new System.Windows.Forms.Label();
			this.labelPlayerOneScore = new System.Windows.Forms.Label();
			this.labelPlayerTwoScore = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelPlayerOneName
			// 
			this.labelPlayerOneName.AutoSize = true;
			this.labelPlayerOneName.Location = new System.Drawing.Point(25, 18);
			this.labelPlayerOneName.Name = "labelPlayerOneName";
			this.labelPlayerOneName.Size = new System.Drawing.Size(48, 13);
			this.labelPlayerOneName.TabIndex = 0;
			this.labelPlayerOneName.Text = "Player 1:";
			this.labelPlayerOneName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPlayerTwoName
			// 
			this.labelPlayerTwoName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPlayerTwoName.AutoSize = true;
			this.labelPlayerTwoName.Location = new System.Drawing.Point(188, 18);
			this.labelPlayerTwoName.Name = "labelPlayerTwoName";
			this.labelPlayerTwoName.Size = new System.Drawing.Size(48, 13);
			this.labelPlayerTwoName.TabIndex = 1;
			this.labelPlayerTwoName.Text = "Player 2:";
			this.labelPlayerTwoName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPlayerOneScore
			// 
			this.labelPlayerOneScore.AutoSize = true;
			this.labelPlayerOneScore.Location = new System.Drawing.Point(79, 18);
			this.labelPlayerOneScore.Name = "labelPlayerOneScore";
			this.labelPlayerOneScore.Size = new System.Drawing.Size(13, 13);
			this.labelPlayerOneScore.TabIndex = 2;
			this.labelPlayerOneScore.Text = "0";
			this.labelPlayerOneScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPlayerTwoScore
			// 
			this.labelPlayerTwoScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPlayerTwoScore.AutoSize = true;
			this.labelPlayerTwoScore.Location = new System.Drawing.Point(242, 18);
			this.labelPlayerTwoScore.Name = "labelPlayerTwoScore";
			this.labelPlayerTwoScore.Size = new System.Drawing.Size(13, 13);
			this.labelPlayerTwoScore.TabIndex = 3;
			this.labelPlayerTwoScore.Text = "0";
			this.labelPlayerTwoScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GameWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(305, 258);
			this.Controls.Add(this.labelPlayerOneScore);
			this.Controls.Add(this.labelPlayerOneName);
			this.Controls.Add(this.labelPlayerTwoScore);
			this.Controls.Add(this.labelPlayerTwoName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "GameWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Checkers - By Niv and Jon";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelPlayerOneName;
		private System.Windows.Forms.Label labelPlayerTwoName;
		private System.Windows.Forms.Label labelPlayerOneScore;
		private System.Windows.Forms.Label labelPlayerTwoScore;
	}
}