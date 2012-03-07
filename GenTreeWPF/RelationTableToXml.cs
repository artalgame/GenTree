using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GenTreeBE
{
    internal class RelationTableToXml
    {
        public bool AddToElement(RelationsTable table, out XElement xTable)
        {
            try
            {
                xTable = new XElement("relations");
                foreach (RelationBetweenTwoPerson relation in table)
                {
                    XElement xRelation = new XElement("relation");
                    xRelation.SetAttributeValue("firstPerson", relation.FirstPerson.ID);
                    xRelation.SetAttributeValue("secondPerson", relation.SecondPerson.ID);
                    xRelation.SetAttributeValue("relation", relation.Relations.ToString());
                    xTable.Add(xRelation);
                 }
                return true;
            }
            catch
            {
                xTable = null;
                return false;
            }
        }
        public bool GetFromElement(XElement xTable, out RelationsTable table)
        {
            table = RelationsTable.GetTable();
            table.Clear();
            try
            {
                foreach (XElement xRelation in xTable.Elements("relation"))
                {
                    int firstID = Int32.Parse(xRelation.Attribute("firstPerson").Value);
                    int secondID = Int32.Parse(xRelation.Attribute("secondPerson").Value);
                    Relatives relation = (Relatives)Enum.Parse(typeof(Relatives), xRelation.Attribute("relation").Value);

                    PersonList personList = PersonList.GetPersonList(null);
                    Person fPerson;
                    Person sPerson;
                    if((personList.GetPersonFromID(firstID,out fPerson))
                        &&(personList.GetPersonFromID(secondID,out sPerson)))
                    {
                        table.SetRelationBetweenPersons(fPerson, sPerson, relation);
                    }
                }
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
