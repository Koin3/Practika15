using System;
using System.Collections.Generic;

namespace holiss15
{
    public interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
    }
    public interface ITransferable
    {
        void Transfer(decimal amount, IBankAccount targetAccount);
    }
    public class BankAccount : IBankAccount, ITransferable
    {
        private decimal balance;
        public string AccountNumber { get; }
        public BankAccount(string accountNumber, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            balance = initialBalance;
        }

        public decimal Balance => balance;
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"На счёт {AccountNumber} внесено: {amount}. Баланс: {balance}");
            }
            else
            {
                Console.WriteLine("Сумма для внесения должна быть больше 0");
            }
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма для снятия должна быть больше 0");
                return;
            }

            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Со счёта {AccountNumber} снято: {amount}. Баланс: {balance}");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств на счёте {AccountNumber}. Требуется: {amount}, доступно: {balance}");
            }
        }
        public void Transfer(decimal amount, IBankAccount targetAccount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть больше 0");
                return;
            }

            if (balance >= amount)
            {
                balance -= amount;
                if (targetAccount is BankAccount target)
                {
                    target.balance += amount;
                }
                else
                {
                    targetAccount.Deposit(amount);
                }
                Console.WriteLine($"Перевод {amount} со {AccountNumber} на {(targetAccount as BankAccount)?.AccountNumber} выполнен успешно");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств для перевода. Требуется: {amount}, имеется: {balance}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var account1 = new BankAccount("Счёт 1", 1000);
            var account2 = new BankAccount("Счёт 2", 500);

            Console.WriteLine("Начальные балансы:");
            Console.WriteLine($" {account1.AccountNumber}: {account1.Balance}");
            Console.WriteLine($" {account2.AccountNumber}: {account2.Balance}");

            Console.WriteLine("\nGеревод 300 со счёта 1 на счёт 2:");
            account1.Transfer(300, account2);
            Console.WriteLine("\nПосле перевода:");
            Console.WriteLine($" {account1.AccountNumber}: {account1.Balance}");
            Console.WriteLine($" {account2.AccountNumber}: {account2.Balance}");
        }
    }
}
