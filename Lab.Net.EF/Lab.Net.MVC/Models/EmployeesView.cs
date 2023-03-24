using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Lab.Net.MVC.Models
{
    public class EmployeesView
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string LastName { get; set; }
    }
}