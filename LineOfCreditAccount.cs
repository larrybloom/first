using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }

        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) :
            base(name, initialBalance, -creditLimit)
        {
            
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                //negate the balance to get a positive interest charge:
                decimal interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Interest charge");
            }

        }

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
            isOverdrawn
            ? new Transaction(-20, DateTime.Now, "apply overdraft fee") : default;
    }
}
