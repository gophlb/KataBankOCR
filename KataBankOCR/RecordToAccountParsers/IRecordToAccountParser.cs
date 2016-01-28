using KataBankOCR.Models;

namespace KataBankOCR.RecordToAccountParsers
{
    public interface IRecordToAccountParser
    {
        Account[] Parse(Record[] records);

        Account Parse(Record record);
    }
}