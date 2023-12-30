using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class DoctorsDAO
    {
        private readonly Health360SchedulerDBContext _dbContext;

        public DoctorsDAO()
        {
            _dbContext = new Health360SchedulerDBContext();
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _dbContext.Doctors.ToListAsync();
        }

        public void Add(Doctor doctor)
        {

        }

        public async Task<Doctor> GetDoctorByAccountId(Guid accountId)
        {
            Doctor doctor = null;
            if (String.IsNullOrEmpty(accountId.ToString().Trim())!)
            {
                doctor = await _dbContext.Doctors.SingleOrDefaultAsync(acc => acc.AccountId.Equals(accountId));
            }
            return doctor;
        }
    }
}
