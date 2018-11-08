using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CharlieBankApp.Models;
using CharlieBankApp.Data;

namespace CharlieBankApp.Controllers
{
    public class HomeController : Controller
    {
        private BankRepostitory BankRepo;
        public HomeController(BankRepostitory _BankRepo)
        {
            BankRepo = _BankRepo;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel() { Customers = BankRepostitory.CustomerList };
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
