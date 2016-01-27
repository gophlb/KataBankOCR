using KataBankOCR.AccountNumberCheckers;
using KataBankOCR.AccountPostProcessors;
using KataBankOCR.RecordReaders;
using KataBankOCR.RecordToAccountParsers;
using KataBankOCR.Utils;

namespace KataBankOCR.AccountFileProcessors
{
    public class OcrFileProcessor : AbstractAccountFileProcessor
    {
        
        public override string[] ExtractRecords(string filePath)
        {
            OcrFileReader ocrFileReader = new OcrFileReader();
            IRecordReader recordReader = new DashPipeRecordReader();
            string[] records = ocrFileReader.ExtractRecordsFrom(filePath, recordReader);

            return records;
        }

        public override string[] ParseRecordsToAccounts(string[] records)
        {
            IRecordToAccountParser recordToAccountParser = new DashPipeRecordToAccountParser();
            string[] accounts = recordToAccountParser.Parse(records);
            return accounts;
        }
        
        public override string[] PostProcessAccounts(string[] accounts)
        {
            IAccountNumberChecker accountNumberChecker = new ChecksumAccountNumberChecker();
            IAccountPostProcessor accountPostProcessor = new CheckNumberValidityAccountPostProcessor(accountNumberChecker);
            string[] processedAccounts = accountPostProcessor.Process(accounts);
            return processedAccounts;
        }
    }
}