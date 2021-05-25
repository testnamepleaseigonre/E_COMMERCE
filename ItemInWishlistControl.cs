using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Backend.Models;
using E_COMMERCE;

namespace GUI
{
    public partial class ItemInWishlistControl : ItemPublicControl, IUpdatable
    {
        private Item item;
        private double cartPrice;
        public ItemInWishlistControl(Item item) : base(item)
        {
            InitializeComponent();
            this.item = item;
        }

        private void removeFWButton_Click(object sender, EventArgs e)
        {
            try
            {
                repository.RemoveFromWishlist(item.Id, int.Parse(HomePage.LoggedInUser.GetId()));
                MessageBox.Show("Item successfully removed from wishlist!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CartItem item in repository.getUserCart(HomePage.LoggedInUser.GetId()))
                {
                    CartItemControl cuc = new CartItemControl(repository.getItemByID(item.itemID), this);
                    cartPrice += repository.getItemByID(item.itemID).Price;
                }
            }
            catch
            {

            }
            DialogResult result = MessageBox.Show($"Do you really want to add [ {item.Title} ] to your cart? Currrent cart price: {cartPrice}", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    repository.addToCart(item.Id, int.Parse(HomePage.LoggedInUser.GetId()));
                    MessageBox.Show("Item successfully added!");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {

            }
        }
        public void downItemsCount(int itemID)
        {

        }

        public void addItemsCount(Item item)
        {

        }
    }
}
