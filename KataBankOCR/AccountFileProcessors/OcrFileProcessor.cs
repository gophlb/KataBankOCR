using KataBankOCR.AccountNumberCheckers;
using KataBankOCR.AccountPostProcessors;
using KataBankOCR.Models;
using KataBankOCR.RecordReaders;
using KataBankOCR.RecordToAccountParsers;
using System.Collections.Generic;

namespace KataBankOCR.AccountFileProcessors
{
    public class OcrFileProcessor : AbstractAccountFileProcessor
    {
        
        public override List<Record> ExtractRecords(string filePath)
        {
            IRecordReader recordReader = new DashPipeRecordReader();
            List<Record> records = recordReader.Read(filePath);

            return records;
        }

        public override List<Account> ParseRecordsToAccounts(List<Record> records)
        {
            IRecordToAccountParser recordToAccountParser = new DashPipeRecordToAccountParser();
            List<Account> accounts = recordToAccountParser.Parse(records);
            return accounts;
        }
        
        public override List<Account> PostProcessAccounts(List<Account> accounts)
        {
            IAccountNumberChecker accountNumberChecker = new ChecksumAccountNumberChecker();
            IAccountPostProcessor accountPostProcessor = new CheckNumberValidityAccountPostProcessor(accountNumberChecker);
            List<Account> processedAccounts = accountPostProcessor.Process(accounts);

            return processedAccounts;
        }
    }
}