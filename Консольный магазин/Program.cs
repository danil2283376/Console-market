using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace ConsoleApp2
{
    class Program : ITerms_of_use
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Готовы прочитать пользовательское соглашение(Y/N)");
                string input = Console.ReadLine();
                if (input == "Y" || input == "y" || input == "Н" || input == "н")
                {
                    Console.Clear();
                    Program program = new Program();
                    program.Termsofuse();
                }
                else if (input == "") {
                    Console.WriteLine("Извините вы нечего не ввели!");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вы отказались от пользовательского соглашения.");
                    Console.WriteLine("Программа завершает свою работу!");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
            } while (true);
        }
        public void Termsofuse()
        {
            Console.WriteLine("ПОЛЬЗОВАТЕЛЬСКОЕ СОГЛАШЕНИЕ:\n\n");
            Console.WriteLine("1. Использование программы. Разрешается установка одновременно на одном компьютере программы\n" +
                "или любой предыдущей версии.Основному пользователю компьютера, на котором установлена эта копия,\n" +
                "разрешается также создание еще одной копии исключительно для своей работы на переносном компьютере.\n");
            Console.WriteLine("2. Хранение и использование в сети. Разрешается хранение, установка и\n" +
                "запуск копии программы с общедоступного устройства хранения данных(например, сервера сети).\n" +
                "При этом для каждого компьютера, на котором установлена или запущена с сервера сети данная программа,\n" +
                "необходимо приобрести отдельную лицензию. ");
            Console.Write("\n\nНажмите на любую клавишу...");

            Console.ReadKey();
            Console.Clear();
            Registr registr = new Registr();
            registr.Verification();
        }
    }
}
