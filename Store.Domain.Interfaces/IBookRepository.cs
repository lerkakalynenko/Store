using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Core.Entities;

namespace Store.Domain.Interfaces
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book GetById(string id);
        void Update(Book book);
        void Delete(string id);
        IEnumerable<Book> GetAll();
    }
}
