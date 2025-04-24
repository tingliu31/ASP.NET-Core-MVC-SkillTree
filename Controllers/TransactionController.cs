using Homework_SkillTree.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework_SkillTree.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            var transactions = new List<TransactionViewModel>
            {
                new TransactionViewModel
                {
                    TransactionType = TransactionType.Income,
                    Date = new DateTime(2025, 1, 1),
                    Amount = 1600,
                    Remark = "設計費"
                    
                },
                new TransactionViewModel
                {
                    TransactionType = TransactionType.Expense,
                    Date = new DateTime(2025, 1, 2),
                    Amount = 300,
                    Remark = "下午茶"
                },
                 new TransactionViewModel
                {
                    TransactionType = TransactionType.Expense,
                    Date = new DateTime(2025, 1, 3),
                    Amount = 160,
                    Remark = "小火鍋"
                }
            };
            return View(transactions);
        }
    }
}
