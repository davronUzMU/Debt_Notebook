using Debt_Notebook.Model.DoMain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Debt_Notebook.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
           : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
            //base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Debt> Debts { get; set; }

        public DbSet<SendSMSMessage> SendSMS { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<State> State { get; set; }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Debt>().
                HasOne(o => o.User).
                WithMany(d => d.Debts).
                HasForeignKey(o => o.UserId);

            modelBuilder.Entity<User>().
                HasOne(l => l.organization).
                WithMany(k => k.Customers).
                HasForeignKey(l => l.OrganizationId);

            modelBuilder.Entity<User>()
               .HasOne(u => u.UserState)
               .WithOne()
               .HasForeignKey<User>(u => u.StateId);


            modelBuilder.Entity<Organization>()
                .HasOne(o => o.State)
                .WithOne()
                .HasForeignKey<Organization>(o => o.StateId);



            base.OnModelCreating(modelBuilder);
        }
    }
}
