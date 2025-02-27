using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllTransactions();
        Task<TransactionDto> GetTransactionById(int id);
        Task<TransactionDto> AddTransaction(TransactionDto transactionDto);
        Task<TransactionDto> UpdateTransaction(TransactionDto transactionDto);
        Task<bool> DeleteTransaction(int id);
    }
}
