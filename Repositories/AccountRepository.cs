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
    public class AccountRepository : IAccountRepository
    {
        private AccountDAO accountDAO;
        public AccountRepository()
        {
            accountDAO = new AccountDAO();
        }
        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await accountDAO.GetAllAsync();
        }

        public async Task<Account> CheckLoginAsync(string email, string password)
        {
            return await accountDAO.CheckAccountAsync(email, password);
        }

        public async Task AddAccountAsync(Account account)
        {
            await accountDAO.AddNewAsync(account);
        }


    }
}
