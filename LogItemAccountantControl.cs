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
using GUI.Backend.Repositories;
using E_COMMERCE.AllUsersData;

namespace GUI
{
    public partial class LogItemAccountantControl : ItemPublicControl
    {
        private UsersRepository userRep = new UsersRepository();

        public LogItemAccountantControl()
        {
            InitializeComponent();
        }

        public LogItemAccountantControl(Item item, string date, int userID) : base(item)
        {
            InitializeComponent();
            label3.Text = DateTime.Parse(date).ToString("yyyy/MM/dd");
            label4.Text = userRep.getUsernameByUserId(userID) + " " + userID;
        }
    }
}
