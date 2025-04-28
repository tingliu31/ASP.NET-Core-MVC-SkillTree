using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework_SkillTree.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public TransactionType TransactionType { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal Amount { get; set; }

        public string? Remark { get; set; }
    }

}
