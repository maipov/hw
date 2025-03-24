using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    public class BankAccount
    {        
        public string Owner {  get; private set; }
        public decimal Balance { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsClosed {  get; private set; }

        public BankAccount(string owner)
        {
            Owner = owner;
            Balance = 0;
            IsActive = true;
            IsClosed = false;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be greater than 0");
            Balance += amount;

            if (!IsActive)
            {
                IsActive = true;
                Console.WriteLine("The account has been reactivated");
            }
        }
        public void Withdraw(decimal amount, bool identityVerified)
        {
            if (IsClosed) throw new InvalidOperationException("The account is closed");
            if (!IsActive) throw new InvalidOperationException("The account is inactive");
            if (!identityVerified) throw new UnauthorizedAccessException("Identity verification is required");
            if (amount > Balance) throw new InvalidOperationException("Insufficient balance");

            Balance -= amount;
            Console.WriteLine($"Successfully withdraw {amount} VND");
        }
        public void CloseAccount()
        {
            IsClosed = true;    
            IsActive = false;
            Console.WriteLine("The account has been closed");
        }
        public void DeactivateAccount()
        {
            if (!IsClosed)
            {
                IsActive = false;
                Console.WriteLine("The account has been deactivated");
            }
        }
            
    }
}
