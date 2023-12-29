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
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(x => x.AppointmentID);
            builder.Property(x => x.AppointmentDate).IsRequired();
            builder.Property(x => x.Notes).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PatientID).IsRequired();
            builder.Property(x => x.DoctorID).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
