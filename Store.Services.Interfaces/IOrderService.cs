using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Store.Domain.Core.Entities;




namespace Store.Services.Interfaces
{
    public interface IOrderService
    {
        Order Create(Order order);
        Order GetById(int id);
        void Delete(int id);
        void Update(Order order);
        ICollection<Order> GetAll();
        List<Order> GetOrders(ISession session, out decimal totalPrice);
        void AddProductToOrder(ISession session, string id);
        void RemoveProductFromOrder(ISession session, string id);
    }
}
