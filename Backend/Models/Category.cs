using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Backend.Models
{
    public class Category
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public List<Item> Items { get; private set; }

        public Category(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public void SetItems(List<Item> items)
        {
            Items = items;
        }
    }
}
