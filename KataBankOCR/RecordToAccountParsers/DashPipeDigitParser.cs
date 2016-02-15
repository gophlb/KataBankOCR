using System;
using System.Collections.Generic;

namespace KataBankOCR.RecordToAccountParsers
{
    public class DashPipeDigitParser
    {
        private const string IllegibleDigit = "?";

        private static string ZERO = " _ " +
                                     "| |" +
                                     "|_|"
                                    ;

        private static string ONE = "   " +
                                    "  |" +
                                    "  |"
                                   ;

        private static string TWO = " _ " +
                                    " _|" +
                                    "|_ "
                                   ;

        private static string THREE = " _ " +
                                      " _|" +
                                      " _|"
                                     ;

        private static string FOUR = "   " +
                                     "|_|" +
                                     "  |"
                                    ;

        private static string FIVE = " _ " +
                                     "|_ " +
                                     " _|"
                                    ;

        private static string SIX = " _ " +
                                    "|_ " +
                                    "|_|"
                                    ;

        private static string SEVEN = " _ " +
                                      "  |" +
                                      "  |"
                                     ;

        private static string EIGHT = " _ " +
                                      "|_|" +
                                      "|_|"
                                    ;

        private static string NINE = " _ " +
                                     "|_|" +
                                     " _|"
                                    ;



        private Dictionary<string, string> numbers = new Dictionary<string, string>
        {
            [ZERO] = "0",
            [ONE] = "1",
            [TWO] = "2",
            [THREE] = "3",
            [FOUR] = "4",
            [FIVE] = "5",
            [SIX] = "6",
            [SEVEN] = "7",
            [EIGHT] = "8",
            [NINE] = "9"
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