using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Bank
    {
        readonly BankAccount[] bankAccount;
        readonly BusinessBankAccount[] businessBankAccount;
        int numOfBA;
        int numOfBBA;

        public Bank(int size)
        {
            bankAccount = new BankAccount[size];
            businessBankAccount = new BusinessBankAccount[size];
            numOfBA = 0;
            numOfBBA = 0;
        }

        public void AddAccount(BankAccount b)
        {
            if (bankAccount.Length==numOfBA)
            {
                throw new IndexOutOfRangeException();
            }
            bankAccount[numOfBA++] = b;
        }
        public void AddAccount(BusinessBankAccount b)
        {
            if (businessBankAccount.Length==numOfBBA)
            {
                throw new IndexOutOfRangeException();
            }
            businessBankAccount[numOfBBA++] = b;
        }
        public BankAccount GetBankAccount(string name)
        {
            foreach (BankAccount b in bankAccount)
            {
                if (b.accountName==name)
                {
                    return b;
                }
            }
            throw new ArgumentException("Bank account with the provided name couldn't be found");
            
        }
        public BusinessBankAccount GetBusinessBankAccount(string name)
        {
            foreach (BusinessBankAccount b in businessBankAccount)
            {
                if (b.accountName == name)
                {
                    return b;
                }
            }
            throw new ArgumentException("Business bank account with the provided name couldn't be found");
        }
        public  void CloseBankAccount(BankAccount b)
        {
            int index = 0;
            foreach (BankAccount ba in bankAccount)
            {
                index++;
                if (b.Equals(ba) && ba.CurrentAmount == 0)
                {
                    for (int i = index - 1; i < bankAccount.Length; i++)
                    {
                        bankAccount[i] = bankAccount[i + 1];
                    }
                    return;
                }
                else if (b.Equals(ba) && ba.CurrentAmount != 0)
                {
                    throw new ArgumentException("Cannot shut an account which hasn't 0 funds");
                }
            }
            throw new ArgumentException();
        }
        public void CloseBankAccount(BusinessBankAccount b)
        {
            int index = 0;
            foreach (BusinessBankAccount bba in businessBankAccount)
            {
                index++;
                if (b.Equals(bba) && bba.CurrentAmount == 0)
                {
                    for (int i = index - 1; i < businessBankAccount.Length; i++)
                    {
                        businessBankAccount[i] = businessBankAccount[i + 1];
                    }
                    return;
                }
                else if (b.Equals(bba) && bba.CurrentAmount != 0)
                {
                    throw new ArgumentException("Cannot shut an account which hasn't got 0 funds");
                }
            }
            throw new ArgumentException();
        }
        public void MonthElapsed()
        {
            foreach (BusinessBankAccount bba in businessBankAccount)
            {
                bba.MonthElapsed();
            }
        }

       public string PrintBalance(int accountNum)
        {
            for(int i = 0; i < numOfBA; i++)
            {
                if (bankAccount[i].AccountNum == accountNum)
                {
                    return "Account Number: " + bankAccount[i].AccountNum.ToString() + "Current Amount: " + bankAccount[i].CurrentAmount + "\n";
                }
            }
            for (int i = 0; i < numOfBBA; i++)
            {
                if (businessBankAccount[i].AccountNum == accountNum)
                {
                    return "Account Number: " + businessBankAccount[i].AccountNum.ToString() + "Current Amount: " + businessBankAccount[i].CurrentAmount + "\n";
                }
            }
            throw new ArgumentException("Bank account couldn't be found"); ;
        }

        public void PrintDetails()
        {
            for(int i = 0; i < numOfBA; i++)
            {
                Console.WriteLine(bankAccount[i].PrintAccount()); 

            }

            for (int i = 0; i < numOfBBA; i++)
            {
                Console.WriteLine(businessBankAccount[i].PrintAccount());
                

            }

           
        }

        public double GetAssets()
        {
            double counter = 0;
            
            for(int i = 0; i<numOfBA; i++)
            {
                counter += bankAccount[i].CurrentAmount;
            }
            for(int i = 0; i < numOfBBA; i++)
            {
                counter += businessBankAccount[i].CurrentAmount;
            }
            return counter;
        }
    }
    
}
