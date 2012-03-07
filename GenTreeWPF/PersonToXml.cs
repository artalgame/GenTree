using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using GenTreeBE;

namespace GenTreeDAL
{
    internal class PersonToXml
    {
        public bool AddToElement(Person person,out XElement xPerson)
        {
            try
            {
                xPerson = new XElement("person");               
                xPerson.SetAttributeValue("id", person.ID);
                xPerson.SetAttributeValue("name",person.NameOfPerson);
                xPerson.SetAttributeValue("layer", person.GenLayer);
                xPerson.SetAttributeValue("gender", person.Gender.ToString());
                xPerson.SetAttributeValue("bornDate", person.DateOfBorn.ToString());
                xPerson.SetAttributeValue("deathDate", person.DateOfDeath.ToString());
                xPerson.SetAttributeValue("note", person.Note);
                return true;
            }
            catch (Exception)
            {
                xPerson = null;
                return false;
            }
        }

            public bool GetFromElement(XElement xPerson, out Person person)
            {
                try
                {                    
                    int ID = Int32.Parse(xPerson.Attribute("id").Value);
                    string name = xPerson.Attribute("name").Value;
                    int layer= Int32.Parse(xPerson.Attribute("layer").Value);
                    Genders gender = (Genders)Enum.Parse(typeof(Genders),xPerson.Attribute("gender").Value);
                    DateTime bornDate = DateTime.Parse(xPerson.Attribute("bornDate").Value);
                    DateTime deathDate = DateTime.Parse(xPerson.Attribute("deathDate").Value);
                    string note = xPerson.Attribute("note").Value;
                    person = new Person(ID,name,bornDate,deathDate,gender,layer,note);
                    return true;
                }
                catch(Exception)
                {
                    person = null;
                    return false;
                }
            }
        }
    }
