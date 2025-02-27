using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _repository;
        private readonly IMapper _mapper;

        public AccountService(IRepository<Account> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAccounts()
        {
            var accounts = await _repository.GetAll();
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }

        public async Task<AccountDto> GetAccountById(int id)
        {
            var account = await _repository.GetById(id);
            return _mapper.Map<AccountDto>(account);
        }

        public async Task<AccountDto> AddAccount(AccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            account = await _repository.Add(account);
            return _mapper.Map<AccountDto>(account);
        }

        public async Task<AccountDto> UpdateAccount(AccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            account = await _repository.Update(account);
            return _mapper.Map<AccountDto>(account);
        }

        public async Task<bool> DeleteAccount(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
