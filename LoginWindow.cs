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

namespace E_COMMERCE
{
    public partial class LoginWindow : Form
    {
        private UsersRepository repository = new UsersRepository();

        public LoginWindow()
        {
            InitializeComponent();
            textBox1.Text = "rex";
            textBox2.Text = "rex";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HomePage.LoggedInUser = repository.Login(textBox1.Text, textBox2.Text);
                this.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
