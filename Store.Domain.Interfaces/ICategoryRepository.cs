using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Core.Entities;

namespace Store.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Category Create(Category category);
        Category GetById(int id);
        void Update(Category category);
        void Delete(int id);
        IEnumerable<Category> GetAll();
    }
}
