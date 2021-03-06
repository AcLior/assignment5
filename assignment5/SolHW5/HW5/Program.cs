using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    class Program
    {
        static void Main()
        {
            const int size = 5;
            string accountname;
            double limit,amount;
            double currenamount;
            char choice;
            Bank b=new Bank(size);
           
            do
            {
                Console.WriteLine("Choose what to do:\nA)Add account\nB)Add Business account\nC)Close account\nF)Close Business account\nD)Deposit\nW)Withdraw\nM)Month elapsed\nX)Print Assets\nL)Print Details\nE)Exit");
                choice = char.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 'A':
                       
                        Console.WriteLine("Enter account name");
                        accountname = Console.ReadLine();
                        Console.WriteLine("Enter account amount");
                        currenamount = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter limit");
                        limit = double.Parse(Console.ReadLine());
                        BankAccount account = new BankAccount(accountname, currenamount, limit);
                        try
                        {
                            b.AddAccount(account);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Bank account array is full");

                        }
                        break;
                    case 'B':

                        Console.WriteLine("Enter account name");
                        accountname = Console.ReadLine();
                        Console.WriteLine("Enter account amount");
                        currenamount = double.Parse(Console.ReadLine());
                        BusinessBankAccount accountb = new BusinessBankAccount(accountname, currenamount);
                        try
                        {
                            b.AddAccount(accountb);
                        }
                        
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Bank account array is full");

                        }
                       
                        break;

                    case 'C':
                        Console.WriteLine("Enter account name");
                        accountname = Console.ReadLine();
                       
                        try
                        {
                            b.CloseBankAccount(b.GetBankAccount(accountname));

                        }
                        catch(ArgumentException)
                        {
                            Console.WriteLine("Bank account couldn't be found");
                        }
                        break;

                    case 'F':

                        Console.WriteLine("Enter account name");
                        accountname = Console.ReadLine();
                        
                        try
                        {
                            b.CloseBankAccount(b.GetBusinessBankAccount(accountname));
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Bank account couldn't be found");

                        }
                        break;

                    case 'D':
                        int num;

                        Console.WriteLine("Enter type of account: \n1.Regular\n2.Business");
                        num = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter account name");
                        accountname = Console.ReadLine();
                        Console.WriteLine("Enter the amount");
                        amount = double.Parse(Console.ReadLine());

                        try
                        {
                            if (num == 1)
                            {
                                b.GetBankAccount(accountname).Deposit(amount);
                            }
                            else
                            {
                                b.GetBusinessBankAccount(accountname).Deposit(amount);
                            }
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Cannot add negative value");
                        }

                        break;

                    case 'W':

                        Console.WriteLine("Enter type of account: 1.Regular\n2.Business");
                        num = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter account name");
                        accountname = Console.ReadLine();
                        Console.WriteLine("Enter the amount");
                        amount = double.Parse(Console.ReadLine());
                        try
                        {
                            if (num == 1)
                            {
                                b.GetBankAccount(accountname).Withdraw(amount);
                            }
                            else
                            {
                                b.GetBusinessBankAccount(accountname).Withdraw(amount);
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("Error: cannot withraw a value greater than the limit"); 
                        }
                        break;


                    case 'M':
                        Console.WriteLine("Enter account name");
                        accountname = Console.ReadLine();
                        b.GetBusinessBankAccount(accountname).MonthElapsed();
                        break;

                    case 'X':
                        Console.WriteLine("Assets: " + b.GetAssets());
                        break;

                    case 'L':
                        b.PrintDetails();
                        break;

                    case 'E': break;
                }

                
            } while (choice != 'E');
        }
    }
}
