using KataBankOCR.Models;

namespace KataBankOCR.AccountPostProcessors
{
    public interface IAccountPostProcessor
    {
        Account[] Process(Account[] accounts);
    }
}