using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAccountService 
    {
        public Task<IEnumerable<Account>> GetAllAccountAsync();
        public Task<Account> CheckLoginAsync(string email, string password);
        public Task RegistAccountAsync(Account account);
    }
}
