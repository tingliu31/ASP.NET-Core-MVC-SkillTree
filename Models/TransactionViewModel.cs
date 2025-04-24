using System.ComponentModel.DataAnnotations;

namespace Homework_SkillTree.Models
{

    public enum TransactionType
    {
        [Display(Name = "收入")]
        Income,
        [Display(Name = "支出")]
        Expense
    }

    public class TransactionViewModel
    {
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
    }

}
