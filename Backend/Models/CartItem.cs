using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Backend.Models
{
    public class CartItem
    {
        public int Id { get; private set; }
        public int itemID { get; private set; }

        public CartItem(int id, int itemID)
        {
            Id = id;
            this.itemID = itemID;
        }
    }
}
