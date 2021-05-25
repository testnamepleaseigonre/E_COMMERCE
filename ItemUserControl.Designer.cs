namespace GUI
{
    partial class ItemUserControl
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
            this.addToWishlistButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.commentButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(346, 37);
            // 
            // addToWishlistButton
            // 
            this.addToWishlistButton.Location = new System.Drawing.Point(342, 118);
            this.addToWishlistButton.Name = "addToWishlistButton";
            this.addToWishlistButton.Size = new System.Drawing.Size(84, 23);
            this.addToWishlistButton.TabIndex = 5;
            this.addToWishlistButton.Text = "Add to wishlist";
            this.addToWishlistButton.UseVisualStyleBackColor = true;
            this.addToWishlistButton.Click += new System.EventHandler(this.addToWishlistButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 170);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(551, 185);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // commentButton
            // 
            this.commentButton.Location = new System.Drawing.Point(252, 118);
            this.commentButton.Name = "commentButton";
            this.commentButton.Size = new System.Drawing.Size(84, 23);
            this.commentButton.TabIndex = 8;
            this.commentButton.Text = "Comment";
            this.commentButton.UseVisualStyleBackColor = true;
            this.commentButton.Click += new System.EventHandler(this.commentButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Add to cart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.commentButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.addToWishlistButton);
            this.Name = "ItemUserControl";
            this.Size = new System.Drawing.Size(557, 358);
            this.Controls.SetChildIndex(this.imageBox, 0);
            this.Controls.SetChildIndex(this.titleLabel, 0);
            this.Controls.SetChildIndex(this.descriptionLabel, 0);
            this.Controls.SetChildIndex(this.priceTextLabel, 0);
            this.Controls.SetChildIndex(this.priceLabel, 0);
            this.Controls.SetChildIndex(this.addToWishlistButton, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.commentButton, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addToWishlistButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button commentButton;
        private System.Windows.Forms.Button button1;
    }
}
