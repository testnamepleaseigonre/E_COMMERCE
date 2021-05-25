using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Backend.Models;
using GUI.Backend.Repositories;
using E_COMMERCE;

namespace GUI
{
    public partial class StoreMainWindow : Form, IUpdatable
    {
        private ItemsRepository repository;

        public StoreMainWindow()
        {
            InitializeComponent();
            repository = new ItemsRepository();
            List<Category> categoriesList = repository.GetCategories();
            foreach (Category category in categoriesList)
            {
                Button categoryButton = new Button();
                categoryButton.Text = category.Title;
                categoryButton.Tag = category;
                categoryButton.Click += CategoryButton_Click;
                categoryButton.Width = SideMenuPanel.Width - 5;
                SideMenuPanel.Controls.Add(categoryButton);
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();

            Button button = (Button)sender;
            Category category = (Category)button.Tag;
            
            if (HomePage.LoggedInUser.getUserType() == "admin")
            {
                foreach (Item item in category.Items)
                {
                    ItemAdminControl iac = new ItemAdminControl(item, this);
                    contentPanel.Controls.Add(iac);
                }
            }
            else if (HomePage.LoggedInUser.getUserType() == "user")
            {
                foreach (Item item in category.Items)
                {
                    ItemUserControl iuc = new ItemUserControl(item, this);
                    contentPanel.Controls.Add(iuc);
                }
            }
            else if (HomePage.LoggedInUser.getUserType() == "anonymous")
            {
                foreach (Item item in category.Items)
                {
                    ItemPublicControl ipc = new ItemPublicControl(item);
                    contentPanel.Controls.Add(ipc);
                }
            }
            else
            {
                MessageBox.Show("Error! Please try again later.");
            }
        }

        public void downItemsCount(int itemID)
        {

        }

        public void addItemsCount(Item item)
        {

        }

        private void SideMenuPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
