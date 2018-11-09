using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using CharlieBankApp.Data;
using CharlieBankApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharlieBankApp.Controllers
{
    public class BankActionController : Controller
    {
        private BankRepostitory BankRepo;
        public BankActionController(BankRepostitory _BankRepo)
        {
            BankRepo = _BankRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepositOrWithdraw(string btn, BankActionIndexViewModel vm)
        {
            string result;
            if (btn.Length > 5)
            {

                result = BankRepo.BankDeposit(vm.AccountNumber, vm.Amount);
            }
            else
            {
                result = BankRepo.BankWithdraw(vm.AccountNumber, vm.Amount);
            }

            var newVm = new BankActionIndexViewModel()
            {
                Message = result
            };
            return View("Index", newVm);
        }

        public IActionResult Transfer()
        {
            TransferViewModel vm = new TransferViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Transfer(TransferViewModel vm)
        {
            
            if (!ModelState.IsValid)
            {
                vm.Message = "Överföring misslyckades! Se över kontouppgifterna igen";
                return View(vm);
            };
            
            if (BankRepostitory.GetAccountFromAccountNumber(vm.FromAccountId) == null)
            {
                vm.Message = "Överföring misslyckades! Se över kontouppgifterna igen";
            }
            else
            {
                vm.Message = BankRepostitory.GetAccountFromAccountNumber(vm.FromAccountId).Transfer(vm.ToAccountId, (int)vm.Amount);

            }

            return View(vm);
        }
    }
}