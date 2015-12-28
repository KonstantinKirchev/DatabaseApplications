using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Pr05_06_ATMTransactions
    {
        static void Main(string[] args)
        {
            var context = new ATMEntities();
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    Console.Write("Enter card number: ");
                    var cardNumber = Console.ReadLine();

                    Console.Write("Enter PIN: ");
                    var pin = Console.ReadLine();

                    var num = context.CardAccounts.FirstOrDefault(a => a.CardNumber == cardNumber);

                    if (num == null)
                    {
                        throw new InvalidOperationException("Wrong CardNumber");
                    }

                    var cardpin = context.CardAccounts.FirstOrDefault(a => a.CardPIN == pin && a.CardNumber == cardNumber);

                    if (cardpin == null)
                    {
                        throw new InvalidOperationException("Invalid PIN.");
                    }


                    Console.Write("Enter amount: ");
                    var amount = decimal.Parse(Console.ReadLine());

                    if (amount < 0)
                    {
                        throw new InvalidOperationException("Enter positive amount.");
                    }

                    var account = context.CardAccounts.FirstOrDefault(a => a.CardPIN == pin && a.CardNumber == cardNumber);
                    
                    if (account.CardCash < amount)
                    {
                        throw new InvalidOperationException("Insufficient amount");
                    }

                    account.CardCash -= amount;

                    context.SaveChanges();

                    var history = new TransactionHistory
                    {
                        CardNumber = cardNumber,
                        TransactionDate = DateTime.Now,
                        Amount = amount
                    };

                    context.TransactionHistories.Add(history);

                    context.SaveChanges();

                    Console.WriteLine("Transaction successful!");

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
