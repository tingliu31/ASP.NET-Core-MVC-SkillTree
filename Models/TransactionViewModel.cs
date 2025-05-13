using System.ComponentModel.DataAnnotations;

namespace Homework_SkillTree.Models
{
    public class TransactionViewModel
    {
  
        [Display(Name = "類別")]
        public TransactionType TransactionType { get; set; }

        [Display(Name = "日期")]
        public DateOnly Date { get; set; }

        [Display(Name = "金額")]
        public int Amount { get; set; }

        [Display(Name = "備註")]
        public string? Remark { get; set; }
    }

}
