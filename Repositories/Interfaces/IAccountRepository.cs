using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Task<IEnumerable<Account>> GetAccountsAsync();
        public Task<Account> CheckLoginAsync(string email, string password);
        public Task AddAccountAsync(Account account);
    }
}
