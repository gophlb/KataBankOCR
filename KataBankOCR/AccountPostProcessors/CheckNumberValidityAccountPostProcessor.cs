using KataBankOCR.AccountNumberCheckers;
using KataBankOCR.Models;
using KataBankOCR.Utils;

namespace KataBankOCR.AccountPostProcessors
{
    public class CheckNumberValidityAccountPostProcessor : IAccountPostProcessor
    {        
        private IAccountNumberChecker accountNumberChecker;

        public CheckNumberValidityAccountPostProcessor(IAccountNumberChecker accountNumberChecker)
        {
            this.accountNumberChecker = accountNumberChecker;
        }


        public Account[] Process(Account[] accounts)
        {
            int numberOfAccounts = accounts.Length;
            Account[] processedAccounts = new Account[numberOfAccounts];
            Account currentAccount;
            ValidityCodes.Codes checkNumberResult;

            for (int i = 0; i < numberOfAccounts; i++)
            {
                currentAccount = accounts[i];
                checkNumberResult = accountNumberChecker.CheckValidity(currentAccount);

                currentAccount.ValidityCode = checkNumberResult;

                processedAccounts[i] = currentAccount;
            }

            return processedAccounts;
        }
    }
}