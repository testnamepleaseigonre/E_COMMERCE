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

namespace GUI
{
    public partial class ItemAdminControl : ItemUserControl
    {
        private Item item;
        public ItemAdminControl(Item item, IUpdatable updatable): base(item, updatable)
        {
            InitializeComponent();
            this.item = item;
        }

        private void itemDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Do you really want to delete item [ {item.Title} ]?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    repository.deleteItem(item.Id);
                    MessageBox.Show("Item successfully deleted!");

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
    }
}
