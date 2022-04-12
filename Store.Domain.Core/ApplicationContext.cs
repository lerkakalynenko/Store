using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Core.Entities;

namespace Store.Domain.Core
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
       
            public DbSet<Category> Categories { get; set; }
            public DbSet<Book> Books { get; set; }

            public ApplicationContext()
            {

            }
            public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
            {
                Database.EnsureCreated();

            }
        }
}
