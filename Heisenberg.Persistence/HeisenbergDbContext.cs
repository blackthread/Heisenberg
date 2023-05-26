using Heisenberg.Application.Contracts;
using Heisenberg.Domain.Common;
using Heisenberg.Domain.Entities;
using Heisenberg.Persistence.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Heisenberg.Persistence
{


    public class HeisenbergDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        // private readonly ILoggedInUserService _loggedInUserService;

           public HeisenbergDbContext(DbContextOptions<HeisenbergDbContext> options)
              : base(options)
           {
               //_loggedInUserService = loggedInUserService;
           }


        /*
        set persistence as startup
        in package manager console
        run add-migration initial
        run update-database
        */

        //    public HeisenbergDbContext(DbContextOptions<HeisenbergDbContext> options)
        //        : base(options)
        //    {
        //    }

        public DbSet<AppUser> Users { get; set; }

        public DbSet<ToDoItem> ToDoItems { get; set; }

 //       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //      {
  //          optionsBuilder.UseSqlServer("Server=LAPTOP-9MEGBOCG;Database=HeisenbergDb;Trusted_Connection=True;TrustServerCertificate=true;");
  //          base.OnConfiguring(optionsBuilder);
  //      }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");


            // Seed ToDoItems
            builder.Entity<ToDoItem>().HasData(
                new ToDoItem { ID = 1, Description = "Description 1", IsComplete = false, DueDate = DateTime.UtcNow },
                new ToDoItem { ID = 2, Description = "Description 2", IsComplete = false, DueDate = DateTime.UtcNow }
            // Add more seed data as needed
            );

            // Create a user that can login
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser
            {
                Id = "13",
                UserName = "YourUsername",
                NormalizedUserName = "YOURUSERNAME",
                Email = "your@email.com",
                NormalizedEmail = "YOUREMAIL@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "YourPassword")
            };

            builder.Entity<IdentityUser>().HasData(user);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                      //  entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        entry.Entity.CreatedBy = "Tron";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Steve";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }




    }

    
}
