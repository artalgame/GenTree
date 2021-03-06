﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GenTreeBE
{
    public class PersonList:IEnumerable<Person>
    {
        private static PersonList _personList;
        public static PersonList GetPersonList(List<Person> persons = null)
        {
            if (_personList == null)
            {
                if (persons == null)
                    _personList =  new PersonList();
                else
                    _personList = new PersonList(persons);
                return _personList;
            }
            else
            {
                if (persons != null)
                    _personList._persons = persons;
                return _personList;
            }
        }
        private List<Person> _persons;
        public int Count
        {
            get
            {
                return _persons.Count;
            }
            private set { }
        }
        public int GetPersonIndexInTable(Person person)
        {
            try
            {
                return _persons.FindLastIndex(x => (x.ID == person.ID));

            }
            catch (Exception)
            {
                return -1;
            }

        }

        private PersonList()
        {
            _persons = new List<Person>();
        }
        private PersonList(List<Person> personList)
        {
            _persons = personList;
        }
        public List<Person> GetPersonsList()
        {
            return _persons;
        }
        public bool AddNewPerson(Person newPerson)
        {
            Person tmp;
            try
            {
                tmp = _persons.Single<Person>(x => x.ID == newPerson.ID);
            }
            catch
            {
                tmp = null;
            }
                if (tmp == null)
                {
                    _persons.Add(newPerson);
                    return true;
                }
                else
                    return false;
        }
        public bool GetPersonFromID(int ID, out Person person)
        {
            try
            {
                person = _persons.Single<Person>(x => x.ID == ID);
                return true;
            }
            catch
            {
                person = null;
                return false;
            }
        }

        public void DeletePersonFromList(Person person)
        {
            _persons.Remove(person);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return (IEnumerator<Person>)_persons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)_persons.GetEnumerator();
        }
    }
}
