using KataBankOCR.AccountFileProcessors;
using KataBankOCR.Models;
using System;

namespace KataBankOCR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IAccountFileProcessor accountFileProcessor = new OcrFileProcessor();

            string filePath = "../../App_Data/accounts.txt";
            Account[] processedAccounts = accountFileProcessor.Process(filePath);
                        
            foreach (Account account in processedAccounts)
            {
                Console.WriteLine(account.ToString());
            }

            Console.ReadLine();
        }
    }
}