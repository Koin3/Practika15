using System;
using System.Collections.Generic;

namespace holiss15
{
    public interface IPriceable
    {
        decimal GetPrice();
    }
    public interface IWarrantable
    {
        int GetWarrantyMonths();
    }
    public class Phone : IPriceable, IWarrantable
    {
        private decimal price;
        private int warrantyMonths;
        public Phone(decimal price, int warrantyMonths)
        {
            this.price = price;
            this.warrantyMonths = warrantyMonths;
        }
        public decimal GetPrice()
        {
            return price;
        }
        public int GetWarrantyMonths()
        {
            return warrantyMonths;
        }
    }
    public class Laptop : IPriceable
    {
        private decimal price;

        public Laptop(decimal price)
        {
            this.price = price;
        }
        public decimal GetPrice()
        {
            return price;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var phone = new Phone(25000, 12);
            var laptop = new Laptop(50000);
            List<IPriceable> products = new List<IPriceable> { phone, laptop };
            decimal totalCost = 0;
            Console.WriteLine("Информация о товарах:");
            foreach (var product in products)
            {
                totalCost += product.GetPrice();
                if (product is IWarrantable warrantable)
                {
                    Console.WriteLine($"Товар: {product.GetType().Name}. Цена: {product.GetPrice()} - Гарантия: {warrantable.GetWarrantyMonths()} месяцев");
                }
                else
                {
                    Console.WriteLine($"Товар: {product.GetType().Name}. Цена: {product.GetPrice()}");
                }
            }
            Console.WriteLine($"Общая стоимость товаров: {totalCost}");
        }
    }
}
