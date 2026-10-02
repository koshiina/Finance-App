using FinanceApp.Data;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly FinanceAppContext _context;
        public ExpensesController(FinanceAppContext context)//leidzia interactint su database
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return View(expenses);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]//metodas, kuris siuncia duomenis i serveri, kad sukurti/apdorot duomenis
        //siuo atveju create sukuria expense ir nusiuncia i serveri kad sukurtu nauja expense
        //ir rodytu lenteleje
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(expense);
        }
    }
}
