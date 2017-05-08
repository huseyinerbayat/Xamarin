using SQLite.Net.Attributes;

namespace PhoneBook.Model
{
    public class Person
    {

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
