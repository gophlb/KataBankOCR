using System;
using System.Linq;

namespace KataBankOCR.AccountNumberCheckers
{
    public class ChecksumAccountNumberChecker : IAccountNumberChecker
    {
        private int[] coefficients = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        
        public ValidityCodes.Codes CheckValidity(string accountNumber)
        {
            try
            {
                int result = coefficients.Zip(accountNumber, (c, a) => c * Convert.ToInt32(Char.GetNumericValue(a))).Sum();

                if (result % 11 == 0)
                {
                    return ValidityCodes.Codes.VALID;
                }
                return ValidityCodes.Codes.ERROR;
            }
            catch (Exception)
            {
                return ValidityCodes.Codes.ILLEGIBLE;
            }
        }
    }
}