using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace GenTree
{
    public class TreeToXml : SaveOrOpenTree
    {
        public bool SaveTree(string fileName, GenTree tree)
        {
            XDocument xmlTree = new XDocument();
            XElement root = new XElement("tree");
            try
            {
                root.SetAttributeValue("name", tree.Name);
                root.SetAttributeValue("createDate", tree.DateOfCreate.ToString());
                root.SetAttributeValue("lastEditDate", tree.DateOfLastEdit.ToString());
                root.SetAttributeValue("id", tree.ID);
                root.SetAttributeValue("information", tree.Information);

                XElement xPersons = new XElement("persons");
                List<Person> persons = tree.Persons.GetPersonList();
                PersonToXml personToXml = new PersonToXml();
                XElement xPerson;
                foreach (Person person in persons)
                {
                    if (personToXml.AddToElement(person, out xPerson))
                    {
                        xPersons.Add(xPerson);
                    }
                    else return false;
                }
                root.Add(xPersons);

                XElement xTable = new XElement("table");
                List<RelationBetweenTwoPerson> relations = tree.Relations.GetRelationList();
                RelationToXml relationToXml = new RelationToXml();
                XElement xRelation;
                foreach(RelationBetweenTwoPerson relation in relations)
                {
                if (!relationToXml.AddToElement(relation, out xRelation))
                {
                    return false;
                }
                else
                    xTable.Add(xRelation);
                }
                root.Add(xTable);
                xmlTree.Add(root);
                xmlTree.Save(new XmlTextWriter(fileName, null));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool OpenTree(string fileName, out GenTree tree)
        {
            try
            {
                if (File.Exists(fileName))
                {

                    XmlTextReader xmlFile = new XmlTextReader(File.OpenText(fileName), null);
                    XDocument xmlTree = XDocument.Load(xmlFile);
                    XElement root = xmlTree.Root;
                    string treename = root.Attribute("name").Value;
                    DateTime createTime = DateTime.Parse(root.Attribute("createDate").Value);
                    DateTime lastEditTime = DateTime.Parse(root.Attribute("lastEditDate").Value);
                    int id = Int32.Parse(root.Attribute("id").Value);
                    string information = root.Attribute("information").Value;

                    List<Person> personList = new List<Person>();
                    Person somePerson;
                    PersonToXml readPerson = new PersonToXml();
                    foreach(XElement xmlPerson in root.Elements("persons").Elements())
                    {
                        if (readPerson.GetFromElement(xmlPerson, out somePerson))
                        {
                            personList.Add(somePerson);
                        }
                        else
                        {
                            tree = null;
                            return false;
                        }
                    }
                    List<RelationBetweenTwoPerson> relationList = new List<RelationBetweenTwoPerson>();
                    RelationBetweenTwoPerson relation;
                    RelationToXml readRelation = new RelationToXml();
                    foreach (XElement xmlRelation in root.Element("table").Elements())
                    {
                        if(readRelation.GetFromElement(xmlRelation,out relation))
                        {
                            relationList.Add(relation);
                        }
                        else
                        {
                            tree = null;
                            return false;
                        }
                    }
                    tree = new GenTree(createTime,lastEditTime,treename,id,information,personList,relationList);
                    return true;
                }
                else
                {
                    throw new FileNotFoundException();
                    tree = null;
                    return false;
                }
            }
            catch(Exception)
            {
                tree = null;
                return false;
                
            }
        }

        public bool SaveTree(GenTree tree)
        {
            throw new NotImplementedException();
        }

        public bool OpenTree(out GenTree tree)
        {
            throw new NotImplementedException();
        }
    }
}
