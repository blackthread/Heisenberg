using Heisenberg.Application.Contracts;
using Heisenberg.Domain.Common;
using Heisenberg.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Heisenberg.Persistence
{
    public  class HeisenbergDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public HeisenbergDbContext(DbContextOptions<HeisenbergDbContext> options, ILoggedInUserService loggedInUserService)
           : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        /*
        set persistence as startup
        in package manager console
        run add-migration initial
        run update-database
        */
        public HeisenbergDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-9MEGBOCG; Database = HeisenbergDb; Trusted_Connection = True;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

        


        public DbSet<ToDoItem> ToDoItems { get; set; }

        public DbSet<ToDoList> ToDoLists { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HeisenbergDbContext).Assembly);

            // Users dummy data
            modelBuilder.Entity<User>().HasData(
                new User { ID = 1, Name = "User1", Email = "user1@example.com", Password = "Password1" },
                new User { ID = 2, Name = "User2", Email = "user2@example.com", Password = "Password2" }
            );

            // ToDoLists dummy data
            modelBuilder.Entity<ToDoList>().HasData(
                new ToDoList { ID = 1, Title = "User1's ToDoList", UserID = 1 },
                new ToDoList { ID = 2, Title = "User2's ToDoList", UserID = 2 }
            );

            // ToDoItems dummy data
            modelBuilder.Entity<ToDoItem>().HasData(
                new ToDoItem { ID = 1, Description = "Task 1", DueDate = DateTime.Now.AddDays(1), IsComplete = false, ToDoListID = 1 },
                new ToDoItem { ID = 2, Description = "Task 2", DueDate = DateTime.Now.AddDays(2), IsComplete = false, ToDoListID = 1 },
                new ToDoItem { ID = 3, Description = "Task 3", DueDate = DateTime.Now.AddDays(3), IsComplete = false, ToDoListID = 2 }
            );
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
