using KataBankOCR.Models;

namespace KataBankOCR.AccountFileProcessors
{
    public interface IAccountFileProcessor
    {
        Account[] Process(string filePath);

        Record[] ExtractRecords(string filePath);

        Account[] ParseRecordsToAccounts(Record[] records);

        Account[] PostProcessAccounts(Account[] accounts);
    }
}