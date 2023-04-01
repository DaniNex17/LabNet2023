using Lab.Net.EF.Entities;
using Lab.Net.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods:"GET, POST, PUT, DELETE, OPTIONS")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    //[EnableCors("*", "*", "*")]
    public class EmployeesController : ApiController
    {
        // GET api/<controller>
        private readonly EmployeesLogic employeesLogic = new EmployeesLogic();
        public IEnumerable<Employees> Get()
        {
            return employeesLogic.GetAll();
        }

        // GET api/<controller>/5
        public Employees Get(int id)
        {
            return employeesLogic.GetById(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]Employees employee)
        {
            try
            {
                if (string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName))
                {
                    throw new ArgumentException("Los campos Nombre y Apellido son requeridos.");
                }
                employeesLogic.Add(employee);

                return Request.CreateResponse(HttpStatusCode.Created, employee);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Employees employee)
        {
            try
            {
                if (employee == null || employee.EmployeeID != id)
                {
                    throw new ArgumentException("El ID del empleado no coincide con el objeto recibido.");
                }

                var existingEmployee = employeesLogic.GetById(id);
                if (existingEmployee == null)
                {
                    throw new ArgumentException($"El empleado con ID {id} no existe.");
                }

                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.City = employee.City;
                existingEmployee.Country = employee.Country;
                employeesLogic.Update(existingEmployee);             

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var logic = new EmployeesLogic();
                logic.Delete(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}