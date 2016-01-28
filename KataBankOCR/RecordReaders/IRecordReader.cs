using KataBankOCR.Models;

namespace KataBankOCR.RecordReaders
{
    public interface IRecordReader
    {
        Record[] Read(string filePath);
    }
}