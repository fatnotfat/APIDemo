using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class MedicalRecord
    {
        public Guid RecordID { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public DateTime ExaminationDate { get; set;}
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public int Status { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
