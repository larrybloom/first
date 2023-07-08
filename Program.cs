using System;
using ConsoleApp1;


var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "get coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();
//can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "needed to pay monthly bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());

var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
//how much is too much to borrow?
lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "take out monthly balance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "pay back small amount");
lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for reapairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());


namespace ConsoleApp1
{

    public class Program
    {

        
        static void Main(string[] args)
        {
            var account = new BankAccount("Larry", 100);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance."); ;
            account.MakeDeposit(100, DateTime.Now, "Friend paid back");
            Console.WriteLine(account.Balance);
            account.MakeWithdrawal(500, DateTime.Now, "rent");
            Console.WriteLine(account.Balance);

            // test that the initial balances must be positive
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("exception caught for creating account with negative balance");
                Console.WriteLine(e.ToString());
                return;
            }

            //test for a negative balance
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught to overdraw");
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine(account.GetAccountHistory());

           

        }
        
    }

} 