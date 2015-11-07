using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrudWebAPI;
using CrudWebAPI.Repository;
using CrudWebAPI.Models;
using CrudWebAPI.Controllers;

namespace CrudWebAPI.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            IRepository<Employee> repository = new FileSystemRepository(new TestFileHelper());
            EmployeeController controller = new EmployeeController(repository);

            // Act
            IEnumerable<Employee> result = controller.GetAllEmployees();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            IRepository<Employee> repository = new FileSystemRepository(new TestFileHelper());
            EmployeeController controller = new EmployeeController(repository);

            //// Act
            Employee result = controller.GetEmployeeById(2);

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.id);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            IRepository<Employee> repository = new FileSystemRepository(new TestFileHelper());
            EmployeeController controller = new EmployeeController(repository);
            int lengthBefore = controller.GetAllEmployees().Count();
            
            // Act
            Employee e = new Employee {id = 4, name="test",age=45,sex="female"};
            controller.PostEmployee(e);
            int lengthAfter = controller.GetAllEmployees().Count();
            
            // Assert
            Assert.AreEqual(lengthBefore + 1, lengthAfter);
        }

        [TestMethod]
        
        public void Put()
        {
        //    // Arrange
        //    IRepository<Employee> repository = new FileSystemRepository(new TestFileHelper());
        //    EmployeeController controller = new EmployeeController(repository);
            
        //    //Act
        //    Employee e = new Employee { id = 1, name = "amol", sex = "male", age = 29 };
        //    controller.PutEmployee(e);

        //    // Assert
        //    Employee changedEmployee = controller.GetEmployeeById(2);
        //    Assert.AreEqual("amol", changedEmployee.name);
        //    Assert.AreEqual(28, changedEmployee.age);
        }

        [TestMethod]
        
        public void Delete()
        {
        //    //Arrange
        //    IRepository<Employee> repository = new FileSystemRepository(new TestFileHelper());
        //    EmployeeController controller = new EmployeeController(repository);
        //    int lengthBefore = controller.GetAllEmployees().Count();          
            
        //    // Act
        //    controller.Delete(2);
        //    int lengthAfter = controller.GetAllEmployees().Count();  
            
        //    // Assert
        //    Assert.AreEqual(lengthAfter + 1, lengthBefore);
        }
    }
}
