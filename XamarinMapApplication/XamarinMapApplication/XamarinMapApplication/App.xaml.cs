
using Xamarin.Forms;
using XamarinMapApplication.Views;

namespace XamarinMapApplication
{
    public partial class App : Application
    {

        // Picker ile Map'ten konum seçiminin senkronize çalışması örneği
        // Erbayat.Com
        // Hüseyin Erbayat
        // huseyin@erbayat.com

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new LocationPickerPage());
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
