using KataBankOCR.Models;
using System.Collections.Generic;

namespace KataBankOCR.AccountFileProcessors
{
    public abstract class AbstractAccountFileProcessor : IAccountFileProcessor
    {
        public List<Account> Process(string filePath)
        {
            List<Record> records = ExtractRecords(filePath);
            List<Account> accounts = ParseRecordsToAccounts(records);
            List<Account> processedAccounts = PostProcessAccounts(accounts);

            return processedAccounts;
        }
        
        public abstract List<Record> ExtractRecords(string filePath);

        public abstract List<Account> ParseRecordsToAccounts(List<Record> records);

        public abstract List<Account> PostProcessAccounts(List<Account> accounts);
    }
}