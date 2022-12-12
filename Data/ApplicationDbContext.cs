using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using csharp_diary.Models;

namespace csharp_diary.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<csharp_diary.Models.Diary> Diary { get; set; } = default!;
}

//note to self maybe no auto log in feature so i can get used to it, and then i can do specfic things with the api routes??
