namespace Quiz_
{
    partial class SuddenDeath
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
            this.components = new System.ComponentModel.Container();
            this.lbluserName = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.gbQuestions = new System.Windows.Forms.GroupBox();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnGiveUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbTime = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.pbTotalTimeLeft = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gbQuestions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lbluserName
            // 
            this.lbluserName.AutoSize = true;
            this.lbluserName.Location = new System.Drawing.Point(12, 16);
            this.lbluserName.Name = "lbluserName";
            this.lbluserName.Size = new System.Drawing.Size(63, 13);
            this.lbluserName.TabIndex = 0;
            this.lbluserName.Text = "User Name:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(88, 13);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(113, 20);
            this.tbUser.TabIndex = 1;
            // 
            // gbQuestions
            // 
            this.gbQuestions.Controls.Add(this.rb4);
            this.gbQuestions.Controls.Add(this.rb3);
            this.gbQuestions.Controls.Add(this.rb2);
            this.gbQuestions.Controls.Add(this.rb1);
            this.gbQuestions.Location = new System.Drawing.Point(19, 64);
            this.gbQuestions.Name = "gbQuestions";
            this.gbQuestions.Size = new System.Drawing.Size(309, 94);
            this.gbQuestions.TabIndex = 3;
            this.gbQuestions.TabStop = false;
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Location = new System.Drawing.Point(158, 56);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(14, 13);
            this.rb4.TabIndex = 3;
            this.rb4.TabStop = true;
            this.rb4.UseVisualStyleBackColor = true;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(19, 56);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(14, 13);
            this.rb3.TabIndex = 2;
            this.rb3.TabStop = true;
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(158, 20);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(14, 13);
            this.rb2.TabIndex = 1;
            this.rb2.TabStop = true;
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(19, 20);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(14, 13);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(19, 195);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(160, 195);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 5;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click_1);
            // 
            // btnGiveUp
            // 
            this.btnGiveUp.Location = new System.Drawing.Point(298, 195);
            this.btnGiveUp.Name = "btnGiveUp";
            this.btnGiveUp.Size = new System.Drawing.Size(75, 23);
            this.btnGiveUp.TabIndex = 6;
            this.btnGiveUp.Text = "Give up";
            this.btnGiveUp.UseVisualStyleBackColor = true;
            this.btnGiveUp.Click += new System.EventHandler(this.btnGiveUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Time left:";
            // 
            // pbTime
            // 
            this.pbTime.Location = new System.Drawing.Point(12, 241);
            this.pbTime.Maximum = 10;
            this.pbTime.Name = "pbTime";
            this.pbTime.Size = new System.Drawing.Size(397, 23);
            this.pbTime.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Time Left:";
            // 
            // pbTotalTimeLeft
            // 
            this.pbTotalTimeLeft.Location = new System.Drawing.Point(12, 296);
            this.pbTotalTimeLeft.Maximum = 15;
            this.pbTotalTimeLeft.Name = "pbTotalTimeLeft";
            this.pbTotalTimeLeft.Size = new System.Drawing.Size(397, 23);
            this.pbTotalTimeLeft.Step = 1;
            this.pbTotalTimeLeft.TabIndex = 10;
            this.pbTotalTimeLeft.Value = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Score:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "label4";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(266, 19);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(0, 13);
            this.lblPoints.TabIndex = 14;
            // 
            // pbPicture
            // 
            this.pbPicture.Location = new System.Drawing.Point(415, 13);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(334, 325);
            this.pbPicture.TabIndex = 15;
            this.pbPicture.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // SuddenDeath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 350);
            this.Controls.Add(this.pbPicture);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbTotalTimeLeft);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGiveUp);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.gbQuestions);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lbluserName);
            this.Name = "SuddenDeath";
            this.Text = "SuddenDeath";
            this.Load += new System.EventHandler(this.SuddenDeath_Load);
            this.gbQuestions.ResumeLayout(false);
            this.gbQuestions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbluserName;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.GroupBox gbQuestions;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnGiveUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbTotalTimeLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.Timer timer2;
    }
}