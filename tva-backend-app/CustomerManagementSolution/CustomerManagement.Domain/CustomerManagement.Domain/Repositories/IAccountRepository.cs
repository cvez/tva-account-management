using CustomerManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Repositories
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Get account by id
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// 

        Task<Account> GetByIdAsync(int code);
        Task<IEnumerable<Account>> GetAllAsync();
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Account account);

    }
}
