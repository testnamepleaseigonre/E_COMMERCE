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
    public partial class CommentAdminControl : CommentsUserControl
    {
        private Comment comment;
        private ItemsRepository repository = new ItemsRepository();
        public CommentAdminControl()
        {
            InitializeComponent();
        }
        public CommentAdminControl(Comment comment) : base(comment)
        {
            InitializeComponent();
            this.comment = comment;
        }

        private void deleteCommentButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Do you really want to delete this comment?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                try
                {
                    repository.deleteComment(comment.itemID, comment.userID);
                    MessageBox.Show("Comment successfully deleted!");
                    
                }
                catch(Exception exc)
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
