using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using teste_styme.Data;
using teste_styme.Entities;

namespace teste_styme.Service
{
    public class ServiceRestaurant
    {
        private readonly TesteStymeContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceRestaurant(TesteStymeContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IEnumerable<Restaurant>> List(string name)
        {
            if (name != null)
            {
                var merchant = await _context.Restaurantes.Where(_ => _.Name.Contains(name)).ToListAsync();

                return merchant;
            }
            else
            {
                return await _context.Restaurantes.ToListAsync();
            }


        }

        public async Task<RestaurantModel> Create(RestaurantModel restaurant)
        {
            string uniqueFileName = UploadedFile(restaurant);
            restaurant.ImageUri = uniqueFileName;

            var restaurantbanco = new Restaurant()
            {
                Name = restaurant.Name,
                Address = restaurant.Address,
                Category = restaurant.Category,
                ImageUri = restaurant.ImageUri,
                Location = restaurant.Location,
                ProfileImage = restaurant.ProfileImage,
            };

            await _context.AddAsync(restaurantbanco);
            await _context.SaveChangesAsync();
            return restaurant;

        }

        public async Task<RestaurantModel> Edit(RestaurantModel restaurant, int restaurantId = 1)
        {
            var restaurantrequest = _context.Restaurantes.Find(restaurantId);


            string uniqueFileName = UploadedFile(restaurant);
            restaurant.ImageUri = uniqueFileName;


            restaurantrequest.Name = restaurant.Name;
            restaurantrequest.Address = restaurant.Address;
            restaurantrequest.Category = restaurant.Category;
            restaurantrequest.ImageUri = restaurant.ImageUri;
            restaurantrequest.Location = restaurant.Location;
            restaurantrequest.ProfileImage = restaurant.ProfileImage;

            _context.Update(restaurantrequest);
            await _context.SaveChangesAsync();
            return restaurant;

        }

        private string UploadedFile(RestaurantModel restaurant)
        {
            string uniqueFileName = null;

            if (restaurant.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + restaurant.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = File.Create(filePath))
                {
                    restaurant.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
