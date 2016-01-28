using KataBankOCR.AccountNumberCheckers;
using KataBankOCR.AccountPostProcessors;
using KataBankOCR.Models;
using KataBankOCR.RecordReaders;
using KataBankOCR.RecordToAccountParsers;

namespace KataBankOCR.AccountFileProcessors
{
    public class OcrFileProcessor : AbstractAccountFileProcessor
    {
        
        public override Record[] ExtractRecords(string filePath)
        {
            IRecordReader recordReader = new DashPipeRecordReader();
            Record[] records = recordReader.Read(filePath);

            return records;
        }

        public override Account[] ParseRecordsToAccounts(Record[] records)
        {
            IRecordToAccountParser recordToAccountParser = new DashPipeRecordToAccountParser();
            Account[] accounts = recordToAccountParser.Parse(records);
            return accounts;
        }
        
        public override Account[] PostProcessAccounts(Account[] accounts)
        {
            IAccountNumberChecker accountNumberChecker = new ChecksumAccountNumberChecker();
            IAccountPostProcessor accountPostProcessor = new CheckNumberValidityAccountPostProcessor(accountNumberChecker);
            Account[] processedAccounts = accountPostProcessor.Process(accounts);
            return processedAccounts;
        }
    }
}