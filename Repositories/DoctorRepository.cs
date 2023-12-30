using BusinessObjects;
using DataAccessObject;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private DoctorsDAO doctorDAO;
        public DoctorRepository()
        {
            doctorDAO = new DoctorsDAO();
        }

        public async Task<Doctor> GetDoctorByAccountId(Guid accountId)
        {
            return await doctorDAO.GetDoctorByAccountId(accountId);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await doctorDAO.GetAllAsync();
        }
    }
}
