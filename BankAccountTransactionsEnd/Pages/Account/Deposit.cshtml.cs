using BankAccountTransactionsEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankAccountTransactionsEnd.Pages.Account
{
    [BindProperties]
    public class DepositModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DepositModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public decimal Amount { get; set; }
        public DateTime DepositDate { get; set; }
        public string Comment { get; set; }
        
        public void OnGet(int accountId)
        {
            DepositDate = DateTime.Now;
        }

        public IActionResult OnPost(int accountId)
        {
            var accountDb = _accountService.GetAccount(accountId);
            accountDb.Balance += Amount;
            _accountService.Update(accountDb);
            return RedirectToPage("Index");
        }
    }
}
