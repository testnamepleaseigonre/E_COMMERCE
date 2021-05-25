using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_COMMERCE
{
    public partial class PasswordChangeForm : Form
    {
        public PasswordChangeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
                HomePage.LoggedInUser.SetPassword(textBox1.Text, textBox2.Text, HomePage.LoggedInUser.GetUserName());
                MessageBox.Show("Password succesfully changed!");
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
