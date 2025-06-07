﻿using Web_Shop.Persistence.Repositories.Interfaces;

namespace Web_Shop.Persistence.UOW.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }

        IGenericRepository<T> Repository<T>() where T : class;

        IProductRepository ProductRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);

        Task Rollback();
    }
}
