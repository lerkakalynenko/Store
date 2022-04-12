using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Core.Entities;
using Store.Domain.Interfaces;
using Store.Services.Interfaces;

namespace Store.Infrastructure.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public Category Create(Category category)
        {
            return repository.Create(category);
        }

        public Category GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Category category)
        {
            repository.Update(category);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return repository.GetAll();
        }
    }
}
