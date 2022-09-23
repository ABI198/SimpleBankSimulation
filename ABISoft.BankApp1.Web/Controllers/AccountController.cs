 using ABISoft.BankApp1.Web.Data.Context;
using ABISoft.BankApp1.Web.Data.Entities;
using ABISoft.BankApp1.Web.Data.Interfaces;
using ABISoft.BankApp1.Web.Data.Repositories;
using ABISoft.BankApp1.Web.Data.UnitOfWork;
using ABISoft.BankApp1.Web.Mappings;
using ABISoft.BankApp1.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ABISoft.BankApp1.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _uow;
        public AccountController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult Create(int id)
        {
            var user = _uow.GetRepository<User>().GetById(id);
            var selectedUserListModel = new UserListModel()
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
            if (selectedUserListModel != null)
                return View(selectedUserListModel);
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _uow.GetRepository<Account>().Add(new Account() { 
                AccountNumber = accountCreateModel.AccountNumber,
                Balance = accountCreateModel.Balance,
                UserId = accountCreateModel.UserId
            });
            _uow.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ShowAccountsByUserId(int userId)
        {
            var accountQueryable = _uow.GetRepository<Account>().GetQueryable();
            var accountList = accountQueryable.Where(x => x.UserId == userId).ToList();
            var user = _uow.GetRepository<User>().GetById(userId);
            ViewBag.FullName = user.Firstname + " " + user.Lastname;
            var accoutShowModelList = new List<AccountShowModel>();
            foreach (var account in accountList)
            {
                accoutShowModelList.Add(new AccountShowModel()
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    UserId = account.UserId,
                });
            }
            return View(accoutShowModelList);
        }

        public IActionResult SendMoney(int accountId)
        {
            var accountQueryable = _uow.GetRepository<Account>().GetQueryable();
            var accountList = accountQueryable.Where(x => x.Id != accountId).ToList();
            ViewBag.SenderAccountId = accountId;

            //Mapping Operation
            var accountSendMoneyModelList = new List<AccountSendMoneyModel>();
            foreach (var account in accountList)
            {
                var user = _uow.GetRepository<User>().GetById(account.UserId);
                string fullName = user.Firstname + " " + user.Lastname;
                accountSendMoneyModelList.Add(new AccountSendMoneyModel()
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    UserId = account.UserId,
                    FullName = fullName,
                    SelectListValue = account.AccountNumber + " - " + fullName
                });
            }
            return View(new SelectList(accountSendMoneyModelList, "Id", "SelectListValue"));
        }
    
    
        [HttpPost]
        public IActionResult SendMoney(SendMoneyTransferModel model)
        {            
            var senderAccount = _uow.GetRepository<Account>().GetById(model.SenderAccountId);
            var receiverAccount = _uow.GetRepository<Account>().GetById(model.ReceiverAccountId);
            
            senderAccount.Balance -= model.Amount;
            _uow.GetRepository<Account>().Update(senderAccount);

            receiverAccount.Balance += model.Amount;
            _uow.GetRepository<Account>().Update(receiverAccount);

            _uow.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
