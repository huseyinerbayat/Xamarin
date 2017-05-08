using PhoneBook.Helper;
using PhoneBook.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonDetailPage : ContentPage
    {
        SQLiteManager<Person> manager;
        Person _person;
        public PersonDetailPage(Person _person)
        {
            InitializeComponent();
            Title = "Kişi Düzenle";
            manager = new SQLiteManager<Person>();
            this._person = _person;
            GetInfo();
            _btnUpdate.Clicked += _btnUpdate_Clicked;
        }

        private void _btnUpdate_Clicked(object sender, EventArgs e)
        {
            SetInfo();
            int updated = manager.Update(_person);
            if (updated > 0)
            {
                DisplayAlert("Kişi Güncellendi", _person.Name + " " + _person.Surname + " kişisi güncellendi", "Tamam");
            }
            else
            {
                DisplayAlert("Kişi Güncellenemedi", "Güncelleme sırasında bir hata oluştu", "Tamam");
            }

        }
        private void SetInfo()
        {
            _person.Name = _txtName.Text;
            _person.Surname = _txtSurname.Text;
            _person.PhoneNumber = _txtPhoneNumber.Text;
        }
        private void GetInfo()
        {
            _txtName.Text = _person.Name;
            _txtSurname.Text = _person.Surname;
            _txtPhoneNumber.Text = _person.PhoneNumber;
        }
    }
}
