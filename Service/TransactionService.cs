using Homework_SkillTree.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.EF;


namespace Homework_SkillTree.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly MyDbContext _context;

        public TransactionService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransactionViewModel>> GetAllAsync()
        {
            return await _context.Transactions
                .OrderByDescending(t => t.Date)
                .Select(t => new TransactionViewModel
                {
                    TransactionType = t.TransactionType,
                    Date = DateOnly.FromDateTime(t.Date),
                    Amount = t.Amount,
                    Remark = t.Remark
                })
                .ToListAsync();
        }

        public async Task<IPagedList<TransactionViewModel>> GetPagedAsync(int page, int pageSize)
        {
            var query = _context.Transactions.AsNoTracking();

            // Convert query to IPagedList using ToPagedListAsync
            var result = await query
                .Select(t => new TransactionViewModel
                {
                    TransactionType = t.TransactionType,
                    Date = DateOnly.FromDateTime(t.Date),
                    Amount = t.Amount,
                    Remark = t.Remark
                })
                .OrderByDescending(t => t.Date)
                .ToPagedListAsync(page, pageSize);

            return result;
        }

        public async Task AddAsync(TransactionViewModel viewModel)
        {
            var entity = new Transaction
            {
                TransactionType = viewModel.TransactionType,
                Date = viewModel.Date.ToDateTime(TimeOnly.MinValue),
                Amount = viewModel.Amount,
                Remark = viewModel.Remark
            };

            _context.Transactions.Add(entity);
            await _context.SaveChangesAsync(); //不行
        }
    }
}
