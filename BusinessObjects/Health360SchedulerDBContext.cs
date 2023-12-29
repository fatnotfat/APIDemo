using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects
{
    public partial class Health360SchedulerDBContext : DbContext
    {
        public Health360SchedulerDBContext()
        {
        }
        public Health360SchedulerDBContext(DbContextOptions<Health360SchedulerDBContext> opt) : base(opt) { }

        public virtual DbSet<Patient>? Patients { get; set; }
        public virtual DbSet<Doctor>? Doctors { get; set; }
        public virtual DbSet<Appointment>? Appointments { get; set; }
        public virtual DbSet<MedicalRecord>? MedicalRecords { get; set; }
        public virtual DbSet<Account>? Accounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }


        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config["ConnectionStrings:DB"]!;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Take all configurations of entities from Infrastructures.FluentAPIs
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }

}

