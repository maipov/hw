using System;
using Xunit;
using BankAccountApp;
namespace BankAccountTests
{
    public class BankAccountTests
    {
        [Fact]
        public void Deposit_ShouldIncreaseBalance()
        {
            // Arrange
            var account = new BankAccount("Phuong");

            // Act
            account.Deposit(100);

            // Assert
            Assert.Equal(100, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldDecreaseBalance_WhenVerified()
        {
            // Arrange
            var account = new BankAccount("Phuong");
            account.Deposit(200);

            // Act
            account.Withdraw(50, true);

            // Assert
            Assert.Equal(150, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldThrowException_IfNotVerified()
        {
            // Arrange
            var account = new BankAccount("Phuong");
            account.Deposit(100);

            // Act & Assert
            Assert.Throws<UnauthorizedAccessException>(() => account.Withdraw(50, false));
        }

        [Fact]
        public void Withdraw_ShouldThrowException_IfBalanceNotEnough()
        {
            // Arrange
            var account = new BankAccount("Phuong");
            account.Deposit(50);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(100, true));
        }

        [Fact]
        public void CloseAccount_ShouldChangeStatus()
        {
            // Arrange
            var account = new BankAccount("Phuong");

            // Act
            account.CloseAccount();

            // Assert
            Assert.True(account.IsClosed);
            Assert.False(account.IsActive);
        }

        [Fact]
        public void Deposit_ShouldReactivateAccount_IfInactive()
        {
            // Arrange
            var account = new BankAccount("Phuong");
            account.DeactivateAccount();

            // Act
            account.Deposit(50);

            // Assert
            Assert.True(account.IsActive);
        }
    }

}

