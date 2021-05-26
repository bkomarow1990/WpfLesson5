using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Wpf_Lessn5_Classwork
{
    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;

        public string Name
        {
            get { return name; }
            set { 
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Info)));
            }
        }
        private string surname;

        public string Surname
        {
            get { return surname; }
            set { 
                surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Info)));
            }
            
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { 
                phone = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Info))); 
            }
        }
        private string country;


        public string Country
        {
            get { return country; }
            set { 
                country = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Info)));
            }
        }
        public string Info => $"Name: {Name}, Surname: {Surname}, Phone: {Phone}, Country: {Country}";
        public Person(string name, string surname, string phone, string country)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Country = country;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Phone: {Phone}, Country: {Country}";
        }


    }
}
