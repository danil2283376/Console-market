using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp2
{
    class ShopGame : Abstract
    {
        public string name { get; set; }
        public int quantity { get; set; }

        private int pay;
        public int Pay
        {
            get { return pay; }
            set
            {
                if (pay < 0 || pay > 9999) // добавляем проверку на цену
                {
                    pay = value;
                }
                else
                {
                    Console.WriteLine("Непреемлемая цена");
                }
            }
        }

        public ShopGame(string Name, int Quantity) : base (money)// конструктор
        {
            name = Name;
            quantity = Quantity;
        }
        public ShopGame() : base (money)
        {
            
        }

        public void DisplayGame() // Выводим игры из файла
        {
            Console.Clear();
            Console.WriteLine("   <Магазин игр>                                       БАЛАНС = {0}", money);

            for (int i = 0; i < Game.Count; i++) // вывел массив с играми
            {
                Console.WriteLine($"{i+1}) {Game[i]}            Цена: {PayGame[i]}");
            }
            Console.Write("Купить игру(Введите номер): ");
            int NumberGame = Convert.ToInt32(Console.ReadLine());
            try
            {
                gameBasket.Add(Game[NumberGame - 1]);
                payBasket.Add(PayGame[NumberGame - 1]);

                Console.WriteLine("Переходим в корзину для оплаты...");
                Thread.Sleep(2000);

                Console.Clear();
                Basket basket = new Basket();
                basket.DisplayBasket();
            }
            finally 
            {
                Console.WriteLine("Вы ввели не верное число!");
                Thread.Sleep(1500);
                DisplayGame();
            }
        }
        public void AddGameUser() // в магазин добавляет игры User
        {
            Console.Clear();
            Console.WriteLine("  <Добавить игру>");
            Console.Write("Сколько игр хотите добавить: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (Convert.ToString(quantity) == "")
            {
                Console.WriteLine("Вы нечего не ввели!");
                Thread.Sleep(1500);
                Console.Clear();
                AddGameUser();
            }
            else
            {

                for (int i = 0; i < quantity; i++)
                {
                    Console.Write("Введите название {0} - й игры: ", i + 1);
                    string NameGame = Console.ReadLine();

                    using (var writer = new StreamWriter(pathGame, true))
                    {
                        writer.WriteLine("\n" + NameGame);
                    }
                    Console.Write("Введите cтоимость {0} - й игры: ", i + 1);
                    int PayGame = Convert.ToInt32(Console.ReadLine());

                    using (var writer = new StreamWriter(pathPay, true))
                    {
                        writer.WriteLine("\n" + PayGame);
                    }
                }
                Console.WriteLine("Переходим в меню...");
                Thread.Sleep(3000);
                Console.Clear();
                Display display = new Display();
                display.DisplayInfo();
            }
        }
    }
}
