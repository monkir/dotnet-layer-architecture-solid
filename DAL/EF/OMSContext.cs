using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace DAL.EF
{
    public class OMSContext:DbContext
    {
        //public OMSContext(DbContextOptions<OMSContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true);
            var dbConnectionInfo = builder.Build().GetSection("ConnectionStrings").GetSection("mssql").Value;
            optionsBuilder.UseMySQL(dbConnectionInfo);
            //optionsBuilder.UseMySQL("server=localhost; port=3500; database=OMS;user=root;password=tiger");
            //optionsBuilder.UseSqlServer("server=MONKIR\\SQLEXPRESS; initial catalog=Office Management System; integrated security=true; TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("server=DESKTOP-T8I7D7N\\SQLEXPRESS; initial catalog=OMS; integrated security=true; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Admin>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);*/
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Admin)
                .WithMany(a => a.Employees)
                .HasForeignKey(e => e.AdminId)
                .IsRequired();
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
