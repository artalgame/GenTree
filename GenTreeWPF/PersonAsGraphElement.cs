using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenTreeBE;

namespace GenTreeCore
{
    public class PersonAsGraphElement
    {
        public Person PersonLink { get; set; }
        public int Layer { get; set; }
        public int FamilyCell { get; set; }

        public PersonAsGraphElement(Person person, int layer, int familyCell)
        {
            PersonLink = person;
            Layer = layer;
            FamilyCell = familyCell;
        }
    }
}
