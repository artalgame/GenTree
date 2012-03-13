using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenTreeBE
{
  public class GenTree
    {    
      private DateTime _dateOfCreate;
      private DateTime _dateOfLastEdit;
      private String _name;
      private int _id;
      private PersonList _persons;
      private string _information;
      private RelationsTable _relationTable;

      public string Information
      {
          get
          {
              return _information;
          }
          set
          {
              _information = value;
          }
      }
      
      public PersonList Persons
      {
          get
          {
              return _persons;
          }
          set
          {
              _persons = value;
          }
       }
      public RelationsTable Relations
      {
          get
          {
              return _relationTable;
          }
          private set{ }

      }

      public int ID
      {
          get
          {
              return _id;
          }
          set
          {
              _id = value;
          }
      }

      public string Name
      {
          get
          {
              return _name;
          }
          set
          {
              _name = value;
          }
      }
      public DateTime DateOfCreate
      {
          get
          {
              return _dateOfCreate;
          }
          set
          {
              _dateOfCreate = value;
          }
      }
      public DateTime DateOfLastEdit
      {
          get
          {
              return _dateOfLastEdit;
          }
          set
          {
              _dateOfLastEdit = value;
          }
      }
          
      /// <summary>
      /// return count of person in tree
      /// </summary>
      public int CountOfPerson
      {
          get
          {
              if (_persons != null)
                  return _persons.Count;

              else
                  return 0;
          }
          private set
          { 
          }
      }
      public void DeletePerson(Person person)
      {
          Persons.DeletePersonFromList(person);
          Relations.DeleteRelationOfPerson(person);
      }
      public GenTree(DateTime dateOfCreate, DateTime dateOfLastEdit,
          String name,string information,int id = -1, List<Person> personList = null,
          List<RelationBetweenTwoPerson> relationList=null)
      {
          _dateOfCreate = dateOfCreate;
          _dateOfLastEdit = dateOfLastEdit;
          _name = name;
          _information = information;
          _persons = PersonList.GetPersonList(personList);
          _relationTable = RelationsTable.GetTable(relationList);
          if (id == -1)
              _id = (name + dateOfCreate.ToString() + information).GetHashCode();
          else
              _id = id;
      }
    }
}
