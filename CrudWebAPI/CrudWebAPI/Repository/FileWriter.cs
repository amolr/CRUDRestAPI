using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using CrudWebAPI.Models;

namespace CrudWebAPI.Repository
{
    /// <summary>
    /// Deals with writing entries to data file
    /// </summary>
    public class FileWriter
    {
        // path of the filename to be read
        private string fileName;

        public FileWriter(string fileName)
        {
            this.fileName = fileName;
        }
        
        /// <summary>
        /// Writes entries to the data file
        /// </summary>
        /// <param name="employeeList">List of employee objects to be written</param>
        public void WriteToFile(List<Employee> employeeList)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName);
                writer.Write(JsonConvert.SerializeObject(employeeList));
            }
            catch (JsonSerializationException)
            {
                throw new JsonSerializationException();
            }
            catch (IOException)
            {
                throw new IOException();
            }
            catch(NotSupportedException)
            {
                throw new NotSupportedException();
            }
            finally
            {
                if (writer != null)
                    writer.Dispose();
            }

        }
    }
}