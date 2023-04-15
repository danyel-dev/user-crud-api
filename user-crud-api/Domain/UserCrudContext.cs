using Microsoft.EntityFrameworkCore;
using user_crud_api.Domain.Model;

namespace user_crud_api.Domain;

public class UserCrudContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserCrudContext(DbContextOptions options) : base(options)
    {
        
    }
}
