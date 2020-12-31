using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    class Library : Basket
    {
        public void DisplayInfoLibrary()
        {
            if (payLibrary.Count > 0)
            {
                Console.WriteLine("<Библиотека>");
                for (int i = 0; i < payLibrary.Count; i++)
                {
                    Console.WriteLine("{0}) {1}", i + 1, payLibrary[i]);
                }
                Console.WriteLine("\n\n+) Перейти в магазин");
                Console.WriteLine("-) Перейти в меню");
                string verification = Console.ReadLine();

                if (verification == "") {
                    Console.WriteLine("Извините вы нечего не ввели!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    DisplayInfoBasket();
                }

                else if (verification == "+")
                {
                    Console.Clear();
                    DisplayGame();
                }
                else
                {
                    Console.Clear();
                    Display display = new Display();
                    display.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("Ваша библиотека пуста!");
                Console.WriteLine("Переходим в магазин...");
                Thread.Sleep(3000);
                DisplayGame();
            } 
        }
    }
}
