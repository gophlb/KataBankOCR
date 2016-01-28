using KataBankOCR.AccountNumberCheckers;
using KataBankOCR.Models;
using KataBankOCR.Utils;
using System.Collections.Generic;
using System.Linq;

namespace KataBankOCR.AccountPostProcessors
{
    public class CheckNumberValidityAccountPostProcessor : IAccountPostProcessor
    {        
        private IAccountNumberChecker accountNumberChecker;

        public CheckNumberValidityAccountPostProcessor(IAccountNumberChecker accountNumberChecker)
        {
            this.accountNumberChecker = accountNumberChecker;
        }


        public List<Account> Process(List<Account> accounts)
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