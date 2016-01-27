using KataBankOCR.AccountNumberCheckers;
using System.Collections.Generic;

namespace KataBankOCR.AccountPostProcessors
{
    public class CheckNumberValidityAccountPostProcessor : IAccountPostProcessor
    {
        private Dictionary<ValidityCodes.Codes, string> Suffixes = new Dictionary<ValidityCodes.Codes, string>
        {
            [ValidityCodes.Codes.VALID] = "",
            [ValidityCodes.Codes.ERROR] = " ERR",
            [ValidityCodes.Codes.ILLEGIBLE] = " ILL"
        };

        private IAccountNumberChecker accountNumberChecker;

        public CheckNumberValidityAccountPostProcessor(IAccountNumberChecker accountNumberChecker)
        {
            this.accountNumberChecker = accountNumberChecker;
        }


        public string[] Process(string[] accounts)
        {
            int numberOfAccounts = accounts.Length;
            string[] processedAccounts = new string[numberOfAccounts];
            string currentAccount = "";
            ValidityCodes.Codes checkNumberResult;
            for (int i = 0; i < numberOfAccounts; i++)
            {
                currentAccount = accounts[i];
                checkNumberResult = accountNumberChecker.CheckValidity(currentAccount);
                processedAccounts[i] = currentAccount + Suffixes[checkNumberResult];
            }

            return processedAccounts;
        }
    }
}
