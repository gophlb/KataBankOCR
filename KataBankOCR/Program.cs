using KataBankOCR.AccountFileProcessors;
using System;

namespace KataBankOCR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IAccountFileProcessor accountFileProcessor = new OcrFileProcessor();

            string filePath = "../../App_Data/accounts.txt";
            string[] processedAccounts = accountFileProcessor.Process(filePath);
                        
            foreach (string account in processedAccounts)
            {
                Console.WriteLine(account);
            }

            Console.ReadLine();
        }
    }
}