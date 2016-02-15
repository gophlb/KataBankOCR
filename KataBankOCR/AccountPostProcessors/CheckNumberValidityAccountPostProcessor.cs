using KataBankOCR.AccountNumberCheckers;
using KataBankOCR.Models;
using System.Collections.Generic;
using System.Linq;

namespace KataBankOCR.AccountPostProcessors
{
    public class CheckNumberValidityAccountPostProcessor : AbstractAccountPostProcessor
    {        
        private IAccountNumberChecker accountNumberChecker;


        public CheckNumberValidityAccountPostProcessor(IAccountNumberChecker accountNumberChecker)
        {
            this.accountNumberChecker = accountNumberChecker;
        }


        protected override List<Account> ProcessAccounts(List<Account> accounts)
        {
            List<Account> processedAccounts = accounts.Select(a => new Account
            {
                Number = a.Number,
                OriginalPreParsed = a.OriginalPreParsed,
                ValidityCode = accountNumberChecker.CheckValidity(a)
            }).ToList();

            return processedAccounts;
        }
    }
}