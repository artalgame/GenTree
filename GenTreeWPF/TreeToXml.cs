using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using GenTreeBE;

namespace GenTreeDAL
{
    public class TreeToXml : SaveOrOpenTree
    {
        public List<GenTree> GetSavedTrees(string directoryName)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryName);
            List<GenTree> findedTrees = new List<GenTree>();
            foreach (FileInfo file in directory.GetFiles("*.xml"))
            {
                GenTree tree;
                if (OpenTree(file.FullName, out tree,true))
                {
                    findedTrees.Add(tree);
                }
            }
            return findedTrees;
        }
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
                xmlTree.Save(fileName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool OpenTree(string fileName, out GenTree tree,bool isReadInformationOnly=false)
        {
            try
            {
                if (File.Exists(fileName))
                {

                    XmlTextReader xmlFile = new XmlTextReader(fileName);
                    XDocument xmlTree = XDocument.Load(xmlFile);
                    XElement root = xmlTree.Root;
                    string treename = root.Attribute("name").Value;
                    DateTime createTime = DateTime.Parse(root.Attribute("createDate").Value);
                    DateTime lastEditTime = DateTime.Parse(root.Attribute("lastEditDate").Value);
                    int id = Int32.Parse(root.Attribute("id").Value);
                    string information = root.Attribute("information").Value;
                    if (isReadInformationOnly)
                    {
                        tree = new GenTree(createTime, lastEditTime, treename, information, id,null, null); 
                        return true;
                    }
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
                    tree = new GenTree(createTime,lastEditTime,treename,information,id,personList,relationList);
                    return true;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch(Exception)
            {
                tree = null;
                return false;
                
            }
        }
        
    }
}
