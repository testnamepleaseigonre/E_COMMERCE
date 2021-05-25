using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace E_COMMERCE
{
    public class Person 
    {
        protected string Name;
        protected string Surname;
        protected DateTime BirthDate; 

        public Person(string name, string surname, DateTime birthDate)
        {
            DataValidation(name, surname, birthDate.ToString());
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public int GetAge()
        {
            return (int)((DateTime.Now - BirthDate).TotalDays / 365);
        }

        public int DaysUntilBirthday()
        {
            DateTime temp = new DateTime(DateTime.Today.Year, BirthDate.Month, BirthDate.Day);

            if (temp < DateTime.Today)
                temp = temp.AddYears(1);

            int days = (temp - DateTime.Today).Days;
            return (int)(days);
        }

        public string GetName()
        {
            return Name;
        }

        public string GetSurname()
        {
            return Surname;
        }

        public string GetBirthDate()
        {
            return BirthDate.ToString("yyyy/MM/dd");
        }

        public void DataValidation(string name, string surname, string date)
        {
            if (name == "" || name == null)
            {
                throw new Exception("Name field empty!");
            }
            if (surname == "" || surname == null)
            {
                throw new Exception("Surname field empty!");
            }
            if (date == "" || date == null)
            {
                throw new Exception("Date field empty!");
            }
            if (DateTime.Parse(date) > DateTime.Now)
            {
                throw new Exception("Bad date format (YYYY-MM-DD)!!");
            }
        }
    }
}
