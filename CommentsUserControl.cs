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
using E_COMMERCE.AllUsersData;

namespace GUI
{
    public partial class CommentsUserControl : UserControl
    {
        UsersRepository repository = new UsersRepository();
        public CommentsUserControl()
        {
            InitializeComponent();
        }
        public CommentsUserControl(Comment comment)
        {
            InitializeComponent();
            userNameLabel.Text = repository.getUsernameByUserId(comment.userID);
            textLabel.Text = comment.text;
            dateLabel.Text = DateTime.Parse(comment.date).ToString("yyyy-MM-dd");
        }
    }
}
