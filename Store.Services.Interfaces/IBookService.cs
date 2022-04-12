using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Core.Entities;

namespace Store.Services.Interfaces
{
    public interface IBookService
    {
        Book Create(Book book);
        Book GetById(string id);
        void Update(Book book);
        void Delete(string id);
        IEnumerable<Book> GetAll();
        //IEnumerable<Book> RangeByCategory(Category category);
        IEnumerable<Book> RangeByPriceMin();
        IEnumerable<Book> RangeByPriceMax();
    }
}
