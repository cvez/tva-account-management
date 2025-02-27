using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAccounts();
        Task<AccountDto> GetAccountById(int id);
        Task<AccountDto> AddAccount(AccountDto accountDto);
        Task<AccountDto> UpdateAccount(AccountDto accountDto);
        Task<bool> DeleteAccount(int id);
    }
}
