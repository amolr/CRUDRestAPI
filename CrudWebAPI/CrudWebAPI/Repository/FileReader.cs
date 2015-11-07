using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CrudWebAPI.Models;
using Newtonsoft.Json;

namespace CrudWebAPI.Repository
{
    /// <summary>
    /// Deals with reading entries from data file
    /// </summary>
    public class FileReader
    {
        // path of the filename to be read
        private string fileName;

        public FileReader(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Creates a list of employee objects by reading from the data file
        /// </summary>
        /// <returns>List of employee objects</returns>
        public List<Employee> CreateEmployeeList()
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(fileName);
                string data = reader.ReadToEnd();
                List<Employee> employeeList = JsonConvert.DeserializeObject<List<Employee>>(data);
                return employeeList;
            }
            catch (JsonSerializationException e)
            {
                throw new JsonSerializationException();
            }
            catch (Exception e)
            {
                throw new IOException();
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }
        }
    }
}