using PhoneBook.Views;
using Xamarin.Forms;

namespace PhoneBook
{
    public partial class App : Application
    {
        public static string DbName = "PhoneBook.db3";
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage( new ListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
