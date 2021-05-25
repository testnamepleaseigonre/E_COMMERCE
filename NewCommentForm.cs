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
    public partial class NewCommentForm : Form
    {
        private ItemsRepository repository = new ItemsRepository();
        private Item item;
        private LogWrite log;


        public NewCommentForm(Item item)
        {
            InitializeComponent();
            this.item = item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                repository.addNewComment(richTextBox1.Text, item.Id, int.Parse(HomePage.LoggedInUser.GetId()));
                repository.logAction(int.Parse(HomePage.LoggedInUser.GetId()), item.Id, "commented");
                repository.logActionTxt(int.Parse(HomePage.LoggedInUser.GetId()), item.Id, "commented");

                string info = "Added new comment:" + Environment.NewLine + "user_id: " + HomePage.LoggedInUser.GetId() + Environment.NewLine + "item_id: " + item.Id;
                log = new LogWrite(info);

                MessageBox.Show("Comment added successfully!");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
