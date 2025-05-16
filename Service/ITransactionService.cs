using Homework_SkillTree.Models;
using X.PagedList;

namespace Homework_SkillTree.Service
{
    public interface ITransactionService
    {
        Task<List<TransactionViewModel>> GetAllAsync();
        Task<IPagedList<TransactionViewModel>> GetPagedAsync(int page, int pageSize);
        Task AddAsync(TransactionViewModel viewModel);
    }
}
