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
                    TransactionType = TransactionType.Expense,
                    Date = new DateTime(2025, 1, 1),
                    Amount = 300
                },
                new TransactionViewModel
                {
                    TransactionType = TransactionType.Income,
                    Date = new DateTime(2025, 1, 2),
                    Amount = 1600
                },
                 new TransactionViewModel
                {
                     TransactionType = TransactionType.Expense,
                     Date = new DateTime(2025, 1, 3),
                    Amount = 800
                }
            };
            return View(transactions);
        }
    }
}
