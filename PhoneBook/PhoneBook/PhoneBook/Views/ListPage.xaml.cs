using PhoneBook.Helper;
using PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        SQLiteManager<Person> manager;
        List<Person> persons;
        public ListPage()
        {
            InitializeComponent();
            Title = "Telefon Rehberi";
            _searchBarBook.TextChanged += _searchBarBook_TextChanged;
            _addPerson.Clicked += _addPerson_Clicked;
            _lstPersons.ItemTapped += _lstPersons_ItemTapped;
            manager = new SQLiteManager<Person>();
            persons = new List<Person>();
           
            
        }

        private void _lstPersons_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListView _lst = (ListView)sender;
            _lst.SelectedItem = null;
            Person _person = (Person)e.Item;
            Navigation.PushAsync(new PersonDetailPage(_person));
        }
        

        private async void _addPerson_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertPage());
        }

        protected override void OnAppearing()
        {
            GetPersons();
        }
        

        private void _searchBarBook_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue) || e.NewTextValue.Trim()!="")
                _lstPersons.ItemsSource = manager.Search(e.NewTextValue);
            else if (String.IsNullOrEmpty(e.NewTextValue))
            {
                GetPersons();
                _lstPersons.ItemsSource = persons;
            }
        }
        
        private void GetPersons()
        {
            persons =   manager.GetAll().ToList();
            SortingByName();
            _lstPersons.ItemsSource = persons;
        }
        private void SortingByName()
        {
            int _personCount = persons.Count;
            for (int i = 0; i < _personCount; i++)
            {
                for (int j = 0; j < _personCount - 1; j++)
                {
                    if (persons[j].Name.CompareTo(persons[j + 1].Name) == 1)
                    {
                        Person temp = persons[j];
                        persons[j] = persons[j + 1];
                        persons[j + 1] = temp;
                    }
                }
            }
        }
    }
}
