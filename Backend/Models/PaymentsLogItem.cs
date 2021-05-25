using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Backend.Models
{
    public class PaymentsLogItem
    {
        public int Id { get; private set; }
        public string date { get; private set; }
        public int userID { get; private set; }
        public int itemID { get; private set; }

        public PaymentsLogItem(int id, string date, int userID, int itemID)
        {
            this.Id = id;
            this.date = date;
            this.userID = userID;
            this.itemID = itemID;
        }
    }
}
