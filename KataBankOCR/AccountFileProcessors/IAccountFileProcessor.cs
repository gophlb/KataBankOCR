using KataBankOCR.Models;
using System.Collections.Generic;

namespace KataBankOCR.AccountFileProcessors
{
    public interface IAccountFileProcessor
    {
        List<Account> Process(string filePath);
    }
}