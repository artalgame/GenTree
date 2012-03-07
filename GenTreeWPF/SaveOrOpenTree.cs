using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenTreeBE
{
    public interface SaveOrOpenTree
    {
        bool SaveTree(string fileName,GenTree tree);
        bool OpenTree(string fileName, out GenTree tree, bool isForInformationOnly);
    }
}
