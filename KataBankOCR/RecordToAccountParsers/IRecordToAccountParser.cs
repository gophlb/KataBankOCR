namespace KataBankOCR.RecordToAccountParsers
{
    public interface IRecordToAccountParser
    {
        string[] Parse(string[] records);

        string Parse(string record);
    }
}