using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenTree
{
    public interface SaveOrOpenTree
    {
        bool SaveTree(GenTree tree);
        bool OpenTree(out GenTree tree);
    }
}
