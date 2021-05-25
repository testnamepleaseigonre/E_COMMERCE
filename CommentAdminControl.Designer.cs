namespace GUI
{
    partial class CommentAdminControl
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
            this.deleteCommentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deleteCommentButton
            // 
            this.deleteCommentButton.Location = new System.Drawing.Point(514, 4);
            this.deleteCommentButton.Name = "deleteCommentButton";
            this.deleteCommentButton.Size = new System.Drawing.Size(26, 23);
            this.deleteCommentButton.TabIndex = 3;
            this.deleteCommentButton.Text = "X";
            this.deleteCommentButton.UseVisualStyleBackColor = true;
            this.deleteCommentButton.Click += new System.EventHandler(this.deleteCommentButton_Click);
            // 
            // CommentAdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteCommentButton);
            this.Name = "CommentAdminControl";
            this.Controls.SetChildIndex(this.deleteCommentButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deleteCommentButton;
    }
}
