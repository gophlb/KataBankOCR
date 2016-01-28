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
        protected override List<Record> ExtractRecords(string filePath)
        {
            IRecordReader recordReader = new DashPipeRecordReader();
            List<Record> records = recordReader.Read(filePath);

            return records;
        }

        protected override List<Account> ParseRecordsToAccounts(List<Record> records)
        {
            IRecordToAccountParser recordToAccountParser = new DashPipeRecordToAccountParser();
            List<Account> accounts = recordToAccountParser.Parse(records);
            return accounts;
        }

        protected override List<Account> PostProcessAccounts(List<Account> accounts)
        {
            IAccountNumberChecker accountNumberChecker = new ChecksumAccountNumberChecker();
            AbstractAccountPostProcessor accountPostProcessor = new CheckNumberValidityAccountPostProcessor(accountNumberChecker);
            List<Account> processedAccounts = accountPostProcessor.Process(accounts);

            return processedAccounts;
        }
    }
}