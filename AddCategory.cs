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

namespace GUI
{
    public partial class AddCategory : Form
    {
        private ItemsRepository repository = new ItemsRepository();
        public AddCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(categoryTitle.Text.ToString() != "" && categoryTitle.Text.ToString() != null)
                {
                    repository.AddNewCategory(categoryTitle.Text.ToString());
                    MessageBox.Show("Category added succesfully!");
                }
                else
                {
                    throw new Exception("Field empty!");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
