using FinanceApp.Data;
using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesServicecs _expensesServ;
        public ExpensesController(IExpensesServicecs expensesServ)//leidzia interactint su database
        {
            _expensesServ = expensesServ;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _expensesServ.GetAll();
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
                await _expensesServ.Add(expense);

                return RedirectToAction("Index");
            }
            return View(expense);
        }
        public IActionResult GetChart()
        {

        }
    }
}
