using System;
using System.Collections.Generic;

namespace holiss15
{
    public interface IAttackable
    {
        void Attack();
    }
    public interface IHealable
    {
        void Heal();
    }
    public class Warrior : IAttackable
    {
        public void Attack()
        {
            Console.WriteLine("Воин атакует мечом!");
        }
    }
    public class Mage : IAttackable, IHealable
    {
        public void Attack()
        {
            Console.WriteLine("Маг бросает огненный шар!");
        }

        public void Heal()
        {
            Console.WriteLine("Маг исцеляет раны!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var warrior = new Warrior();
            var mage = new Mage();

            List<IAttackable> attackers = new List<IAttackable> { warrior, mage };

            List<IHealable> healers = new List<IHealable> { mage };

            Console.WriteLine("Damage Dealers:");
            foreach (var attacker in attackers)
            {
                attacker.Attack();
            }
            Console.WriteLine("\nSupports:");
            foreach (var healer in healers)
            {
                healer.Heal();
            }
        }
    }
}
