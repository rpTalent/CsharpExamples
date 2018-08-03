using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebModel_001.Models
{
    public class PersonProvider
    {

        private List<Person> items = new List<Person>();

        public List<Person> Items { get { return items; } }

        //Dodaje nowy obiekt do listy. Może także generować id tego obiektu
        public Boolean Insert(Person value, Boolean createid = false)
        {
            if (String.IsNullOrEmpty(value.PersonId) && createid)
                value.PersonId = Guid.NewGuid().ToString();

            if (Find(value.PersonId) == null)
            {
                Items.Add(value);
                return true;
            }
            return false;
        }

        //Wyszukuje i zwraca obiekt o podanym id. Zwraca null, jeżeli obiekt nie istnieje w liście
        public Person Find(string personid)
        {
            if (!String.IsNullOrEmpty(personid))
                return Items.SingleOrDefault(item => item.PersonId == personid);
             else
                return null;
        }

        //Wyszukuje i zwraca obiekt o id identycznym jak value.Personid
        public Person Find(Person value)
        {
            if (value != null)
                return Find(value.PersonId);
            else
                return null;
        }


        public Boolean Remove(string personid)
        {
            return Items.Remove(Find(personid));
        }

        public Boolean Remove(Person value)
        {
            return Items.Remove(Find(value));
        }
    }
}