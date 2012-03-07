using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenTreeBE
{ 
  public  class Person
    {
      /// <summary>
      /// For other notes about person
      /// </summary>
      private string _note;
      /// <summary>
      /// Uniqual ID of person
      /// </summary>
      public int ID 
      {
          get;
          set;
      }
      public DateTime DateOfBorn
      {
          get;
          set;
      }
      public DateTime DateOfDeath
      {
          get;
          set;
      }
      public String NameOfPerson
      {
          get;
          set;
      }
      public Genders Gender
      {
          get;
          set;
      }

      /// <summary>
      /// it's property signalize, what layer on this person in common tree
      /// </summary>
      public int GenLayer
      {
          get;
          set;
      }
      /// <summary>
      /// Method returns string of Notes or return null if was mistake
      /// </summary>
      /// <param name="index"></param>
      /// <returns></returns>
      public String Note
      {
          get
          {
              return _note;
          }
          set
          {
              _note = value;
          }
      }

      public Person(int id, String personName, DateTime dateOfBorn, DateTime dateOfDeath,
          Genders gender, int genLayer, String notes)
      {
          ID = id;
          NameOfPerson = personName;
          DateOfBorn = dateOfBorn;
          DateOfDeath = dateOfDeath;
          Gender = gender;
          GenLayer = genLayer;
          Note = notes;
      }
    }
}
