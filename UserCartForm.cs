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
    public partial class UserCartForm : Form, IUpdatable
    {
        private ItemsRepository repository = new ItemsRepository();
        private double cartPrice = 0;
        private List<CartItem> userCartItems;
        private Promotion promotion = null;

        public UserCartForm()
        {
            InitializeComponent();
            userCartItems = repository.getUserCart(HomePage.LoggedInUser.GetId());
            try
            {
                foreach (CartItem item in userCartItems)
                {
                    CartItemControl cuc = new CartItemControl(repository.getItemByID(item.itemID), this);
                    flowLayoutPanel1.Controls.Add(cuc);
                    cartPrice += repository.getItemByID(item.itemID).Price;
                }
                if(flowLayoutPanel1.Controls.Count == 0)
                {
                    label3.Text = "Cart is empty!";
                }
                label2.Text = cartPrice.ToString();
            }
            catch
            {
                MessageBox.Show("Eror!");
            }
            try
            {
                promotion = repository.getPromotion(int.Parse(HomePage.LoggedInUser.GetId()));
                if (promotion != null)
                {
                    if (promotion.active == "no")
                    {
                        DateTime usd = DateTime.Parse(promotion.use_date);
                        if (usd.Year != DateTime.Today.Year)
                        {
                            DateTime birthDate = DateTime.Parse(HomePage.LoggedInUser.GetBirthDate());
                            DateTime today = DateTime.Today;
                            DateTime nextBirthday = birthDate.AddYears(DateTime.Today.Year - birthDate.Year);
                            if (nextBirthday < DateTime.Today)
                                nextBirthday = nextBirthday.AddYears(1);
                            int daysleft = (nextBirthday - DateTime.Today).Days;
                            if (daysleft > 357)
                                daysleft = daysleft - 365;
                            if(daysleft <= 7 && daysleft >= -7)
                            {
                                repository.changeOfferActive(promotion.Id);
                                promotion = repository.getPromotion(int.Parse(HomePage.LoggedInUser.GetId()));
                            }
                        }
                    }
                    if (promotion.active == "yes")
                    {
                        label4.Text = promotion.title;
                    }
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                MessageBox.Show("Cart is empty. Add something to buy!");
            }
            else
            {
                double total_price = totalPrice();
                DialogResult result = MessageBox.Show($"Are you sure you want to buy everything form you cart? Price with available promotions: {Math.Round(total_price, 2)}", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        foreach(CartItem item in userCartItems)
                        {
                            repository.removeFromCart(item.itemID, int.Parse(HomePage.LoggedInUser.GetId()));
                            repository.addPurchasesToSql(item.itemID, int.Parse(HomePage.LoggedInUser.GetId()));
                            flowLayoutPanel1.Controls.Clear();
                            label3.Text = "Cart is empty!";
                            label4.Text = "";
                            if (promotion.active == "yes")
                            {
                                repository.deactivatePromotion(promotion.Id);
                            }
                        }
                        MessageBox.Show("Items successfully purchased!");
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }
            }
        }
        private double totalPrice()
        {
            if(promotion.active == "yes")
            {
                return (cartPrice * (1 - (double.Parse(promotion.value.ToString()) / 100)));
            }
            else
            {
                return cartPrice;
            }
        }

        public void downItemsCount(int itemID)
        {
            int i = 0;
            CartItem delete = null;
            foreach(CartItem item in userCartItems)
            {
                if (item.itemID == itemID)
                {
                    flowLayoutPanel1.Controls.RemoveAt(i);
                    delete = item;
                    break;
                }
                i++;
            }
            userCartItems.Remove(delete);
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                label3.Text = "Cart is empty!";
            }
            else
            {
                label3.Text = "";
            }
            refreshCartPrice();
        }

        private void refreshCartPrice()
        {
            cartPrice = 0;
            if(flowLayoutPanel1.Controls.Count != 0)
            {
                foreach (CartItem item in userCartItems)
                {
                    cartPrice += repository.getItemByID(item.itemID).Price;
                }
            }
            label2.Text = cartPrice.ToString();
        }

        public void addItemsCount(Item item)
        {
           //userCartItems.Add(new CartItem(0, item.Id));
           //CartItemControl cuc = new CartItemControl(repository.getItemByID(item.Id), this);
           //flowLayoutPanel1.Controls.Add(cuc);
           //refreshCartPrice();
        }
    }
}
