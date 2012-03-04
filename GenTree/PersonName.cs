using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenTree
{
 public class PersonName
   {
     /// <summary>
     /// Saves all names(first,second and other)
     /// </summary>
     private List<String> _allNames;
    
     private bool _noNames;
     public PersonName(String[] names)
     {
         if ((names == null) || (names.Length == 0))
         {
             _allNames = new List<String>(1);
             _allNames[0] = "No name";
             _noNames = true;
         }
         else
         {
             //_allNames = new List<string>(names.Length);
             _allNames = names.ToList<string>();
             _noNames = false;
         }
     }
     public List<String> GetNames()
     {
         return _allNames;
     }
     public string GetName(int index)
     {
         try
         {
             return _allNames[index];
         }
         catch (Exception)
         {
             return _allNames[1];
         }
     }
     public bool AddName(string newName, int index = -1)
     {
         if ((index == -1))
             return AddName(newName);
         else
         {
             if (newName != null)
             {
                 try
                 {
                     //if _noNames == true then newName will stayed only on [0] position
                     _allNames[index] = newName;
                     if (_noNames)
                         _noNames = false;
                     return true;
                 }
                 catch (Exception)
                 {
                     return false;
                 }
             }
             else
                 return false;
         }
     }
     private bool AddName(string newName)
     {
         if (newName != null)
         {
             if (_noNames)
             {
                 _noNames = true;
                
                 _allNames[0] = newName;
                 return true;
             }
             else
             {
                 _allNames.Add(newName);
                 return true;
             }
         }
         else
             return false;
     }
    }
}
