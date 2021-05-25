using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E_COMMERCE.AllUsersData;
using GUI;

namespace E_COMMERCE
{
    public partial class HomePage : Form
    {
        public static User LoggedInUser = new User(" ", " ", " ", DateTime.Now, " ", "  ", " ", "anonymous");

        public HomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.ShowDialog();
            if(LoggedInUser.getUserType() == "acc")
            {
                AccountantWindow aw = new AccountantWindow();
                aw.ShowDialog();
                LoggedInUser.setUserType("anonymous");
            }
            else if (LoggedInUser.getUserType() != "anonymous")
            {
                UserWindow uw = new UserWindow();
                uw.ShowDialog();
                LoggedInUser.setUserType("anonymous"); //MAB
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StoreMainWindow store = new StoreMainWindow();
            store.ShowDialog();
        }
    }
}
