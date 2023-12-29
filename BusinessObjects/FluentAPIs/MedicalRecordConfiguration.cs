using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.FluentAPIs
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.ToTable("MedicalRecord");
            builder.HasKey(x => x.RecordID);
            builder.Property(x => x.Diagnosis).HasMaxLength(255).IsRequired();
            builder.Property(x => x.ExaminationDate).IsRequired();
            builder.Property(x => x.Prescription).HasMaxLength(255).IsRequired();
            builder.Property(x => x.DoctorID).IsRequired();
            builder.Property(x => x.PatientID).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
