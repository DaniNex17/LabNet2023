using Lab.Net.EF.Data;
using Lab.Net.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.EF.Logic
{
    public class ProductsLogic : BaseLogic
    {
        public List<Products> GetProductsNoStock()
        {
            var query = from p in context.Products
                        where p.UnitsInStock == 0
                        select p;
            return query.ToList();
        }
        public List<Products> GetProductsStockAndPrice3() 
        {
            var query = from p in context.Products
                        where p.UnitsInStock > 0 && p.UnitPrice > 3
                        select p;
            return query.ToList();
        }
        public Products GetProductById(int productId)
        {
            var product = (from p in context.Products
                           where p.ProductID == productId
                           select p).FirstOrDefault();
            return product;
        }

        public List<Products> GetProdOrderedByName()
        {
            var products = context.Products.OrderBy(p => p.ProductName).ToList();
            return products;
        }

        public List<Products> GetProdOrderByUnitStock()
        {
            return context.Products.OrderByDescending(p => p.UnitsInStock).ToList();
        }

        public List<string> GetDistinctCategories()
        {
            var distinctCategories = context.Products.Select(p => p.Categories.CategoryName).Distinct().ToList();
            return distinctCategories;
        }
        public Products GetFirstProduct()
        {
            return context.Products.FirstOrDefault();
        }      
    }
}
