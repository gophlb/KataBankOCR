namespace KataBankOCR.RecordReaders
{
    public interface IRecordReader
    {
        string[] Read(string[] allLines);
    }
}