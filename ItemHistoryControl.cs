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

namespace GUI
{
    public partial class ItemHistoryControl : ItemPublicControl
    {
        public ItemHistoryControl()
        {
            InitializeComponent();
        }

        public ItemHistoryControl(Item item, string date) : base(item)
        {
            InitializeComponent();
            label2.Text = DateTime.Parse(date).ToString("yyyy/MM/dd");
        }
    }
}
