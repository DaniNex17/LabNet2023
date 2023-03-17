using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.EF.Logic
{
    public class CustomersOrdersLogic : BaseLogic
    {
        public void CustomersOrdersJoin()
        {
            var query = from customer in context.Customers
                       join order in context.Orders on customer.CustomerID equals order.CustomerID
                       where customer.Region == "WA" && order.OrderDate > new DateTime(1997, 1, 1)
                       select new { customer.CompanyName, order.OrderDate };

            foreach (var item in query)
            {
                Console.WriteLine($"Company Name: {item.CompanyName}, Order Date: {item.OrderDate}");
            }
        }     
    }
}
