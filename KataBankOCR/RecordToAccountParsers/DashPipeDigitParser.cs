using KataBankOCR.Utils;
using System;
using System.Collections.Generic;

namespace KataBankOCR.RecordToAccountParsers
{
    public class DashPipeDigitParser
    {
        private const string IllegibleDigit = "?";

        private Dictionary<string, string> numbers = new Dictionary<string, string>
        {
            [OcrNumbers.ZERO] = "0",
            [OcrNumbers.ONE] = "1",
            [OcrNumbers.TWO] = "2",
            [OcrNumbers.THREE] = "3",
            [OcrNumbers.FOUR] = "4",
            [OcrNumbers.FIVE] = "5",
            [OcrNumbers.SIX] = "6",
            [OcrNumbers.SEVEN] = "7",
            [OcrNumbers.EIGHT] = "8",
            [OcrNumbers.NINE] = "9"
        };

        public string Parse(char[] line1, char[] line2, char[] line3)
        {
            string numberString = Convert.ToString(line1[0]) + Convert.ToString(line1[1]) + Convert.ToString(line1[2]) +
                                  Convert.ToString(line2[0]) + Convert.ToString(line2[1]) + Convert.ToString(line2[2]) +
                                  Convert.ToString(line3[0]) + Convert.ToString(line3[1]) + Convert.ToString(line3[2])
                                  ;

            string digit;
            if (numbers.TryGetValue(numberString, out digit))
            {
                return digit;
            }
            return IllegibleDigit;
        }
    }
}
