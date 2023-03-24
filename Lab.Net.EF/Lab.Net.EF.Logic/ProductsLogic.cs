using Lab.Net.EF.Data;
using Lab.Net.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.EF.Logic
{
    public class ProductsLogic : BaseLogic, IABMLogic<Products>
    {
        public void Add(Products entity)
        {
            context.Products.Add(entity);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var ProductToDelete = context.Products.Find(id);
            context.Products.Remove(ProductToDelete);
            context.SaveChanges();
        }
        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }
        public void Update(Products entity)
        {
            var productUpdate = context.Products.Find(entity.ProductID);
            productUpdate.ProductName = entity.ProductName;
            context.SaveChanges();
        }
        public Products GetById(int id)
        {
            return context.Products.FirstOrDefault(p => p.ProductID == id);
        }
    }
}
