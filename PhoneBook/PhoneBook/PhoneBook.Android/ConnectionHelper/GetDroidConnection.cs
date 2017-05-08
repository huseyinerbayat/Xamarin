using PhoneBook.Droid.ConnectionHelper;
using PhoneBook.Helper;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Xamarin.Forms.Dependency(typeof(GetDroidConnection))]
namespace PhoneBook.Droid.ConnectionHelper
{
    public class GetDroidConnection : ISQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentPath, App.DbName);
            var platform = new SQLitePlatformAndroid();

            var connection = new SQLiteConnection(platform, path);


            return connection;
        }
    }
}