using HelpDesk.Data.Entities;
using HelpDesk.Data.Seeder;
using System.Data.Entity;

namespace HelpDesk.Data
{
    public class HelpDeskDbContext : DbContext
    {
        public HelpDeskDbContext() : base("DefaultConnection")
        {
            if (Database.CreateIfNotExists())
                new HelpDeskSeeder(this).SeedAll();
        }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentType> IncidentTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}