using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Shop.Persistence.Repositories.Interfaces;
using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Persistence.Repositories.Interfaces { 
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> NameExistsAsync(string name);
        Task<bool> IsNameEditAllowedAsync(string name, ulong id);
        Task<Product?> GetByNameAsync(string name);
    }
}