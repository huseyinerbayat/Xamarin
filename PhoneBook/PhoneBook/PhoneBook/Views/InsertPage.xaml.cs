
using PhoneBook.Helper;
using PhoneBook.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertPage : ContentPage
    {
        SQLiteManager<Person> manager;
        public InsertPage()
        {
            InitializeComponent();
            Title = "Kişi Ekle";
            _btnInsert.Clicked += _btnInsert_Clicked;
            manager = new SQLiteManager<Person>();
            
        }

        private void _btnInsert_Clicked(object sender, System.EventArgs e)
        {
            Person _person = new Person
            {
                Name = _txtName.Text,
                Surname = _txtSurname.Text,
                PhoneNumber = _txtPhoneNumber.Text
            };

            int isInserted =  manager.Insert(_person);

            if(isInserted > 0)
            {
                DisplayAlert("Kişi eklendi",_person.Name + " " + _person.Surname + " rehbere ekledi","Tamam");
                _txtName.Text ="";
                _txtSurname.Text = "";
                _txtPhoneNumber.Text = "";
            }
            else
            {
                DisplayAlert("Kişi eklenemedi", "Ekleme işlemi yapılırken bir hata oluştu", "Tamam");
            }

        }
    }
}
