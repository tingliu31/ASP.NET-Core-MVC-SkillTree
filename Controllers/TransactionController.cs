using System.ComponentModel.DataAnnotations;
using System.Transactions;
using Homework_SkillTree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;
using X.PagedList.Extensions;

namespace Homework_SkillTree.Controllers
{
    public class TransactionController(MyDbContext context) : Controller
    {
        
        [HttpGet]
        public IActionResult Create()
        {
            // 建立新的 TransactionViewModel 物件
            var model = new TransactionViewModel
            {
                // 設定 Date 屬性的預設值為今天的日期
                Date = DateOnly.FromDateTime(DateTime.Now)
            };

            ViewBag.TypeList = GetTransactionTypeList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(TransactionViewModel pageData)
        {
            if (ModelState.IsValid)
            {
                ViewBag.TypeList = GetTransactionTypeList();
                return RedirectToAction("Index");
            }
            ViewBag.TypeList = GetTransactionTypeList();
            return View(pageData);
        }

        public IActionResult Index(int page = 1)
        {
            var pageSize = 20;

            var transactions = context.Transactions
                .OrderByDescending(t => t.Date)
                .Select(t => new TransactionViewModel
                {
                    TransactionType = t.TransactionType,
                    Date = DateOnly.FromDateTime(t.Date),
                    Amount = t.Amount,
                    Remark = t.Remark
                })
                .ToPagedList(page, pageSize); // 這裡套用分頁

            return View(transactions);
        }

        private List<SelectListItem> GetTransactionTypeList()
        {
            return Enum.GetValues(typeof(TransactionType))
                       .Cast<TransactionType>()
                       .Select(t => new SelectListItem
                       {
                           Value = t.ToString(),               // 用於表單送出
                           Text = GetDisplayName(t)            // 顯示中文名
                       })
                       .ToList();
        }

        private string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null)
                return value.ToString();

            var attr = field.GetCustomAttributes(typeof(DisplayAttribute), false)
                            .Cast<DisplayAttribute>()
                            .FirstOrDefault();

            return attr?.Name ?? value.ToString();
        }

    }
}
