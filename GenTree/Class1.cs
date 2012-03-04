using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace GenTree
{
    public class TreeToXml:SaveOrOpenTree
    {
        public String FileName
        {
            get;
            set;
        }
        public TreeToXml(String fileName)
        {
            FileName = fileName;
        }
        public bool SaveTree(GenTree tree)
        {
            XDocument xmlTree = new XDocument();
            XElement root = new XElement("tree");
            root.SetAttributeValue("name", tree.Name);
            root.SetAttributeValue("createDate", tree.DateOfCreate.ToString());
            root.SetAttributeValue("lastEditDate", tree.DateOfLastEdit.ToString());
            root.SetAttributeValue("id", tree.ID);
            root.SetAttributeValue("countOfPerson", tree.CountOfPerson);
            
        }
        public bool OpenTree(out GenTree tree)
        {
            
        }
    }
}
