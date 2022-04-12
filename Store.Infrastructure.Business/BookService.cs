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
    public class BookService : IBookService
    {

        private readonly IBookRepository repository;
        private readonly ICategoryRepository categoryRepository;

        public BookService(IBookRepository repository, ICategoryRepository categoryRepository)
        {
            this.repository = repository;
            this.categoryRepository = categoryRepository;
        }

        public Book Create(Book book)
        {
            return repository.Create(book);
        }

        
        public Book GetById(string id)
        {
            return repository.GetById(id);
        }

        public void Update(Book book)
        {
            repository.Update(book);
        }

        public void Delete(string id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return repository.GetAll();
        }

        public IEnumerable<Book> RangeByPriceMin()
        {
            var books = repository.GetAll().ToList().OrderBy(c => c.Price);
            return books;
        }

        public IEnumerable<Book> RangeByPriceMax()
        {
            var books = repository.GetAll().ToList().OrderBy(c => c.Price).Reverse();
            return books;
        }
    }
}
