namespace KataBankOCR.AccountFileProcessors
{
    public abstract class AbstractAccountFileProcessor : IAccountFileProcessor
    {
        public string[] Process(string filePath)
        {
            string[] records = ExtractRecords(filePath);
            string[] accounts = ParseRecordsToAccounts(records);
            string[] processedAccounts = PostProcessAccounts(accounts);

            return processedAccounts;
        }
        
        public abstract string[] ExtractRecords(string filePath);

        public abstract string[] ParseRecordsToAccounts(string[] records);

        public abstract string[] PostProcessAccounts(string[] accounts);
    }
}