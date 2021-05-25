using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Backend.Models
{
    public class WishList
    {
        public List<Item> Items { get; private set; }

        public WishList()
        {
            
        }

        public void SetItems(List<Item> items)
        {
            Items = items;
        }
    }
}
