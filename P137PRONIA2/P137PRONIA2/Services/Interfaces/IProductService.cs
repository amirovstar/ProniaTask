using System;
using P137PRONIA2.Models;
using P137PRONIA2.ViewModels.ProductVMs;

namespace P137PRONIA2.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAll(bool takeAll);
        public Task<Product> GetById(int? id);
        Task Create(CreateProductVM productVM);
       
        Task Delete(int? id);
        Task SoftDelete(int? id);
        IQueryable<Product> GetTable { get; }
    }
}

