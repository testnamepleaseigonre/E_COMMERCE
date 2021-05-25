using System;
using System.Windows.Forms;
using E_COMMERCE.AllUsersData;

namespace E_COMMERCE
{
    public partial class RegisterWindow : Form
    {
        private UsersRepository repository = new UsersRepository();

        public RegisterWindow()
        {
            InitializeComponent();
            textBox3.Text = DateTime.Today.ToString("yyyy-MM-dd");
            //textBox1.Text = "ad";
            //textBox2.Text = "ad";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.TryParse(textBox3.Text, out DateTime check) == false)
                {
                    throw new Exception("Bad date format (YYYY-MM-DD)!");
                }
                if ((int)((DateTime.Now - DateTime.Parse(textBox3.Text)).TotalDays / 365) < 14)
                {
                    throw new Exception("14 years old is the minimum age for registering!");
                }
                User user = new User(" ", textBox1.Text, textBox2.Text, DateTime.Parse(textBox3.Text), userNameTextBox.Text, passwordTextBox.Text, "C:\\Users\\valde\\Desktop\\II Kursas\\OOP\\2\\GUI\\images\\user_default.png", "user");
                repository.Register(user);
                MessageBox.Show("Registration completed!");
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
