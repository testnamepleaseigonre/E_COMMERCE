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
    public partial class UserShoppingHistory : Form
    {
        private ItemsRepository repository = new ItemsRepository();

        public UserShoppingHistory()
        {
            InitializeComponent();
            try
            {
                foreach (PaymentsLogItem item in repository.getUserBuyHistory(HomePage.LoggedInUser.GetId()))
                {
                    ItemHistoryControl cuc = new ItemHistoryControl(repository.getItemByID(item.itemID), item.date);
                    flowLayoutPanel1.Controls.Add(cuc);
                }
            }
            catch
            {
                MessageBox.Show("Log empty!");
            }
        }
    }
}
