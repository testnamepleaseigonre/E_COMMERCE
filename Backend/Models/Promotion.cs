using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Backend.Models
{
    public class Promotion
    {
        public int Id { get; private set; }
        public string title { get; private set; }
        public string active { get; private set; }
        public string use_date { get; private set; }
        public int userID { get; private set; }
        public int value { get; private set; }

        public Promotion(int id, string title, string active, string use_date, int userID, int value)
        {
            Id = id;
            this.title = title;
            this.active = active;
            this.use_date = use_date;
            this.userID = userID;
            this.value = value;
        }
    }
}
