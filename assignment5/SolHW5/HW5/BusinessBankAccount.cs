using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    
    class BusinessBankAccount : BankAccount
    {
        
       readonly int negativeInterest;


        public BusinessBankAccount(string accountName, double currentAmount) : base(accountName, currentAmount, Int32.MinValue)
        {
            
            negativeInterest = 3;
        }

        public void MonthElapsed()
        {
            if (CurrentAmount < 0) 
            {
                currentAmount += currentAmount * (negativeInterest / 100);
            }
        }
        public new string PrintAccount()
        {
            return base.PrintAccount() + "\nNegative interest: " + negativeInterest+"\n";
        }
    }
}
