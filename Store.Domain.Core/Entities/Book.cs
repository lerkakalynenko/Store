using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Core.Entities
{
    public class Book
    {
        public string Id { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PhotoPath { get; set; }
        public virtual Category Category { get; set; }

    }
}
