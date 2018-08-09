using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebModel_002.Models
{
    public class PersonProvider
    {

        private List<Person> items = new List<Person>();

        public PersonProvider()
        {
            //Generujemy przykładowe dane
            GenerateRandomData();

        }

        private void GenerateRandomData(int count = 50)
        {
            Insert(new Person() { FirstName = "Jan", SureName = "Nowak", Sex = 'M', BirthDate = new DateTime(2000, 1, 22) }, true);
            Insert(new Person() { FirstName = "Piotr", SureName = "Brzeski", Sex = 'M', BirthDate = new DateTime(1995, 10, 17) }, true);
            Insert(new Person() { FirstName = "Andrzej", SureName = "Dudek", Sex = 'M', BirthDate = new DateTime(1972, 4, 5) }, true);
            Insert(new Person() { FirstName = "Anna", SureName = "Mała", Sex = 'W', BirthDate = new DateTime(2003, 10, 23) }, true);

            var r = new Random();
            for (var i = 0; i < count; i++)
                Insert(new Person()
                {
                    FirstName = "FirstName_" + i,
                    SureName = "SureName_" + i,
                    BirthDate = new DateTime(r.Next(1950, 2010), r.Next(1, 12), r.Next(1, 28)),
                    Sex = 'M'
                }, true);
            foreach (var item in items)
                item.Email = item.FirstName.Substring(0, 1) + "." + item.SureName + "@domena.com";

        }

        public List<Person> ListAll()
        {
            return items;
        }

        //Dodaje nowy obiekt do listy. Może także generować id tego obiektu
        public Boolean Insert(Person value, Boolean createid = false)
        {
            if (value == null)
                return false;

            if (String.IsNullOrEmpty(value.PersonId) && createid)
                value.PersonId = Guid.NewGuid().ToString();

            //Takiego obiektu (o takim PersonID) nie ma jeszcze w kolekcji
            if (Find(value) == null)
            {
                items.Add(value);
                return true;
            }
            return false;
        }

        //Wyszukuje i zwraca obiekt o podanym id. Zwraca null, jeżeli obiekt nie istnieje w liście
        public Person Find(string personid)
        {
            if (!String.IsNullOrEmpty(personid))
                return items.SingleOrDefault(item => item.PersonId == personid);
            else
                return null;
        }

        //Wyszukuje i zwraca obiekt o id identycznym jak value.Personid
        public Person Find(Person value)
        {
            return (value == null) ? null : Find(value.PersonId);
        }


        public Boolean Remove(string personid)
        {
            return items.Remove(Find(personid));
        }

        public Boolean Remove(Person value)
        {
            return items.Remove(Find(value));
        }

        //Metoda aktualizuje (zastępuje) obiekt zawarty w kolekcji i którego PersonID = value.PersonID. Nowy obiekt = value
        public Boolean Update(Person value)
        {
            var person = Find(value);
            if (person != null)
            {
                items[items.IndexOf(person)] = value;
                return true;
            }
            else
                return false;
        }

        public Boolean InsertOrUpdate(Person value)
        {
            var person = Find(value);
            if (person == null)
                return Insert(value, true);
            else
                return Update(value);
        }

    }
}