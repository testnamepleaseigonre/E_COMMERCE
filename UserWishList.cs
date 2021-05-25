using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Backend.Repositories;
using GUI.Backend.Models;
using E_COMMERCE;

namespace GUI
{
    public partial class UserWishList : Form
    {
        private ItemsRepository repository = new ItemsRepository();

        public UserWishList()
        {
            InitializeComponent();
            contentPanel.Controls.Clear();
            WishList wishList = repository.GetWishList(int.Parse(HomePage.LoggedInUser.GetId()));
            if (wishList.Items != null)
            {
                foreach (Item item in wishList.Items)
                {
                    ItemInWishlistControl iuc = new ItemInWishlistControl(item);
                    contentPanel.Controls.Add(iuc);
                }
            }
            else
            {
                throw new Exception("Wishlist empty!");
            }
        }
    }
}
