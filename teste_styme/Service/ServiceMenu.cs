using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_styme.Data;
using teste_styme.Entities;

namespace teste_styme.Service
{
    public class ServiceMenu
    {
        private readonly TesteStymeContext _context;
        public ServiceMenu(TesteStymeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> List(string name)
        {
            if (name != null)
            {
                var menu = _context.Menus.Include(_ => _.Restaurant).Where(_ => _.Restaurant.Name.Contains(name));

                return menu;
            }
            else
            {
                return await _context.Menus.ToListAsync();
            }

        }
    }
}
