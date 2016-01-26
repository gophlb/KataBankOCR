using KataBankOCR.RecordReaders;
using System.IO;

namespace KataBankOCR.Utils
{
    public class OcrFileReader
    {
        public string[] ExtractRecordsFrom(string filePath, IRecordReader recordReader)
        {
            string[] allLines = File.ReadAllLines(filePath);
            string[] records = recordReader.Read(allLines);

            return records;
        }
    }
}