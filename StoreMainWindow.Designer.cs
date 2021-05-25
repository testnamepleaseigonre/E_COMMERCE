namespace GUI
{
    partial class StoreMainWindow
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
            this.SideMenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // SideMenuPanel
            // 
            this.SideMenuPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.SideMenuPanel.Location = new System.Drawing.Point(12, 25);
            this.SideMenuPanel.Name = "SideMenuPanel";
            this.SideMenuPanel.Size = new System.Drawing.Size(200, 435);
            this.SideMenuPanel.TabIndex = 0;
            this.SideMenuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SideMenuPanel_Paint);
            // 
            // contentPanel
            // 
            this.contentPanel.AutoScroll = true;
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.Location = new System.Drawing.Point(237, 25);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(586, 435);
            this.contentPanel.TabIndex = 1;
            // 
            // StoreMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 485);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.SideMenuPanel);
            this.Name = "StoreMainWindow";
            this.Text = "StoreMainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel SideMenuPanel;
        private System.Windows.Forms.FlowLayoutPanel contentPanel;
    }
}