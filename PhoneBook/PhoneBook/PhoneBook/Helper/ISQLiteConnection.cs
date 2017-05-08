using SQLite.Net;

namespace PhoneBook.Helper
{
    public interface ISQLiteConnection
    {
        SQLiteConnection GetConnection();
    }
}
