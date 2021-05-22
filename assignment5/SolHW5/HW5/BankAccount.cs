using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class BankAccount
    {
        public string accountName;
        readonly int accountNum = 0;
        protected double currentAmount;
        protected double limit;

        public BankAccount(string accountName, double currentAmount, double limit)
        {
            accountNum++;
            this.accountName = accountName;
            if (currentAmount < 0)
            {
                throw new ArgumentException("Current amount cannot be negative...");
            }
            else
            {
                this.currentAmount = currentAmount;

            }
            Limit = limit;
        }

        public string AccountName
        {
            get { return this.accountName; }
        }

        public int AccountNum
        {

            get { return this.accountNum; }
        
        }
        public double CurrentAmount
        {
            get => currentAmount;
        }
        public double Limit
        { 
            get => limit;
            set => limit = value;
        }

        public void Deposit(double amountToAdd)
        {
            if (amountToAdd<0)
            {
                throw new ArgumentException("Cannot add negative value");
            }
            else
            {
                this.currentAmount += amountToAdd;

            }
        }
        public void Withdraw(double amountToWithraw)
        {
            if (amountToWithraw<0)
            {
                throw new ArgumentException("Cannot withraw negative value");
            }
            else if ((limit>0&&amountToWithraw>limit+currentAmount)|| (limit < 0 && amountToWithraw > currentAmount - limit))
            {
                throw new InvalidOperationException("Error: cannot withraw a value greater than the limit");
            }
           
            currentAmount -= amountToWithraw;
        }
        public string PrintAccount()
        {
            return "Account name: " + accountName + "\nAccount number: " + accountNum + "\nCurrent amount: " + currentAmount + "\nLimit: " + limit+"\n";
        }
    }
}
