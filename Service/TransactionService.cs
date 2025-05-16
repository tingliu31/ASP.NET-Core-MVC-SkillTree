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
                .AsNoTracking()
                .Select(t => new TransactionViewModel
                {
                    TransactionType = t.TransactionType,
                    Date = DateOnly.FromDateTime(t.Date),
                    Amount = t.Amount,
                    Remark = t.Remark
                })
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }

        public async Task<IPagedList<TransactionViewModel>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Transactions
                .AsNoTracking()
                .Select(t => new TransactionViewModel
                {
                    TransactionType = t.TransactionType,
                    Date = DateOnly.FromDateTime(t.Date),
                    Amount = t.Amount,
                    Remark = t.Remark
                })
                .OrderByDescending(t => t.Date)
                .ToPagedListAsync(page, pageSize);
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
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // 可依需求記錄 log 或拋出自訂例外
                throw new Exception("新增資料時發生錯誤", ex);
            }
        }

    }
}
