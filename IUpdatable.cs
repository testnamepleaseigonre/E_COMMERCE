using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Backend.Models;

namespace GUI
{
    public interface IUpdatable
    {
        void downItemsCount(int itemID);

        void addItemsCount(Item item);
    }
}
