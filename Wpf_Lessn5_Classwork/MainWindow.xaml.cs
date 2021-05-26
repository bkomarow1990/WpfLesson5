using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Wpf_Lessn5_Classwork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool EditMode = false;
        Person selectedForEdit;
        ObservableCollection<Person> group = new ObservableCollection<Person> { new Person("Anatoliy","Rambo","+380972219321","Ukraine")}; 
        private void InitControls()
        {
            elemsListBox.Items.Clear();
            elemsListBox.ItemsSource = group;
            elemsListBox.DisplayMemberPath = nameof(Person.Info);
        }
        public MainWindow()
        {
            InitializeComponent();
            InitControls();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(nameTxtBox.Text) || String.IsNullOrEmpty(surnameTxtBox.Text) || String.IsNullOrEmpty(phoneTxtBox.Text) || countryComboBox.SelectedItem == null)
            {
                return;
            }
            group.Add(new Person(nameTxtBox.Text, surnameTxtBox.Text, phoneTxtBox.Text, countryComboBox.Text));
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = elemsListBox.SelectedItem as Person;
            if (selected == null)
            {
                return;
            }
            group.Remove(selected);
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = elemsListBox.SelectedItem as Person;
            if (selected == null)
            {
                return;
            }
            nameTxtBox.Text = selected.Name;
            surnameTxtBox.Text = selected.Surname;
            phoneTxtBox.Text = selected.Phone;
            countryComboBox.Text = selected.Country;
            selectedForEdit = selected;
            if (EditMode)
            {
                //editBtn.ClickMode = ClickMode.Press;
                EditMode = false;
            }
            else
            {
                EditMode = true;

            }
            
        }

        private void surnameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (EditMode)
            {
                selectedForEdit.Surname = surnameTxtBox.Text; 
            }
        }

        private void phoneTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EditMode)
            {
                selectedForEdit.Phone = phoneTxtBox.Text;
            }
        }

        private void countryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EditMode)
            {
                selectedForEdit.Country = countryComboBox.Text;
            }
        }

        private void nameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EditMode)
            {
                selectedForEdit.Name = nameTxtBox.Text;
            }
        }

        private void elemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
