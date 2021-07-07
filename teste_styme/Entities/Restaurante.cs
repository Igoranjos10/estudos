using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace teste_styme.Entities
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string ImageUri { get; set; }
        //[Required(ErrorMessage = "Please choose profile image")]
        //[Display(Name = "Profile Picture")]
        [NotMapped]
        public IFormFile ProfileImage { get; set; }
    }

    public class RestaurantModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string ImageUri { get; set; }
        //[Required(ErrorMessage = "Please choose profile image")]
        //[Display(Name = "Profile Picture")]
        [NotMapped]
        public IFormFile ProfileImage { get; set; }
    }

}
