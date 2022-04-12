using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Core.Entities;

namespace Store.Services.Interfaces
{
    public interface ICategoryService
    {
        Category Create(Category category);
        Category GetById(int id);
        void Update(Category category);
        void Delete(int id);
        IEnumerable<Category> GetAll();
    }
}
