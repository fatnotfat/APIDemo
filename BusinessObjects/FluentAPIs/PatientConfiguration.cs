using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.FluentAPIs
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");
            builder.HasKey(x => x.PatientID);
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(255).IsRequired();
            builder.HasIndex(x => x.PhoneNumber).IsUnique();

            builder.HasMany(x => x.Appointments)
                .WithOne(x => x.Patient)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.MedicalRecords)
               .WithOne(x => x.Patient)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Account>(x => x.Account);

        }
    }
}
