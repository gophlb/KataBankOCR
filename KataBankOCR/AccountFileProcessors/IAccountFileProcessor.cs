namespace KataBankOCR.AccountFileProcessors
{
    public interface IAccountFileProcessor
    {
        string[] Process(string filePath);

        string[] ExtractRecords(string filePath);

        string[] ParseRecordsToAccounts(string[] records);

        string[] PostProcessAccounts(string[] accounts);
    }
}