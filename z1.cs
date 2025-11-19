using System;

namespace holiss15
{
    public interface IWorkable
    {
        void Work();
    }
    public interface IChargeable
    {
        void Charge();
    }
    public class Robot : IWorkable, IChargeable
    {
        public string Name { get; private set; }
        public int Energy { get; private set; }
        public Robot(string name)
        {
            Name = name;
            Energy = 100;
        }
        public void Work()
        {
            Energy = Math.Max(0, Energy - 20);
            Console.WriteLine($"{Name} работает. Энергия: {Energy}");
        }
        public void Charge()
        {
            Energy = Math.Max(0, Energy + 50);
            Console.WriteLine($"{Name} работает. Энергия: {Energy}");
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Robot robot = new Robot("Zet-01");
                Console.WriteLine($"Начальная энергия {robot.Name}: {robot.Energy}");
                Console.WriteLine();

                Console.WriteLine("1.Робот работает два раза");
                robot.Work();
                robot.Work();
                Console.WriteLine();

                Console.WriteLine("2.Робот на зарядке");
                robot.Charge();
                Console.WriteLine();

                Console.WriteLine("3.Робот работает еще раз");
                robot.Work();

            }
        }
    }
}
