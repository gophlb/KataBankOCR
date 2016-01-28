using KataBankOCR.Models;
using KataBankOCR.Utils;

namespace KataBankOCR.AccountNumberCheckers
{
    public interface IAccountNumberChecker
    {
        ValidityCodes.Codes CheckValidity(Account account);
    }
}