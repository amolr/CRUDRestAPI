using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CrudWebAPI.Repository
{
    public class TestFileHelper : IFileHelper
    {
        private string fileParentPath = "";

        public TestFileHelper() 
        {
            fileParentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
        public string GetFilePath()
        {
            return fileParentPath + @"\CrudWebAPI\App_data\" + Constants.testfile;
        }
    }
}