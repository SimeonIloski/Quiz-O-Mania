namespace Quiz_
{
    partial class HighScores
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
            this.p1 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.Label();
            this.p3 = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // p1
            // 
            this.p1.AutoSize = true;
            this.p1.Location = new System.Drawing.Point(12, 99);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(0, 13);
            this.p1.TabIndex = 1;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 72);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(57, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "UserName";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(91, 72);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(35, 13);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = "Score";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(173, 72);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(34, 13);
            this.lblMode.TabIndex = 6;
            this.lblMode.Text = "Mode";
            // 
            // p2
            // 
            this.p2.AutoSize = true;
            this.p2.Location = new System.Drawing.Point(91, 99);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(0, 13);
            this.p2.TabIndex = 7;
            // 
            // p3
            // 
            this.p3.AutoSize = true;
            this.p3.Location = new System.Drawing.Point(173, 99);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(0, 13);
            this.p3.TabIndex = 8;
            // 
            // cbMode
            // 
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Location = new System.Drawing.Point(125, 18);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(121, 21);
            this.cbMode.TabIndex = 9;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Choose Game Mode";
            // 
            // HighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 197);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMode);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.p1);
            this.Name = "HighScores";
            this.Text = "HighScores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label p1;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label p2;
        private System.Windows.Forms.Label p3;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.Label label1;
    }
}