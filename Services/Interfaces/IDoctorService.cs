using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        public Task<Doctor> GetDoctorByAccountId(Guid accountId);
    }
}
