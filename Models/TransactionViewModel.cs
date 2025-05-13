using System.ComponentModel.DataAnnotations;

namespace Homework_SkillTree.Models
{
    public class TransactionViewModel
    {
        [Required(ErrorMessage = "請選擇類別")]
        [Display(Name = "類別")]
        public TransactionType TransactionType { get; set; }

        [Required(ErrorMessage = "請選擇日期")]
        [DataType(DataType.Date)]
        [Display(Name = "日期")]
        [CustomValidation(typeof(TransactionViewModel), nameof(ValidateDateNotFuture))]
        public DateOnly Date { get; set; }

        [Required(ErrorMessage = "請輸入金額")]
        [Range(1, int.MaxValue, ErrorMessage = "金額必須為正整數")]
        [Display(Name = "金額")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "請輸入備註")]
        [StringLength(100, ErrorMessage = "備註最多只能輸入 100 個字")]
        [Display(Name = "備註")]
        public string Remark { get; set; }

        public static ValidationResult? ValidateDateNotFuture(DateOnly date, ValidationContext context)
        {
            if (date > DateOnly.FromDateTime(DateTime.Today))
            {
                return new ValidationResult("日期不能大於今天");
            }

            return ValidationResult.Success;
        }
    }

}
