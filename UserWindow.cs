using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI;

namespace E_COMMERCE
{
    public partial class UserWindow : Form
    {
        public UserWindow()
        {
            InitializeComponent();
            pictureBox.ImageLocation = HomePage.LoggedInUser.getImageLocation();
            if (HomePage.LoggedInUser.getUserType() == "admin")
            {
                manageUsersButton.Visible = true;
                addCategoryButton.Visible = true;
                addItemsButton.Visible = true;
            }
        }
        
        private void passwordChangeButton_Click(object sender, EventArgs e)
        {
            PasswordChangeForm pcf = new PasswordChangeForm();
            pcf.ShowDialog();
        }
        private void manageUsersButton_Click(object sender, EventArgs e)
        {
            UserManagerWindow umw = new UserManagerWindow();
            umw.ShowDialog();
        }

        private void AddProfilePictureButton_Click(object sender, EventArgs e)
        {
            try
            {
                HomePage.LoggedInUser.setImageLocation(HomePage.LoggedInUser.GetUserName());
                pictureBox.ImageLocation = HomePage.LoggedInUser.getImageLocation();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreMainWindow store = new StoreMainWindow();
            store.ShowDialog();
        }

        private void AddCategory_Click(object sender, EventArgs e)
        {
            AddCategory newCategory = new AddCategory();
            newCategory.Show();
        }

        private void wishlistButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserWishList wishList = new UserWishList();
                wishList.ShowDialog();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void addItemsButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewItemToShop addItems = new AddNewItemToShop();
                addItems.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserShoppingHistory hist = new UserShoppingHistory();
            hist.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserCartForm ucf = new UserCartForm();
            ucf.Show();
        }
    }
}
