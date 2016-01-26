using KataBankOCR.RecordReaders;
using KataBankOCR.RecordToAccountParsers;
using KataBankOCR.Utils;
using System;

namespace KataBankOCR
{
    public class Program
    {
        public static void Main(string[] args)
        {               
            OcrFileReader ocrFileReader = new OcrFileReader();
            IRecordReader recordReader = new DashPipeRecordReader();
            string filePath = "../../App_Data/accounts.txt";
            string[] records = ocrFileReader.ExtractRecordsFrom(filePath, recordReader);

            IRecordToAccountParser recordToAccountParser = new DashPipeRecordToAccountParser();
            string[] accounts = recordToAccountParser.Parse(records);

            foreach (string account in accounts)
            {
                Console.WriteLine(account);
            }

            Console.ReadLine();
        }
    }
}
