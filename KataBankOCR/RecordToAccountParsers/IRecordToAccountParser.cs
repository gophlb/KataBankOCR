using KataBankOCR.Models;
using System.Collections.Generic;

namespace KataBankOCR.RecordToAccountParsers
{
    public interface IRecordToAccountParser
    {
        List<Account> Parse(List<Record> records);

        Account Parse(Record record);
    }
}