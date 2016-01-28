using KataBankOCR.Models;
using KataBankOCR.Utils;
using System;
using System.Linq;

namespace KataBankOCR.AccountNumberCheckers
{
    public class ChecksumAccountNumberChecker : IAccountNumberChecker
    {
        private int[] coefficients = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

        public ValidityCodes.Codes CheckValidity(Account account)
        {
            string accountNumber = account.Number;

            if (accountNumber.IndexOf('?') != -1)
            {
                return ValidityCodes.Codes.ILLEGIBLE;
            }

            int result = coefficients.Zip(accountNumber, (c, a) => c * Convert.ToInt32(Char.GetNumericValue(a))).Sum();

            if (result % 11 == 0)
            {
                return ValidityCodes.Codes.VALID;
            }

            return ValidityCodes.Codes.ERROR;
        }
    }
}