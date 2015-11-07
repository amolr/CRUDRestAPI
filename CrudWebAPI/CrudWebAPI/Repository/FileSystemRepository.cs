using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Hosting;
using CrudWebAPI.Models;
using Newtonsoft.Json;

namespace CrudWebAPI.Repository
{
    /// <summary>
    /// Class for dealing with data on file system
    /// </summary>
    public class FileSystemRepository : IRepository<Employee>
    {
        // Reads data file entries
        FileReader reader;

        // writes data entries to file
        FileWriter writer;

        //path of the file where entries are stored
        private string fileName;
        
        public FileSystemRepository(IFileHelper helper)
        {
            fileName = helper.GetFilePath();
            reader = new FileReader(fileName);
            writer = new FileWriter(fileName);
        }

        /// <summary>
        /// Gets all the employee items by reading from the file
        /// </summary>
        /// <returns>List of all employee items</returns>
        public IEnumerable<Employee> GetAllItems()
        {
            return reader.CreateEmployeeList();
        }

        /// <summary>
        /// Gets the employee item by id
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <returns>represents an Employee object</returns>
        public Employee GetItemById(int id)
        {
            List<Employee> employeeList = reader.CreateEmployeeList();
            if (employeeList == null)
                throw new JsonSerializationException();
            try
            {
                return employeeList.Find(e => e.id == id);
            }
            catch(ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch(InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Add an employee item to the existing list
        /// </summary>
        /// <param name="item">represents an Employee object</param>
        /// <returns>newly created employee object</returns>
        public Employee AddItem(Employee item)
        {
            if (item == null)
                return null;

            List<Employee> employeeList = reader.CreateEmployeeList();
            if (employeeList == null)
                throw new JsonSerializationException();

            employeeList.Add(item);

            writer.WriteToFile(employeeList);
            return item;
        }

        /// <summary>
        /// Deletes an employee object belonging to a specific id
        /// </summary>
        /// <param name="id">Id of the object to be deleted</param>
        /// <returns>status of deletion</returns>
        public bool RemoveItem(int id)
        {
            List<Employee> employeeList = reader.CreateEmployeeList();
            if (employeeList == null)
                throw new JsonSerializationException();

            try
            {
                int count = employeeList.RemoveAll(e => e.id == id);
                writer.WriteToFile(employeeList);
                return count > 0 ? true : false;
            }
            catch(ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Updates an employee object and persists it on the file
        /// </summary>
        /// <param name="item">represents an Employee object</param>
        /// <returns>newly created employee object</returns>
        public Employee UpdateItem(Employee item)
        {
            if (item == null)
                throw new NullReferenceException();

            try
            {
                List<Employee> employeeList = reader.CreateEmployeeList();
                if (employeeList == null)
                throw new JsonSerializationException();

                int index = employeeList.FindIndex(e => e.id == item.id);

                if (index == -1)
                    return null;

                employeeList.RemoveAt(index);
                employeeList.Add(item);
                writer.WriteToFile(employeeList);
                return employeeList[index];
            }
            catch(ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch(ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}