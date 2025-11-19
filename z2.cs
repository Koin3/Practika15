using System;
using System.Collections.Generic;

namespace holiss15
{
    public interface ISwitchable
    {
        void TurnOn();
        void TurnOff();
    }
    public interface ILevelAdjustable
    {
        void SetLevel(int level);
    }
    public class Lamp : ISwitchable, ILevelAdjustable
    {
        private int _level;
        public void TurnOn()
        {
            _level = 100;
            Console.WriteLine($"Лампа включена. Уровень: {_level}");
        }
        public void TurnOff()
        {
            _level = 0;
            Console.WriteLine($"Лампа выключена. Уровень: {_level}");
        }
        public void SetLevel(int level)
        {
            if (level < 0) _level = 0;
            else if (level > 100) _level = 100;
            else _level = level;

            Console.WriteLine($"Cостояние лампы: Уровень: {_level}");
        }
    }
    public class Fan : ISwitchable
    {
        public void TurnOn()
        {
            Console.WriteLine("Вентилятор включен");
        }

        public void TurnOff()
        {
            Console.WriteLine("Вентилятор выключен");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var lamp = new Lamp();
            var fan = new Fan();
            List<ISwitchable> devices = new List<ISwitchable> { lamp, fan };
            Console.WriteLine("Проходим по всем устройствам: включить → выключить");
            foreach (var device in devices)
            {
                device.TurnOn();
                device.TurnOff();
                Console.WriteLine();
            }
            Console.WriteLine("Для лампы дополнительно устанавлен уровень 30:");
            lamp.SetLevel(30);
        }
    }
}
