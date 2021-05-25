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
    public partial class CartItemControl : ItemPublicControl
    {
        Item item;
        private IUpdatable updatable;

        public CartItemControl()
        {
            InitializeComponent();
        }

        public CartItemControl(Item item, IUpdatable updatable) :base(item)
        {
            InitializeComponent();
            this.item = item;
            this.updatable = updatable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Do you really want to remove item [ {item.Title} ] from your cart?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    repository.removeFromCart(item.Id, int.Parse(HomePage.LoggedInUser.GetId()));
                    updatable.downItemsCount(item.Id);
                    MessageBox.Show("Item successfully removed!");
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
    }
}
