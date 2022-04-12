using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Core.Entities;

namespace Store.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order Create(Order order);
        Order GetById(int id);
        void Delete(int id);
        void Update(Order order);
        ICollection<Order> GetAll();
    }
}
