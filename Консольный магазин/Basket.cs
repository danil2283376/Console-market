using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Collections;

namespace ConsoleApp2
{
    class Basket : ShopGame
    {
        public int numberGame { get; set; }
        public Basket(int Number)
        {
            numberGame = Number;
        }
        public Basket()
        {

        }
        public void DisplayBasket() //Проверка на нахождение игр в корзине
        {
            //Console.WriteLine("  <Корзина>                                       БАЛАНС = {0}", money);
            if (gameBasket.Count == 0) // проверяет есть в корзине что нибудь
            {
                Console.WriteLine("На данный момент ваша корзина пуста!");
                Console.WriteLine("Перейти в магазин для покупок(Y/N)");
                string verification = Console.ReadLine();

                if (verification == "") {
                    Console.WriteLine("Вы нечего не ввели!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    DisplayBasket();
                }

                else if (verification == "Y" || verification == "y" || verification == "Н" || verification == "н")
                {
                    Console.WriteLine("Переходим в магазин...");
                    Thread.Sleep(2);
                    ShopGame shopGame = new ShopGame();
                    shopGame.DisplayGame();
                }
                else // выкидывает в начало
                {
                    Console.Clear();
                    Display display = new Display();
                    display.DisplayInfo();
                }
            }
            else
            {
                DisplayInfoBasket();
            }
        }
        public void DisplayInfoBasket() // Вывести игры в корзине
        {
            int sum = 0;
            Console.WriteLine("  <Корзина>                                       БАЛАНС = {0}", money);
            for (int i = 0; i < gameBasket.Count; i++)
            {
                Console.WriteLine("{0}) {1} Цена: {2}",i+1, gameBasket[i], payBasket[i]);
                sum += Convert.ToInt32(payBasket[i]);
            }
            Console.WriteLine("Общая стоимость вашей корзины: {0}", sum);
    
            Console.WriteLine("\n\n+) Купить игру");
            Console.WriteLine("-) Удалить игру");
            Console.WriteLine("=) Перейти в магазин");
            Console.WriteLine("*) Пополнить Баланс");
            Console.WriteLine("Для выхода введите любой символ");
            Console.Write("Ввод: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "+":
                        Console.WriteLine("Введите № игры: ");
                        int buyNumberGame = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        BuyGame(buyNumberGame);
                        break;
                    case "-":
                        Console.Write("Введите игру которую хотите удалить: ");
                        int deleteGameOfBasket = Convert.ToInt32(Console.ReadLine());
                        RemoveString(deleteGameOfBasket);
                        break;
                    case "=":
                        Console.Clear();
                        DisplayGame();
                        break;
                    case "*":
                        Console.Write("Введите сумму: ");
                        int money1 = Convert.ToInt32(Console.ReadLine());
                        money += money1;
                        moneyforadmin += money1;
                        Console.Clear();
                        DisplayInfoBasket();
                        break;
                    case "":
                        Console.WriteLine("Вы нечего не ввели!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        DisplayInfoBasket();
                        break;
                    default:
                        Console.Clear();
                        Display display1 = new Display();
                        display1.DisplayInfo();
                        break;
                }
        }
        public void RemoveString(int number) //Удаляем игру
        {
            Console.WriteLine("Удаляем...");
            Thread.Sleep(2000);

            gameBasket.Remove(gameBasket[number - 1]);
            payBasket.Remove(payBasket[number - 1]);

            Console.WriteLine("Удаление прошло успешно!");
            Thread.Sleep(2000);
            Console.Clear();
            DisplayBasket();
        }
        public void BuyGame(int buyNumberGame) // купить игру
        {
            Console.WriteLine("Ваш баланс: {0}", money);
            Console.WriteLine($"{gameBasket[buyNumberGame - 1]} Цена: {payBasket[buyNumberGame - 1]}");

            if (money < Convert.ToInt32(payBasket[buyNumberGame - 1]))
            {
                Console.WriteLine("У вас не достаточно средств!");
                Console.Write("Пополнить баланс: ");
                int money1 = Convert.ToInt32(Console.ReadLine());

                money += money1;
                moneyforadmin += money1;
                Console.Clear();

                Display display = new Display();
                display.DisplayInfo(); 
            }
            else
            {
                Console.WriteLine("Купить игру: Y/N");
                char verification = Convert.ToChar(Console.ReadLine());

                if (verification == 'Y' || verification == 'y' || verification == 'Н' || verification == 'н')
                {

                    Console.WriteLine("Игра куплена!");
                    Console.WriteLine("С вашего счета списаны деньги");

                    money -= Convert.ToInt32(payBasket[buyNumberGame - 1]);
                    quantitygame++;

                    Thread.Sleep(2000);

                    payLibrary.Add(gameBasket[buyNumberGame - 1]);// Добавляем в библиотеку

                    gameBasket.Remove(gameBasket[buyNumberGame - 1]);// Удаляем из корзины
                    payBasket.Remove(payBasket[buyNumberGame - 1]);
                    Console.Clear();
                    Library library = new Library();
                    library.DisplayInfoLibrary();
                }
                else
                {
                    DisplayBasket();
                }
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine("Переходим в библиотеку...");
                Library library1 = new Library();
                library1.DisplayInfoLibrary();
                Console.ReadLine();
            }
        }
    }
}
