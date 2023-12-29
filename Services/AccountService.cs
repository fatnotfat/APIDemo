using BusinessObjects;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> CheckLoginAsync(string email, string password)
        {
            return await _accountRepository.CheckLoginAsync(email, password);
        }

        public async Task<IEnumerable<Account>> GetAllAccountAsync()
        {
            return await _accountRepository.GetAccountsAsync();
        }

        public async Task RegistAccountAsync(Account account)
        {
            await _accountRepository.AddAccountAsync(account);
        }
    }
}
