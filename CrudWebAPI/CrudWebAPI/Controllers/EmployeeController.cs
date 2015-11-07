using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudWebAPI.Repository;
using CrudWebAPI.Models;

namespace CrudWebAPI.Controllers
{
    // Performs all the CRUD operations on employee resource
    public class EmployeeController : ApiController
    {
        private IRepository<Employee> repository;

        public EmployeeController(IRepository<Employee> repository)
        {
            this.repository = repository;
        }
        
        // GET api/v1/employee/
        // Gets all employee resources
        public IEnumerable<Employee> GetAllEmployees()
        {
            return repository.GetAllItems();
        }

        // GET api/v1/employee/2
        // Gets an employee resource by id 
        public Employee GetEmployeeById(int id)
        {
            try
            {
                Employee item = repository.GetItemById(id);
                if (item == null)
                {
                    throw new ArgumentNullException();
                }

                return item;
            }
            catch (ArgumentNullException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            catch(Exception)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        // POST api/v1/employee/
        // Creates a new employee resource with a given body
        public HttpResponseMessage PostEmployee(Employee item)
        {
            try
            {
                item = repository.AddItem(item);
                if (item == null)
                    throw new ArgumentNullException();

                var response = Request.CreateResponse<Employee>(HttpStatusCode.Created, item);
                string uri = Url.Link("DefaultApi", new { id = item.id });
                response.Headers.Location = new Uri(uri);

                return response;
            }
            catch (ArgumentNullException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
            catch(Exception)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
        
        // PUT api/v1/employee/
        // Updates a employee resource with a given body
        public HttpResponseMessage PutEmployee(Employee item)
        {
            try
            {
                item = repository.UpdateItem(item);
                
                if(item==null)
                {
                    throw new NullReferenceException();
                }

                var response = Request.CreateResponse<Employee>(HttpStatusCode.OK, item);
                return response;
            }

            catch(NullReferenceException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }
            catch(Exception)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        // DELETE api/v1/employee/5
        // deletes an employee resource based on given id
        public void Delete(int id)
        {
            try
            {
                if (!repository.RemoveItem(id))
                    throw new KeyNotFoundException();   
            }
            catch(KeyNotFoundException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            catch(Exception)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}