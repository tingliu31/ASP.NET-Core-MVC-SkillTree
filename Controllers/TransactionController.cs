using System.ComponentModel.DataAnnotations;
using System.Transactions;
using Homework_SkillTree.Models;
using Homework_SkillTree.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Homework_SkillTree.Controllers
{
    public class TransactionController(ITransactionService service) : Controller
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
            ViewBag.TypeList = GetTransactionTypeList();

            // 檢查日期是否為未來
            if (pageData.Date > DateOnly.FromDateTime(DateTime.Today))
            {
                ModelState.AddModelError(nameof(pageData.Date), "日期不能晚於今天");
            }

            if (!ModelState.IsValid)
            {
                return View(pageData);
            }

            // 資料驗證成功，寫入資料庫
            service.AddAsync(pageData);
            return RedirectToAction("Index");
        }

        public IActionResult Index(int page = 1)
        {
            var pageSize = 20;
            var result = service.GetPagedAsync(page, pageSize).Result; // 這裡使用非同步方法獲取資料
            return View(result);
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
