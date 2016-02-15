using KataBankOCR.AccountNumberCheckers;
using KataBankOCR.AccountPostProcessors;
using KataBankOCR.Models;
using KataBankOCR.RecordReaders;
using KataBankOCR.RecordToAccountParsers;
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
        
        protected abstract List<Record> ExtractRecords(string filePath);

        protected abstract List<Account> ParseRecordsToAccounts(List<Record> records);

        protected abstract List<Account> PostProcessAccounts(List<Account> accounts);

        protected abstract IRecordReader GetRecordReader();

        protected abstract IRecordToAccountParser GetRecordToAccountParser();

        protected abstract IAccountNumberChecker GetAccountNumberChecker();

        protected abstract AbstractAccountPostProcessor GetAccountPostProcessor(IAccountNumberChecker accountNumberChecker);
    }
}