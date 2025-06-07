using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Shop.Persistence.Repositories.Interfaces;
using WWSI_Shop.Persistence.MySQL.Context;
using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(WwsishopContext context) : base(context) { }

        public async Task<bool> NameExistsAsync(string name)
        {
            return await Entities.AnyAsync(e => e.Name == name);
        }

        public async Task<bool> IsNameEditAllowedAsync(string name, ulong id)
        {
            return !await Entities.AnyAsync(e => e.Name == name && e.IdProduct != id);
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            return await Entities.FirstOrDefaultAsync(e => e.Name == name);
        }

    }
}