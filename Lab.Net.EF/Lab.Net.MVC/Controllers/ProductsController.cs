using Lab.Net.EF.Entities;
using Lab.Net.EF.Logic;
using Lab.Net.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Net.MVC.Controllers
{
    public class ProductsController : Controller
    {
        readonly ProductsLogic logic = new ProductsLogic();

        public ActionResult Index()
        {
            List<Lab.Net.EF.Entities.Products> products = logic.GetAll();
            List<ProductsView> productsViews = products.Select(p => new ProductsView
            {
                Id = p.ProductID,
                ProductName = p.ProductName,
                UnitPrice = (decimal)p.UnitPrice,
            }).ToList();
            return View(productsViews);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ProductsView productsView)
        {
            if (!ModelState.IsValid)
            {
                return View(productsView);
            }
            try
            {

                Products products = new Products { ProductName = productsView.ProductName, UnitPrice = productsView.UnitPrice };
                logic.Add(products);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            logic.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            try
            {
                Products product = logic.GetById(id);
                ProductsView productsView = new ProductsView
                {
                    Id = product.ProductID,
                    ProductName = product.ProductName,
                    UnitPrice = (decimal)product.UnitPrice,
                };
                return View(productsView);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult Update(ProductsView productsView)
        {
            if (!ModelState.IsValid)
            {
                return View(productsView);
            }

            try
            {
                Products products = logic.GetById(productsView.Id);
                products.ProductName = productsView.ProductName;
                products.UnitPrice = productsView.UnitPrice;
                logic.Update(products);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}