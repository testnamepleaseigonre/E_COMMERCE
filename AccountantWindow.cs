using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Backend.Models;
using GUI.Backend.Repositories;
using Newtonsoft.Json;

namespace GUI
{
    public partial class AccountantWindow : Form
    {
        private ItemsRepository repository = new ItemsRepository();
        private List<PaymentsLogItem> logList = new List<PaymentsLogItem>();

        public AccountantWindow()
        {
            InitializeComponent();
            try
            {
                foreach (PaymentsLogItem item in repository.getPaymentsList())
                {
                    LogItemAccountantControl cuc = new LogItemAccountantControl(repository.getItemByID(item.itemID), item.date, item.userID);
                    flowLayoutPanel1.Controls.Add(cuc);
                    logList.Add(new PaymentsLogItem(item.Id, item.date, item.userID, item.itemID));
                }
            }
            catch
            {
                MessageBox.Show("Log empty!");
            }       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(logList.Count != 0)
            {
                string items = JsonConvert.SerializeObject(logList);
                Console.WriteLine(items);
                File.WriteAllText(@"shopping_history.json", items);
                MessageBox.Show("Successfully exported to JSON!");
            }
            else
            {
                MessageBox.Show("Nothing to export!");
            }
        }
    }
}
