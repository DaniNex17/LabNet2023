using Lab.Net.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.EF.Logic
{
    public class EmployeesLogic : BaseLogic, IABMLogic<Employees>
    {
        

        public void Add(Employees entity)
        {
            context.Employees.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employeeToDelete = context.Employees.Find(id);
            if (employeeToDelete == null)
            {
                throw new ArgumentException($"El empleado con ID {id} no existe.");
            }

            context.Employees.Remove(employeeToDelete);
            context.SaveChanges();
        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Update(Employees entity)
        {
            var employeeUpdate = context.Employees.Find(entity.EmployeeID);
            if (employeeUpdate == null)
            {
                throw new ArgumentException($"El empleado con ID {entity.EmployeeID} no existe.");
            }

            employeeUpdate.FirstName = entity.FirstName;
            employeeUpdate.LastName = entity.LastName;
            context.SaveChanges();
        }

        public Employees GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.EmployeeID == id);
        }
    }
}
