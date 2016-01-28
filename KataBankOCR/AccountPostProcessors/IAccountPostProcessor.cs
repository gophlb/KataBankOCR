using KataBankOCR.Models;
using System.Collections.Generic;

namespace KataBankOCR.AccountPostProcessors
{
    public interface IAccountPostProcessor
    {
        List<Account> Process(List<Account> accounts);
    }
}