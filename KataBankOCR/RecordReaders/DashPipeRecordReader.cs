namespace KataBankOCR.RecordReaders
{
    public class DashPipeRecordReader : IRecordReader
    {
        private const int LinesPerRecord = 4;

        
        public string[] Read(string[] allLines)
        {
            int numberOfRecords = allLines.Length / LinesPerRecord;
            string[] records = new string[numberOfRecords];

            int currentLine = 0;
            for (int i = 0; i < numberOfRecords; i++)
            {
                records[i] = allLines[currentLine] + allLines[currentLine + 1] + allLines[currentLine + 2];

                currentLine += LinesPerRecord;
            }

            return records;
        }
    }
}