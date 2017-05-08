using PhoneBook.Model;
using SQLite.Net;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PhoneBook.Helper
{
    public class SQLiteManager<T>
    {
        SQLiteConnection _sqlconnection;
        public SQLiteManager()
        {
            _sqlconnection = DependencyService.Get<ISQLiteConnection>().GetConnection();
            _sqlconnection.CreateTable<T>();

        }
        public int Insert(T person)
        {
            return _sqlconnection.Insert(person);
        }

        public int Update(T person)
        {
            return _sqlconnection.Update(person);
        }
        public IEnumerable<Person> GetAll()
        {
            return  _sqlconnection.Table<Person>();
        }

        public IEnumerable<Person> Search(string word)
        {
            return (from person in _sqlconnection.Table<Person>()
                   where
                        person.Name.Contains(word) ||
                        person.Surname.Contains(word) ||
                        person.PhoneNumber.Contains(word)
                   select person);
        }
    }
    
}
