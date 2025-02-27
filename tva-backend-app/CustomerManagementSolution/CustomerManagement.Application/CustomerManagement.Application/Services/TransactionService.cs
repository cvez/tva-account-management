using CustomerManagement.Application.DTOs;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _repository;
        private readonly IMapper _mapper;

        public TransactionService(IRepository<Transaction> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransactions()
        {
            var transactions = await _repository.GetAll();
            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public async Task<TransactionDto> GetTransactionById(int id)
        {
            var transaction = await _repository.GetById(id);
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<TransactionDto> AddTransaction(TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);
            transaction = await _repository.Add(transaction);
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<TransactionDto> UpdateTransaction(TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);
            transaction = await _repository.Update(transaction);
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<bool> DeleteTransaction(int id)
        {
            return await _repository.Delete(id);
        }

    }
}
