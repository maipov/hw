using BankAccountApp;
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter account owner's name: ");
        string ownername = Console.ReadLine();
        BankAccount account = new BankAccount(ownername);

        Console.WriteLine($"\n The account of {account.Owner} has been successfully created");
        Console.WriteLine($"Initial balance: {account.Balance} VND");

        Console.WriteLine("\nEnter the amount to deposit: ");
        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
        account.Deposit(depositAmount);
        Console.WriteLine($" You have deposited {depositAmount} VND into the account.");
        Console.WriteLine($" Initial balance: {account.Balance} VND");

        Console.Write("\nEnter the amount to withdraw: ");
        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Have you verified your identity? (yes/no): ");
        bool identityVerified = Console.ReadLine().Trim().ToLower() == "yes";

        try
        {
            account.Withdraw(withdrawAmount, identityVerified);
            Console.WriteLine($" You have withdrawn {withdrawAmount} VND.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error: {ex.Message}");
        }

        Console.WriteLine($" Remaining balance: {account.Balance} VND");

        // Close the account
        Console.Write("\nDo you want to close the account? (yes/no): ");
        if (Console.ReadLine().Trim().ToLower() == "yes")
        {
            account.CloseAccount();
        }

        Console.WriteLine("\n The program has ended. Press ENTER to exit.");
        Console.ReadLine();
    }

}
