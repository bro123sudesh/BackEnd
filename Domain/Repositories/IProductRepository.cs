﻿using ApiProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddAsync(Product product);
        Task<Product> FindByIdAsync(int id);
        void Update(Product product);
        void Remove(Product product);
    }
}
