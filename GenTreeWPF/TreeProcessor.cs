﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenTreeBE;
using GenTreeDAL;
using System.Configuration;

namespace GenTreeCore
{
    public class TreeProcessor
    {
        private List<GenTree> _listOfTreeInfo;
        private string _treeCatalogName;
        private GenTree _currentTree;
        private Person _currentPerson;

        private static TreeProcessor _singletone;
        public static  TreeProcessor TreeProcessorSingletone
        {
            get
            {
                if (_singletone == null)
                {
                    _singletone = new TreeProcessor();
                }
                return _singletone;
            }
            private set { }
        }

        public bool SetCurrentTree(int id)
        {
            try
            {
                SetCurrentTree(_listOfTreeInfo.Single<GenTree>(x => x.ID == id));
                return true;
            }
            catch
            {
                _currentTree = null;
                return false;
            }
        }

        public bool SetCurrentTree(GenTree tree)
        {
            _currentTree = tree;
            return true;
        }
        public GenTree CurrentTree
        {
            get
            {
                return _currentTree;
            }
            private set
            {
            }
        }
        public Person CurrentPerson
        {
            get
            {
                return _currentPerson;
            }
            set
            {
                _currentPerson = value;
            }
        }

        public bool GetTreeInfoFromIndex(int index, out GenTree tree)
        {
            try
            {
                tree = _listOfTreeInfo[index];
                return true;
            }
            catch (Exception)
            {
                tree = null;
                return false;
            }
        }
        public bool GetTreeFromID(int ID, out GenTree tree)
        {
            try
            {
                tree = _listOfTreeInfo.Single<GenTree>(x => x.ID == ID);
                if (tree != null)
                    return true;
                else
                    throw new FieldAccessException();
            }
            catch (Exception)
            {
                tree = null;
                return false;
            }
        }

        public List<GenTree> GetTreesInfo()
        {
            return _listOfTreeInfo;
        }

        private TreeProcessor()
        {
            try
            {
                _treeCatalogName = ConfigurationManager.AppSettings.GetValues("treeCatalog")[0];
                _listOfTreeInfo = new TreeToXml().GetSavedTrees(_treeCatalogName);
            }
            catch
            {
                _listOfTreeInfo = null;
            }
        }
    }
}
