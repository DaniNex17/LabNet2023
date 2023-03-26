using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.Net.MVC.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public Origin Origin { get; set; }
        public Location Location { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }

        public void SetImageUrl()
        {
            if (Id > 0)
            {
                ImageUrl = $"https://rickandmortyapi.com/api/character/avatar/{Id}.jpeg";
            }
            else
            {
                ImageUrl = "https://img.freepik.com/iconos-gratis/jpg_318-148712.jpg";
            }
        }
    }
    public class Origin
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }


}