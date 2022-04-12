using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Core.Entities
{
    public class Order
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
