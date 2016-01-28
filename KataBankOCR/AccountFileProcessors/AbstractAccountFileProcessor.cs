using KataBankOCR.Models;

namespace KataBankOCR.AccountFileProcessors
{
    public abstract class AbstractAccountFileProcessor : IAccountFileProcessor
    {
        public Account[] Process(string filePath)
        {
            Record[] records = ExtractRecords(filePath);
            Account[] accounts = ParseRecordsToAccounts(records);
            Account[] processedAccounts = PostProcessAccounts(accounts);

            return processedAccounts;
        }
        
        public abstract Record[] ExtractRecords(string filePath);

        public abstract Account[] ParseRecordsToAccounts(Record[] records);

        public abstract Account[] PostProcessAccounts(Account[] accounts);
    }
}