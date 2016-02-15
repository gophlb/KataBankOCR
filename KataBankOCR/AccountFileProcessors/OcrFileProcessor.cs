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
            IRecordReader recordReader = GetRecordReader();
            List<Record> records = recordReader.Read(filePath);

            return records;
        }

        protected override List<Account> ParseRecordsToAccounts(List<Record> records)
        {
            IRecordToAccountParser recordToAccountParser = GetRecordToAccountParser();
            List<Account> accounts = recordToAccountParser.Parse(records);
            return accounts;
        }

        protected override List<Account> PostProcessAccounts(List<Account> accounts)
        {
            IAccountNumberChecker accountNumberChecker = GetAccountNumberChecker();
            AbstractAccountPostProcessor accountPostProcessor = GetAccountPostProcessor(accountNumberChecker);
            List<Account> processedAccounts = accountPostProcessor.Process(accounts);

            return processedAccounts;
        }



        protected override IRecordReader GetRecordReader()
        {
            return new DashPipeRecordReader();
        }

        protected override IRecordToAccountParser GetRecordToAccountParser()
        {
            return new DashPipeRecordToAccountParser();
        }

        protected override IAccountNumberChecker GetAccountNumberChecker()
        {
            return new ChecksumAccountNumberChecker();
        }

        protected override AbstractAccountPostProcessor GetAccountPostProcessor(IAccountNumberChecker accountNumberChecker)
        {
            return new CheckNumberValidityAccountPostProcessor(accountNumberChecker);
        }

    }
}