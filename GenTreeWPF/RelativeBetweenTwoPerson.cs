using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenTreeBE
{
    public class RelationBetweenTwoPerson
    {
        public Person FirstPerson
        {
            get;
            set;
        }
        public Person SecondPerson
        {
            get;
            set;
        }
        public Relatives Relations
        {
            get;
            set;
        }
        public RelationBetweenTwoPerson(Person firstPerson, Person secondPerson, Relatives relations)
        {
            FirstPerson = firstPerson;
            SecondPerson = secondPerson;
            Relations = relations;
        }
    }
}
