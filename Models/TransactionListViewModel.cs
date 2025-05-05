namespace Homework_SkillTree.Models
{
    public class TransactionListViewModel
    {
        public List<TransactionViewModel> Transactions { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
