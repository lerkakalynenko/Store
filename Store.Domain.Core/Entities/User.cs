﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Store.Domain.Core.Entities
{
    
        public class User : IdentityUser
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            
        }
    
}
