namespace KataBankOCR.AccountNumberCheckers
{
    public interface IAccountNumberChecker
    {
        ValidityCodes.Codes CheckValidity(string accountNumber);
    }
}