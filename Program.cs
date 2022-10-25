using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //создание, заполнение списка
            List<Computers> computers = new List<Computers>()
            {
                new Computers(){Num = 123, Name = "Dell", CPU = "Intel", Frequency = 2700, RAM = 12, HDD = 500, GPU = 4, Price = 1500, Quantity= 3},
                new Computers(){Num = 456, Name = "HW", CPU = "AMD", Frequency = 3500, RAM = 8, HDD = 1500, GPU = 2, Price = 1200, Quantity= 6},
                new Computers(){Num = 789, Name = "DNS", CPU = "Baikal", Frequency = 1200, RAM = 4, HDD = 2000, GPU = 8, Price = 1100, Quantity= 5},
                new Computers(){Num = 987, Name = "Xin", CPU = "Intel", Frequency = 2100, RAM = 16, HDD = 1000, GPU = 4, Price = 1600, Quantity= 8},
                new Computers(){Num = 654, Name = "IBM", CPU = "Athlon 5400", Frequency = 2350, RAM = 6, HDD = 750, GPU = 2, Price = 1750, Quantity= 13},
                new Computers(){Num = 321, Name = "Hitachi", CPU = "Elbrus-8S", Frequency = 1500, RAM = 6, HDD = 250, GPU = 2, Price = 2000, Quantity= 2},
                new Computers(){Num = 147, Name = "Siemens", CPU = "AMD", Frequency = 3400, RAM = 4, HDD = 1250, GPU = 6, Price = 2500, Quantity= 7},
            };
            //запрос и вывод на экран компьютера по названию процессора
            Console.WriteLine("Введите название процессора: ");
            string cpu = Console.ReadLine();
            List<Computers> computers1 = computers.Where(x => x.CPU == cpu).ToList();
            Print(computers1);
            //запрос и вывод на экран компьютера по объему ОЗУ
            Console.WriteLine("Введите объем ОЗУ: ");

            try
            {
                double ram = Convert.ToDouble(Console.ReadLine());
                List<Computers> computers2 = computers.Where(x => x.RAM >= ram).ToList();
                Print(computers2);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //сортировка по цене
            List<Computers> computers3 = computers.OrderBy(x => x.Price).ToList();
            Print(computers3);
            //группировка по названию процессора
            IEnumerable<IGrouping<string, Computers>> computers4 = computers.GroupBy(x => x.CPU);
            foreach (IGrouping<string, Computers> gr in computers4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computers c in gr)
                {
                    Console.WriteLine($"{c.Num} {c.Name} {c.CPU} {c.Frequency} {c.RAM} {c.HDD} {c.GPU} {c.Price} {c.Quantity}");
                }
            }
            Console.WriteLine();
            //самый дорогой компьютер
            Computers computers5 = computers.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine("Самый дорогой компьютер");
            Console.WriteLine($"{computers5.Num} {computers5.Name} {computers5.CPU} {computers5.Frequency} {computers5.RAM} {computers5.HDD} {computers5.GPU} {computers5.Price} {computers5.Quantity}");
            //самый бюджетный компьютер
            Computers computers6 = computers.OrderByDescending(x => x.Price).LastOrDefault();
            Console.WriteLine("Самый бюджетный компьютер");
            Console.WriteLine($"{computers6.Num} {computers6.Name} {computers6.CPU} {computers6.Frequency} {computers6.RAM} {computers6.HDD} {computers6.GPU} {computers6.Price} {computers6.Quantity}");
            Console.WriteLine();
            //проверка по количеству
            Console.WriteLine("Есть хотя бы один компьютер с количеством более 30 штук?");
            Console.WriteLine(computers.Any(x => x.Quantity >= 30));

            Console.ReadKey();
        }



        static void Print(List<Computers> computers) //вывод на экран
        {
            if (computers.Count == 0)
            {
                Console.WriteLine("Совпадения не найдены");
            }
            else
            {
                foreach (Computers c in computers)
                {
                    Console.WriteLine($"{c.Num} {c.Name} {c.CPU} {c.Frequency} {c.RAM} {c.HDD} {c.GPU} {c.Price} {c.Quantity}");
                }
                Console.WriteLine();
            }
        }

    }
}
