namespace KataBankOCR.RecordToAccountParsers
{
    public class DashPipeRecordToAccountParser : IRecordToAccountParser
    {
        private const int LineLength = 27;
        private const int DigitWidth = 3;

        
        public string[] Parse(string[] records)
        {
            int numberOfRecords = records.Length;
            string[] parsedAccounts = new string[numberOfRecords];

            for (int i = 0; i < numberOfRecords; i++)
            {
                parsedAccounts[i] = Parse(records[i]);
            }

            return parsedAccounts;
        }



        public string Parse(string record)
        {
            string accountNumber = "";
            DashPipeDigitParser dashPipeNumberExtractor = new DashPipeDigitParser();

            char[] line1, line2, line3;
            int initialPosition = 0;
            for (int currentDigit = 0; currentDigit < 9; currentDigit++)
            {
                initialPosition = currentDigit * DigitWidth;
                line1 = record.Substring(initialPosition, DigitWidth).ToCharArray();
                line2 = record.Substring(initialPosition + LineLength, DigitWidth).ToCharArray();
                line3 = record.Substring(initialPosition + (2 * LineLength), DigitWidth).ToCharArray();

                accountNumber += dashPipeNumberExtractor.Parse(line1, line2, line3);
            }

            return accountNumber;
        }
    }
}