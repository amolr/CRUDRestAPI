# CRUDRestAPI
Implementation of CRUD operations using Web API

Shows a simple implementation of a REST API using ASP.NET Web API

The main code is in the below folders


1. CrudWebAPI/CrudWebAPI/Controllers : Contains all the code for HTTP REST operations.
2. CrudWebAPI/CrudWebAPI/App_Start/WebApiConfig.cs : Initialization logic. Includes the formatters and initialization of Dependency injection library Autofac
3. CrudWebAPI/CrudWebAPI/App_Start/RouteConfig.cs : URL Route pattern for REST API calls
4. CrudWebAPI/CrudWebAPI/App_Data/ : Data used for Testing the Web API locally and in unit test
5. CrudWebAPI/CrudWebAPI/Models/ : Model files
6. CrudWebAPI/CrudWebAPI/Repository/ : Interface to interact with a persistent layer. Also includes implementation of the interface using File system.
7. CrudWebAPI/CrudWebAPI.Tests : Contains unit tests for the REST API


Usage

1.	GET :  http://<server-name>/api/v1/employee/
Gets all employees.

2.	GET: http://<server-name>/api/v1/employee/2
Gets an employee by Id

3.	POST : http://<server-name>/api/v1/employee/
Body :
{
                              "id": 6,
                              "name": "Amolr",
                              "sex": "female",
                              "age": 35
               }

4.	PUT : http://<server-name>/api/v1/employee/
Body :
{
                              "id": 6,
                              "name": "amol",
                              "sex": "female",
                              "age": 36
               }

5.	DELETE :  http://<server-name>/api/v1/employee/2
Deletes an employee object with ID 2

