using Lab.Net.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.EF.Logic
{
    public class OrdersLogic : BaseLogic, IABMLogic<Orders>
    {
        public void Add(Orders entity)
        {
            context.Orders.Add(entity);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var orderToDelete = context.Orders.Find(id);
            if (orderToDelete == null)
            {
                throw new ArgumentException($"La orden con ID {id} no existe.");
            }

            context.Orders.Remove(orderToDelete);
            context.SaveChanges();
        }

        public List<Orders> GetAll()
        {
            return context.Orders.ToList();
        }

        public void Update(Orders entity)
        {
            var orderUpdate = context.Orders.Find(entity.OrderID);
            if (orderUpdate == null)
            {
                throw new ArgumentException($"La orden con ID {entity.EmployeeID} no existe.");
            }
            orderUpdate.ShipName = entity.ShipName;
            orderUpdate.ShipCountry = entity.ShipCountry;          
            context.SaveChanges();
        }
    }
}
