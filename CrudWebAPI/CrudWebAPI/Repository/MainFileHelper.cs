using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace CrudWebAPI.Repository
{
    public class MainFileHelper : IFileHelper
    {
        private string fileParentPath = "";

        public MainFileHelper() 
        {
            fileParentPath = HostingEnvironment.MapPath("~/App_Data");
        }
        public string GetFilePath()
        {
            return fileParentPath + "/" + Constants.dataFile;
        }
    }
}