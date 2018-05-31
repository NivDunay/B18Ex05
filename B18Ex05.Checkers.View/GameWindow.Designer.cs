﻿namespace B18Ex05.Checkers.View
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
            this.labelPlayerTurnName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPlayerOneName
            // 
            this.labelPlayerOneName.AutoSize = true;
            this.labelPlayerOneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayerOneName.Location = new System.Drawing.Point(10, 18);
            this.labelPlayerOneName.Name = "labelPlayerOneName";
            this.labelPlayerOneName.Size = new System.Drawing.Size(57, 13);
            this.labelPlayerOneName.TabIndex = 0;
            this.labelPlayerOneName.Text = "Player 1:";
            this.labelPlayerOneName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayerTwoName
            // 
            this.labelPlayerTwoName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayerTwoName.AutoSize = true;
            this.labelPlayerTwoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayerTwoName.Location = new System.Drawing.Point(93, 18);
            this.labelPlayerTwoName.Name = "labelPlayerTwoName";
            this.labelPlayerTwoName.Size = new System.Drawing.Size(57, 13);
            this.labelPlayerTwoName.TabIndex = 1;
            this.labelPlayerTwoName.Text = "Player 2:";
            this.labelPlayerTwoName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayerOneScore
            // 
            this.labelPlayerOneScore.AutoSize = true;
            this.labelPlayerOneScore.BackColor = System.Drawing.SystemColors.Control;
            this.labelPlayerOneScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayerOneScore.Location = new System.Drawing.Point(64, 18);
            this.labelPlayerOneScore.Name = "labelPlayerOneScore";
            this.labelPlayerOneScore.Size = new System.Drawing.Size(14, 13);
            this.labelPlayerOneScore.TabIndex = 2;
            this.labelPlayerOneScore.Text = "0";
            this.labelPlayerOneScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayerTwoScore
            // 
            this.labelPlayerTwoScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayerTwoScore.AutoSize = true;
            this.labelPlayerTwoScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayerTwoScore.Location = new System.Drawing.Point(154, 18);
            this.labelPlayerTwoScore.Name = "labelPlayerTwoScore";
            this.labelPlayerTwoScore.Size = new System.Drawing.Size(14, 13);
            this.labelPlayerTwoScore.TabIndex = 3;
            this.labelPlayerTwoScore.Text = "0";
            this.labelPlayerTwoScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayerTurnName
            // 
            this.labelPlayerTurnName.AutoSize = true;
            this.labelPlayerTurnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayerTurnName.ForeColor = System.Drawing.Color.Red;
            this.labelPlayerTurnName.Location = new System.Drawing.Point(32, 31);
            this.labelPlayerTurnName.Name = "labelPlayerTurnName";
            this.labelPlayerTurnName.Size = new System.Drawing.Size(127, 13);
            this.labelPlayerTurnName.TabIndex = 4;
            this.labelPlayerTurnName.Text = "labelPlayerTurnName";
            this.labelPlayerTurnName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(203, 258);
            this.Controls.Add(this.labelPlayerTurnName);
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
        private System.Windows.Forms.Label labelPlayerTurnName;
    }
}