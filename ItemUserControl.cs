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
using GUI.Backend.Repositories;
using E_COMMERCE;

namespace GUI
{
    public partial class ItemUserControl : ItemPublicControl, IUpdatable
    {
        private Item item;
        private List<Comment> commentList;
        private double cartPrice = 0;
        private IUpdatable updatable;
        private LogWrite log;

        public ItemUserControl()
        {
            InitializeComponent();
        }

        public ItemUserControl(Item item, IUpdatable updatable): base(item)
        {
            InitializeComponent();
            this.item = item;
            this.updatable = updatable;
            commentList = repository.GetCommentList(item.Id);
            if(HomePage.LoggedInUser.getUserType() == "admin")
            {
                foreach (Comment comment in commentList)
                {
                    CommentAdminControl cuc = new CommentAdminControl(comment);
                    flowLayoutPanel1.Controls.Add(cuc);
                }
            }
            else
            {
                foreach (Comment comment in commentList)
                {
                    CommentsUserControl cuc = new CommentsUserControl(comment);
                    flowLayoutPanel1.Controls.Add(cuc);
                }
            }
            
        }

        private void addToWishlistButton_Click(object sender, EventArgs e)
        {
            try
            {
                repository.AddToWishlist(item.Id, int.Parse(HomePage.LoggedInUser.GetId()));
                repository.logAction(int.Parse(HomePage.LoggedInUser.GetId()), item.Id, "added_to_wishlist");
                repository.logActionTxt(int.Parse(HomePage.LoggedInUser.GetId()), item.Id, "commented");

                string info = "Added to wihslist:" + Environment.NewLine + "user_id: " + HomePage.LoggedInUser.GetId() + Environment.NewLine + "item_id: " + item.Id;
                log = new LogWrite(info);

                MessageBox.Show("Item successfully added to wishlist!");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void commentButton_Click(object sender, EventArgs e)
        {
            NewCommentForm ncf = new NewCommentForm(item);
            ncf.ShowDialog();
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
                    updatable.addItemsCount(item);
                    repository.addToCart(item.Id, int.Parse(HomePage.LoggedInUser.GetId()));
                    repository.logAction(int.Parse(HomePage.LoggedInUser.GetId()), item.Id, "added_to_cart");
                    repository.logActionTxt(int.Parse(HomePage.LoggedInUser.GetId()), item.Id, "commented");

                    string info = "Added to cart:" + Environment.NewLine + "user_id: " + HomePage.LoggedInUser.GetId() + Environment.NewLine + "item_id: " + item.Id;
                    log = new LogWrite(info);

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
