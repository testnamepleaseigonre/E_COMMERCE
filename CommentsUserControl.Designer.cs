namespace GUI
{
    partial class CommentsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.Location = new System.Drawing.Point(12, 9);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(68, 23);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "label1";
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(12, 32);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(486, 37);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "asdasdasd";
            // 
            // userNameLabel
            // 
            this.userNameLabel.Location = new System.Drawing.Point(86, 9);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(106, 23);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "label1";
            // 
            // CommentsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.dateLabel);
            this.Name = "CommentsUserControl";
            this.Size = new System.Drawing.Size(545, 79);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Label userNameLabel;
    }
}
