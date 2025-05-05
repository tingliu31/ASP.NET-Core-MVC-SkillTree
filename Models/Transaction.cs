using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework_SkillTree.Models
{
    [Table("AccountBook")]
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Categoryyy")]
        public TransactionType TransactionType { get; set; }

        [Column("Dateee")]
        public DateTime Date { get; set; }

        [Column("Amounttt")]
        public int Amount { get; set; }

        [Column("Remarkkk")]
        public string? Remark { get; set; }
    }

}
