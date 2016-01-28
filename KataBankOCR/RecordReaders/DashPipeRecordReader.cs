using KataBankOCR.Models;
using System.Collections.Generic;
using System.IO;

namespace KataBankOCR.RecordReaders
{
    public class DashPipeRecordReader : IRecordReader
    {
        private const int LinesPerRecord = 4;
        private const int LineLength = 27;


        public List<Record> Read(string filePath)
        {
            string[] allLines = GetAllContentFrom(filePath);
            List<Record> records = ReadRecords(allLines);

            return records;
        }

        private List<Record> ReadRecords(string[] allLines)
        {
            int numberOfRecords = allLines.Length / LinesPerRecord;
            List<Record> records = new List<Record>(numberOfRecords);

            int currentLine = 0;
            for (int i = 0; i < numberOfRecords; i++)
            {
                records.Add(new Record
                {
                    Content = allLines[currentLine] + allLines[currentLine + 1] + allLines[currentLine + 2] + allLines[currentLine + 3],
                    LineLength = LineLength,
                    NumberOfLines = LinesPerRecord
                });

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