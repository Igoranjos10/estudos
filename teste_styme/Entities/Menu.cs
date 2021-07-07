using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste_styme.Entities
{
    public class Menu
    {
        public int MenuId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int restaurantId { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public string imageUri { get; set; }
        public string category { get; set; }
    }
}
