using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using teste_styme.Entities;
using teste_styme.Service;

namespace teste_styme.Controllers
{
    [Route("api/Restaurante")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly ServiceRestaurant _serviceRestaurant;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RestaurantController(ServiceRestaurant serviceRestaurant, IWebHostEnvironment webHostEnvironment)
        {
            _serviceRestaurant = serviceRestaurant;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var menu = await _serviceRestaurant.List(name);


            return Ok(menu);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post([FromForm] RestaurantModel restaurant)
        {
            var restaurantResponse = await _serviceRestaurant.Create(restaurant);
            return Ok(restaurantResponse);
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Put([FromForm] RestaurantModel restaurant)
        {
            var restaurantResponse = await _serviceRestaurant.Edit(restaurant);
            return Ok(restaurantResponse);
        }
    }
}
