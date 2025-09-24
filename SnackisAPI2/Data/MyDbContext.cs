using Microsoft.EntityFrameworkCore;
using SnackisAPI.Models;

namespace SnackisAPI.Data;

public class MyDbContext : DbContext
{
    

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {        
    }

    public DbSet<Member> Member { get; set; }
    
    public DbSet<Post> Post { get; set; }
    public DbSet<SubPost> SubPost { get; set; }
    
}
