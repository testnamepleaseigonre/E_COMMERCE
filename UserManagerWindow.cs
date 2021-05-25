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
    public partial class UserManagerWindow : Form
    {
        private UsersRepository repository = new UsersRepository();

        public UserManagerWindow()
        {
            InitializeComponent();
        }

        private void UserManagerWindow_Load(object sender, EventArgs e)
        {
            foreach (User user in repository.GetUsersList())
            {
                dataGridView1.Rows.Add(user.GetId(), user.GetUserName(), user.GetPassword(), user.GetName(), user.GetSurname(), user.GetBirthDate(), user.getUserType(), user.getImageLocation());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                try
                {
                    string username = dataGridView1.Rows[item.Index].Cells["username"].Value.ToString();
                    repository.removeUser(username);
                    dataGridView1.Rows.RemoveAt(item.Index);
                    MessageBox.Show("User successfully deleted!");
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
