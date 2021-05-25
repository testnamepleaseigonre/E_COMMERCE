using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Backend.Models
{
    public class Item
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public double Price { get; private set; }

        public Item(int id, string title, string description, string image, double price)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Price = price;
        }
    }
}
