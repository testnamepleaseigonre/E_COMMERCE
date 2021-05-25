namespace E_COMMERCE
{
    partial class UserWindow
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
            this.passwordChangeButton = new System.Windows.Forms.Button();
            this.AddProfilePictureButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.manageUsersButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.wishlistButton = new System.Windows.Forms.Button();
            this.addItemsButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordChangeButton
            // 
            this.passwordChangeButton.Location = new System.Drawing.Point(254, 29);
            this.passwordChangeButton.Name = "passwordChangeButton";
            this.passwordChangeButton.Size = new System.Drawing.Size(126, 48);
            this.passwordChangeButton.TabIndex = 0;
            this.passwordChangeButton.Text = "Change password";
            this.passwordChangeButton.UseVisualStyleBackColor = true;
            this.passwordChangeButton.Click += new System.EventHandler(this.passwordChangeButton_Click);
            // 
            // AddProfilePictureButton
            // 
            this.AddProfilePictureButton.Location = new System.Drawing.Point(386, 29);
            this.AddProfilePictureButton.Name = "AddProfilePictureButton";
            this.AddProfilePictureButton.Size = new System.Drawing.Size(126, 48);
            this.AddProfilePictureButton.TabIndex = 1;
            this.AddProfilePictureButton.Text = "Change profile picture";
            this.AddProfilePictureButton.UseVisualStyleBackColor = true;
            this.AddProfilePictureButton.Click += new System.EventHandler(this.AddProfilePictureButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(33, 29);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(176, 155);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // manageUsersButton
            // 
            this.manageUsersButton.Location = new System.Drawing.Point(386, 245);
            this.manageUsersButton.Name = "manageUsersButton";
            this.manageUsersButton.Size = new System.Drawing.Size(126, 48);
            this.manageUsersButton.TabIndex = 3;
            this.manageUsersButton.Text = "Manage Users";
            this.manageUsersButton.UseVisualStyleBackColor = true;
            this.manageUsersButton.Visible = false;
            this.manageUsersButton.Click += new System.EventHandler(this.manageUsersButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "View products";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.Location = new System.Drawing.Point(254, 191);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(126, 48);
            this.addCategoryButton.TabIndex = 5;
            this.addCategoryButton.Text = "Add new categories";
            this.addCategoryButton.UseVisualStyleBackColor = true;
            this.addCategoryButton.Visible = false;
            this.addCategoryButton.Click += new System.EventHandler(this.AddCategory_Click);
            // 
            // wishlistButton
            // 
            this.wishlistButton.Location = new System.Drawing.Point(386, 83);
            this.wishlistButton.Name = "wishlistButton";
            this.wishlistButton.Size = new System.Drawing.Size(126, 48);
            this.wishlistButton.TabIndex = 6;
            this.wishlistButton.Text = "WishList";
            this.wishlistButton.UseVisualStyleBackColor = true;
            this.wishlistButton.Click += new System.EventHandler(this.wishlistButton_Click);
            // 
            // addItemsButton
            // 
            this.addItemsButton.Location = new System.Drawing.Point(386, 191);
            this.addItemsButton.Name = "addItemsButton";
            this.addItemsButton.Size = new System.Drawing.Size(126, 48);
            this.addItemsButton.TabIndex = 7;
            this.addItemsButton.Text = "Add new items to shop";
            this.addItemsButton.UseVisualStyleBackColor = true;
            this.addItemsButton.Visible = false;
            this.addItemsButton.Click += new System.EventHandler(this.addItemsButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 137);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 48);
            this.button2.TabIndex = 8;
            this.button2.Text = "My cart";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(386, 137);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 48);
            this.button3.TabIndex = 9;
            this.button3.Text = "Shopping history";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // UserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 317);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.addItemsButton);
            this.Controls.Add(this.wishlistButton);
            this.Controls.Add(this.addCategoryButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.manageUsersButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.AddProfilePictureButton);
            this.Controls.Add(this.passwordChangeButton);
            this.Name = "UserWindow";
            this.Text = "UserWindow";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button passwordChangeButton;
        private System.Windows.Forms.Button AddProfilePictureButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button manageUsersButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.Button wishlistButton;
        private System.Windows.Forms.Button addItemsButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}