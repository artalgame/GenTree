using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using GenTreeBE;

namespace GenTreeDAL
{
    internal class RelationToXml
    {
        public bool AddToElement(RelationBetweenTwoPerson relation, out XElement xRelation)
        {
            try
            {
                xRelation = new XElement("relation");
                xRelation.SetAttributeValue("firstPerson", relation.FirstPerson.ID);
                xRelation.SetAttributeValue("secondPerson", relation.SecondPerson.ID);
                xRelation.SetAttributeValue("relation", relation.Relations.ToString());
                return true;
            }
            catch
            {
                xRelation = null;
                return false;
            }
        }
        public bool GetFromElement(XElement xRelation, out RelationBetweenTwoPerson relation)
        {
            try
            {
                int firstID = Int32.Parse(xRelation.Attribute("firstPerson").Value);
                int secondID = Int32.Parse(xRelation.Attribute("secondPerson").Value);
                Relatives relative = (Relatives)Enum.Parse(typeof(Relatives), xRelation.Attribute("relation").Value);

                PersonList personList = PersonList.GetPersonList(null);
                Person fPerson;
                Person sPerson;
                if ((personList.GetPersonFromID(firstID, out fPerson))
                    && (personList.GetPersonFromID(secondID, out sPerson)))
                {
                    relation = new RelationBetweenTwoPerson(fPerson, sPerson, relative);
                    return true;
                }
                else
                {
                    relation = null;
                    return false;
                }

            }
            catch
            {
                relation = null;
                return false;
            }
        }
    }
}
