using System.ComponentModel.DataAnnotations;

namespace Homework_SkillTree.Models
{
    public enum TransactionType
    {
        [Display(Name = "收入")]
        Income = 0,

        [Display(Name = "支出")]
        Expense = 1
    }
}
