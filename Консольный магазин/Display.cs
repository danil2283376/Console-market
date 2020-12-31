using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    class Display
    {
        public void DisplayInfo()
        {
            string input;
            do
            {
                Console.WriteLine("Преведствуем вас {0}", Abstract.nameUser);
                Console.WriteLine(" <Меню>                                       БАЛАНС = {0}", Abstract.money);
                Console.WriteLine("1) Магазин");
                Console.WriteLine("2) Добавить игру");
                Console.WriteLine("3) Библиотека");
                Console.WriteLine("4) Корзина");
                Console.WriteLine("5) Пополнить баланс");
                Console.WriteLine("6) Сменить учетную запись");
                Console.WriteLine("7) Выйти");
                Console.Write("Ввод: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShopGame shopGame = new ShopGame();
                        shopGame.DisplayGame();
                        break;
                    case "2":
                        ShopGame shopGame1 = new ShopGame();
                        shopGame1.AddGameUser();
                        break;
                    case "3":
                        Console.Clear();
                        Library library = new Library();
                        library.DisplayInfoLibrary();
                        break;
                    case "4":
                        Console.Clear();
                        Basket basket = new Basket();
                        basket.DisplayBasket();
                        break;
                    case "5":
                        Console.Clear();
                        Console.Write("Введите сумму: ");
                        int money = Convert.ToInt32(Console.ReadLine());

                        Abstract.money += money;
                        Abstract.moneyforadmin += money;

                        Console.WriteLine("Ваш баланс пополнен!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        DisplayInfo();
                        break;
                    case "6":
                        Console.Clear();
                        Registr registr = new Registr();
                        registr.Verification();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    case "":
                        Console.WriteLine("Вы нечего не ввели!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        DisplayInfo();
                        break;
                    default:
                        Console.WriteLine("Такой цифры нет");
                        Console.Clear();
                        break;
                }
            } while (Convert.ToInt32(input) > 1 || Convert.ToInt32(input) < 8);
            Console.ReadKey();
        }
    }
}
