using KataBankOCR.Models;
using System.Collections.Generic;
using System.Linq;

namespace KataBankOCR.RecordToAccountParsers
{
    public class DashPipeRecordToAccountParser : IRecordToAccountParser
    {
        private const int DigitWidth = 3;

        
        public List<Account> Parse(List<Record> records)
        {
            List<Account> parsedAccounts = records.Select(r => Parse(r)).ToList();
            
            return parsedAccounts;
        }
        
        public Account Parse(Record record)
        {
            DashPipeDigitParser dashPipeNumberExtractor = new DashPipeDigitParser();

            char[] line1, line2, line3;
            int initialPosition = 0;
            string recordContent = record.Content;
            int lineLength = record.LineLength;
            
            string accountNumber = "";
            for (int currentDigit = 0; currentDigit < 9; currentDigit++)
            {
                initialPosition = currentDigit * DigitWidth;
                line1 = recordContent.Substring(initialPosition, DigitWidth).ToCharArray();
                line2 = recordContent.Substring(initialPosition + lineLength, DigitWidth).ToCharArray();
                line3 = recordContent.Substring(initialPosition + (2 * lineLength), DigitWidth).ToCharArray();

                accountNumber += dashPipeNumberExtractor.Parse(line1, line2, line3);
            }

            return new Account
            {
                Number = accountNumber,
                OriginalPreParsed = recordContent
            };
        }
    }
}