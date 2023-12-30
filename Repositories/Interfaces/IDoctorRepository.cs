using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        public Task<IEnumerable<Doctor>> GetDoctorsAsync();
        public Task<Doctor> GetDoctorByAccountId(Guid accountId);
    }
}
