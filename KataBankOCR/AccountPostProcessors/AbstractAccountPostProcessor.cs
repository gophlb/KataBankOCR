using System;
using System.Collections.Generic;
using KataBankOCR.Models;

namespace KataBankOCR.AccountPostProcessors
{
    public abstract class AbstractAccountPostProcessor
    {
        protected AbstractAccountPostProcessor accountPostProcessor;
        
        public List<Account> Process(List<Account> accounts)
        {
            List<Account> processedAccounts = ProcessAccounts(accounts);

            if (accountPostProcessor != null)
            {
                processedAccounts = accountPostProcessor.Process(processedAccounts);
            }

            return processedAccounts;
        }

        protected abstract List<Account> ProcessAccounts(List<Account> accounts);

        public void SetNextProcessor(AbstractAccountPostProcessor accountPostProcessor)
        {
            this.accountPostProcessor = accountPostProcessor;
        }
    }
}
