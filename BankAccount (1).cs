using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManager
{
    public class BankAccount
    {
        public string Owner { get; private set; }
        public decimal Balance { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsClosed { get; private set; }
        public BankAccount(string owner)
        {
            Owner = owner;
            Balance = 0;
            IsActive = false;
            IsClosed = true;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.");
            Balance += amount;

            if (!IsActive)
            {
                IsActive = true;
                Console.WriteLine("Account reactivated");
            }
        }
        public bool Withdraw(decimal amount, bool identityVerified)
        {
            if (IsClosed) throw new InvalidOperationException("Account is closed.");
            if (!IsActive) throw new InvalidOperationException("Account is inactive.");
            if (!identityVerified) throw new UnauthorizedAccessException("Identity verification required.");
            if (amount > Balance) throw new InvalidOperationException("Insufficient fund.");

            Balance -= amount;
            return true;
        }

        public void CloseAccount()
        { 
            IsClosed = true;
            IsActive = false;
        }
        public void DeactivateAccount() 
        {
            if (!IsClosed) IsActive = false;
        }
    }
    
}
