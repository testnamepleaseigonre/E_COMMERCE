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

namespace GUI
{
    public partial class AddNewItemToShop : Form
    {
        private ItemsRepository repository = new ItemsRepository();
        private List<Category> categoriesList;

        public AddNewItemToShop()
        {
            InitializeComponent();
            categoriesList = repository.GetCategories();
            foreach (Category category in categoriesList)
            {
                comboBox1.Items.Add(category.Title);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryid = 0;
                foreach (Category category in categoriesList)
                {
                    if(category.Title == comboBox1.Text)
                    {
                        categoryid = category.Id;
                    }
                }
                if (okButton.Tag != null)
                {
                    repository.addNewItem(titleTextBox.Text, priceTextBox.Text, richTextBox1.Text, categoryid, okButton.Tag.ToString());
                    MessageBox.Show("Item added successfully!"); 
                    titleTextBox.Text = "";
                    priceTextBox.Text = "";
                    richTextBox1.Text = "";
                    comboBox1.SelectedIndex = 0;
                    categoryid = 0;
                    okButton.Tag = null;
                }
                else
                {
                    MessageBox.Show("Please choose an image!");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "All files(*.*)|*.*| jpg files(*.jpg)|*.jpg| png files(*.png)|*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.Copy(dialog.FileName, "item_pics/" + dialog.SafeFileName);
                        okButton.Tag = dialog.SafeFileName;
                    }
                    catch
                    {
                        okButton.Tag = dialog.SafeFileName;
                    }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
