namespace GUI
{
    partial class ItemAdminControl
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
            this.itemDeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(316, 37);
            // 
            // itemDeleteButton
            // 
            this.itemDeleteButton.Location = new System.Drawing.Point(486, 3);
            this.itemDeleteButton.Name = "itemDeleteButton";
            this.itemDeleteButton.Size = new System.Drawing.Size(68, 23);
            this.itemDeleteButton.TabIndex = 7;
            this.itemDeleteButton.Text = "Delete item";
            this.itemDeleteButton.UseVisualStyleBackColor = true;
            this.itemDeleteButton.Click += new System.EventHandler(this.itemDeleteButton_Click);
            // 
            // ItemAdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemDeleteButton);
            this.Name = "ItemAdminControl";
            this.Controls.SetChildIndex(this.imageBox, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.descriptionLabel, 0);
            this.Controls.SetChildIndex(this.priceTextLabel, 0);
            this.Controls.SetChildIndex(this.priceLabel, 0);
            this.Controls.SetChildIndex(this.itemDeleteButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button itemDeleteButton;
    }
}
