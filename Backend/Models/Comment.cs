using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Backend.Models
{
    public class Comment
    {
        public string date { get; private set; }
        public string text { get; private set; }
        public int itemID { get; private set; }
        public int userID { get; private set; }
        public Comment(string date, string text, int itemID, int userID)
        {
            this.date = date;
            this.text = text;
            this.userID = userID;
            this.itemID = itemID;
        }
    }
}
