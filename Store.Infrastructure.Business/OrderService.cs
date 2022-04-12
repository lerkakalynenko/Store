using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Store.Domain.Core.Entities;
using Store.Domain.Core.Entities.Helpers;
using Store.Domain.Interfaces;
using Store.Services.Interfaces;

namespace Store.Infrastructure.Business
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IBookRepository _bookRepository;

        public OrderService(IOrderRepository repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }

        public Order Create(Order order)
        {
            return _repository.Create(order);
        }

        public Order GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Update(Order order)
        {
            _repository.Update(order);
        }

        public ICollection<Order> GetAll()
        {
            return _repository.GetAll();
        }

        private const string SessionKey = "cart";

        public List<Order> GetOrders(ISession session, out decimal totalPrice)
        {
            var orders = session.GetSessionString<List<Order>>(SessionKey);
            totalPrice = (decimal) orders.Sum(order => order.Book.Price * order.Quantity);

            return orders;
        }

        public void AddProductToOrder(ISession session, string id)
        {
            var orders = session.GetSessionString<List<Order>>(SessionKey);

            if (orders == null)
            {
                AddProductToNewOrder(session, id);
            }
            else
            {
                AddProductToExistingOrder(session, orders, id);
            }
        }

        private void AddProductToNewOrder(ISession session, string id)
        {
            var cart = new List<Order>
            {
                CreateDemoOrder(id)
            };

            session.SetSessionString(SessionKey, cart);
        }

        private void AddProductToExistingOrder(ISession session, List<Order> cart, string id)
        {
            var index = GetProductIndex(cart, id);

            if (index == -1)
            {
                cart.Add(CreateDemoOrder(id));
            }
            else
            {
                cart[index].Quantity++;
            }

            session.SetSessionString(SessionKey, cart);
        }

        public void RemoveProductFromOrder(ISession session, string id)
        {
            var cart = session.GetSessionString<List<Order>>(SessionKey);
            var index = GetProductIndex(cart, id);

            if (index != -1)
            {
                cart.RemoveAt(index);
                session.SetSessionString(SessionKey, cart);
            }
        }

        private int GetProductIndex(List<Order> cart, string id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Book.Id.Equals(id))
                {
                    return i;
                }
            }

            return -1;
        }
        

        private Order CreateDemoOrder(string id) 
        {
            var book = _bookRepository.GetById(id);

            return new Order
            {
                Book = new Book
                {
                    Id = id,
                    BookName = book.BookName,
                    Description = book.Description,
                    Price = book.Price,
                    PhotoPath = "book1.png",
                    
                },
                Quantity = 1
            };
        }

    }
}
