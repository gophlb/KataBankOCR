using KataBankOCR.Models;
using System.IO;

namespace KataBankOCR.RecordReaders
{
    public class DashPipeRecordReader : IRecordReader
    {
        private const int LinesPerRecord = 4;
        private const int LineLength = 27;


        public Record[] Read(string filePath)
        {
            string[] allLines = GetAllContentFrom(filePath);
            Record[] records = ReadRecords(allLines);

            return records;
        }

        private Record[] ReadRecords(string[] allLines)
        {
            int numberOfRecords = allLines.Length / LinesPerRecord;
            Record[] records = new Record[numberOfRecords];

            int currentLine = 0;
            for (int i = 0; i < numberOfRecords; i++)
            {
                records[i] = new Record
                {
                    Content = allLines[currentLine] + allLines[currentLine + 1] + allLines[currentLine + 2] + allLines[currentLine + 3],
                    LineLength = LineLength,
                    NumberOfLines = LinesPerRecord
                };

                currentLine += LinesPerRecord;
            }

            return records;
        }

        private string[] GetAllContentFrom(string filePath)
        {
            string[] allLines = File.ReadAllLines(filePath);
            return allLines;
        }
    }
}