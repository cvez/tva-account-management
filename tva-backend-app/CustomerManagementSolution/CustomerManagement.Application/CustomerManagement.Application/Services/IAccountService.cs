using CustomerManagement.Application.DTOs;
using CustomerManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services
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
