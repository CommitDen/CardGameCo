using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CardGameCo.Models;

namespace CardGameCo.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<WordCard>? WordCards { get; set; }
    public DbSet<User>? AspNetUsers { get; set; }
}

