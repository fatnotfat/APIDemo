using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class AccountDAO
    {
        private readonly Health360SchedulerDBContext _dbContext;

        public AccountDAO()
        {
            _dbContext = new Health360SchedulerDBContext();
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

        public async Task<Account> CheckAccountAsync(string email, string password)
        {
            var account = await _dbContext.Accounts
                .FirstOrDefaultAsync(a => a.Email.Equals(email.Trim()) 
                && a.Password.Equals(password.Trim()));
            return account;
        }

        public async Task AddNewAsync(Account account)
        {
            try
            {
                _dbContext.Accounts.Add(account);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
