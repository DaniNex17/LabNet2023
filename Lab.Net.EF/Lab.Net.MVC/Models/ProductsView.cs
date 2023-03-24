using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Lab.Net.MVC.Models
{
    public class ProductsView
    {
        public int Id { get; set; }
        [Display(Name = "Producto")]
        [Required(ErrorMessage = "El campo Producto es obligatorio")]
        public string ProductName { get; set; }
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo Precio es obligatorio")]
        public decimal UnitPrice { get; set; }
    }
}