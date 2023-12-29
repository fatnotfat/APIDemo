using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.FluentAPIs
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");
            builder.HasKey(x => x.DoctorID);
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Specialty).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.HasIndex(x => x.PhoneNumber).IsUnique();


            builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Doctor)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.MedicalRecords)
            .WithOne(x => x.Doctor)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Account>(x => x.Account);
        }
    }
}
