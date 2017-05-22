namespace Quiz_
{
    partial class SingleFormOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnHighScores = new System.Windows.Forms.Button();
            this.btnHow = new System.Windows.Forms.Button();
            this.cbGameMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quiz-O-Mania";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name:";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(116, 75);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(136, 20);
            this.tbUser.TabIndex = 2;
            this.tbUser.Validating += new System.ComponentModel.CancelEventHandler(this.tbUser_Validating);
            // 
            // cbCategory
            // 
            this.cbCategory.Enabled = false;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(116, 199);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(136, 21);
            this.cbCategory.TabIndex = 3;
            this.cbCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cbCategory_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Category";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 242);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnHighScores
            // 
            this.btnHighScores.CausesValidation = false;
            this.btnHighScores.Location = new System.Drawing.Point(152, 242);
            this.btnHighScores.Name = "btnHighScores";
            this.btnHighScores.Size = new System.Drawing.Size(100, 23);
            this.btnHighScores.TabIndex = 6;
            this.btnHighScores.Text = "High Scores";
            this.btnHighScores.UseVisualStyleBackColor = true;
            this.btnHighScores.Click += new System.EventHandler(this.btnHighScores_Click);
            // 
            // btnHow
            // 
            this.btnHow.CausesValidation = false;
            this.btnHow.Location = new System.Drawing.Point(288, 242);
            this.btnHow.Name = "btnHow";
            this.btnHow.Size = new System.Drawing.Size(100, 23);
            this.btnHow.TabIndex = 7;
            this.btnHow.Text = "How to play";
            this.btnHow.UseVisualStyleBackColor = true;
            this.btnHow.Click += new System.EventHandler(this.btnHow_Click);
            // 
            // cbGameMode
            // 
            this.cbGameMode.FormattingEnabled = true;
            this.cbGameMode.Location = new System.Drawing.Point(116, 128);
            this.cbGameMode.Name = "cbGameMode";
            this.cbGameMode.Size = new System.Drawing.Size(136, 21);
            this.cbGameMode.TabIndex = 8;
            this.cbGameMode.SelectedIndexChanged += new System.EventHandler(this.cbGameMode_SelectedIndexChanged);
            this.cbGameMode.Validating += new System.ComponentModel.CancelEventHandler(this.cbGameMode_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Select Game Mode";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SingleFormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 288);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbGameMode);
            this.Controls.Add(this.btnHow);
            this.Controls.Add(this.btnHighScores);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SingleFormOptions";
            this.Text = "SingleFormOptions";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnHighScores;
        private System.Windows.Forms.Button btnHow;
        private System.Windows.Forms.ComboBox cbGameMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}