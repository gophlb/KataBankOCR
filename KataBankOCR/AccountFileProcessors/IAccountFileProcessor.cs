using KataBankOCR.Models;
using System.Collections.Generic;

namespace KataBankOCR.AccountFileProcessors
{
    public interface IAccountFileProcessor
    {
        List<Account> Process(string filePath);

        List<Record> ExtractRecords(string filePath);

        List<Account> ParseRecordsToAccounts(List<Record> records);

        List<Account> PostProcessAccounts(List<Account> accounts);
    }
}