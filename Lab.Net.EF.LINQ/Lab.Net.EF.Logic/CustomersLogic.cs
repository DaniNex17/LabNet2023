using Lab.Net.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.EF.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public Customers GetCustomerById(string customerId)
        {
            var customer = context.Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customer == null)
            {
                throw new ArgumentException($"No se encontró el cliente con ID {customerId}");
            }
            return customer;
        }
        public List<Customers> GetCustomersByRegion(string region)
        {
            var customers = context.Customers
                .Where(c => c.Region == region)
                .ToList();

            return customers;
        }
        public string[] GetCustomerNamesUpLow()
        {
            var cNames = context.Customers
                .Select(c => new { UpperCase = c.CompanyName.ToUpper(), LowerCase = c.CompanyName.ToLower()})
                .ToArray();
            return cNames.Select(c => c.UpperCase).ToArray();
        }
        public List<Customers> ThreeCustomers()
        {
            return context.Customers.Where(c => c.Region == "WA").Take(3).ToList();
        }      
    }
}
