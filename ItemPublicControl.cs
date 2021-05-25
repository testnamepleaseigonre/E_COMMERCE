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
    public partial class ItemPublicControl : UserControl
    {
        protected ItemsRepository repository = new ItemsRepository();
        
        public ItemPublicControl()
        {
            InitializeComponent();
        }

        public ItemPublicControl(Item item)
        {
            InitializeComponent();
            titleLabel.Text = item.Title;
            descriptionLabel.Text = item.Description;
            priceLabel.Text = item.Price.ToString();
            imageBox.Image = Image.FromFile("item_pics/" + item.Image);
        }
    }
}
