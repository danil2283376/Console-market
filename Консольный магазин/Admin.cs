using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ConsoleApp2
{
    class Admin
    {
        public void Adminskaya()
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Админская");
                Console.WriteLine("Прибыль: {0}", Abstract.moneyforadmin);
                Console.WriteLine("Количество зарегистрированных пользователей: {0}", Abstract.Login.Count);
                Console.WriteLine("Количество купленных игр: {0}", Abstract.quantitygame);

                Console.WriteLine("\n \n \n1) Удалить игру");
                Console.WriteLine("2) Изменить стоимость игры");
                Console.WriteLine("3) Удалить пользователя");
                Console.WriteLine("4) Добавить игру");
                Console.WriteLine("5) Выйти");
                Console.Write("Ввод: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //удалить игру
                        Console.Clear();
                        DeleteGameAdminskaya();
                        break;
                    case "2":
                        //изменить стоимость игры
                        Console.Clear();
                        ChangePayGame();
                        break;
                    case "3":
                        //удалить пользователя
                        Console.Clear();
                        DeleteUser();
                        break;
                    case "4":
                        //Добавить игру
                        Console.Clear();
                        AddGameAdmin();
                        break;
                    case "5":
                        Console.Clear();
                        Console.ResetColor();
                        Registr registr = new Registr();
                        registr.Verification();
                        break;
                    case "":
                        Console.WriteLine("Вы нечего не ввели!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        Adminskaya();
                        break;

                }
            } while (true);
        }
        public void DeleteGameAdminskaya() // удаляю игру
        {
            Console.Clear();
            for (int i = 0; i < Abstract.Game.Count; i++) // вывел массив с играми
            {
                Console.WriteLine($"{i + 1}) {Abstract.Game[i]}         Цена: {Abstract.PayGame[i]}");
            }
            Console.Write("Введите для удаления: ");
            int input = Convert.ToInt32(Console.ReadLine());
            //Abstract.Game.Remove[input - 1];// Удаляем из корзины

            Abstract.Game.Remove(Abstract.Game[input - 1]);
            Abstract.PayGame.Remove(Abstract.PayGame[input - 1]);
            Console.WriteLine("Удаление произошло успешно!");
            Thread.Sleep(1500);

            Console.Clear();
            Adminskaya();
        }
        public void ChangePayGame() //Меняю цену игры
        {
            Console.Clear();
            for (int i = 0; i < Abstract.Game.Count; i++) // вывел массив с играми
            {
                Console.WriteLine($"{i + 1}) {Abstract.Game[i]}         Цена: {Abstract.PayGame[i]}");
            }
            Console.Write("Выберите игру для изменения цены: ");
            int changeGame = Convert.ToInt32(Console.ReadLine());

            Console.Write("Старая цена игры {0}, введите новую цену: ", Abstract.PayGame[changeGame - 1]);
            string newPay = Console.ReadLine();

            Abstract.PayGame[changeGame - 1] = newPay;
            using (StreamWriter NewPay = new StreamWriter(@"Pay.txt", false))
            {
                for (int i = 0; i < Abstract.PayGame.Count; i++)
                {
                    NewPay.WriteLine(Abstract.PayGame[i].ToString());
                }
            }
            Console.WriteLine("Цена успешно изменена!");
            Thread.Sleep(1500);
            Adminskaya();
        }
        public void DeleteUser()
        {
            do
            {
                Console.WriteLine("Зарегистрированные пользователи");
                if (Abstract.Login.Count >= 1)
                {
                    for (int i = 0; i < Abstract.Login.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {Abstract.Login[i]}");
                    }
                    Console.Write("Введите номер пользователя: ");
                    int numberUser = Convert.ToInt32(Console.ReadLine());

                    Abstract.Login.Remove(Abstract.Login[numberUser - 1]); // Удаление из массива логинов
                    Abstract.Password.Remove(Abstract.Password[numberUser - 1]); // Удаление из массива пароля

                    using (StreamWriter DeleteUser = new StreamWriter(@"Login.txt", false)) // перезапись в файл логинов
                    {
                        for (int i = 0; i < Abstract.Login.Count; i++)
                        {
                            DeleteUser.WriteLine(Abstract.Login[i].ToString());
                        }
                    }
                    using (StreamWriter DeletePassword = new StreamWriter(@"Password.txt", false)) // перезапись в файл паролей
                    {
                        for (int i = 0; i < Abstract.Password.Count; i++)
                        {
                            DeletePassword.WriteLine(Abstract.Password[i].ToString());
                        }
                    }
                    Console.WriteLine("Пользователи были удалены!");
                    Thread.Sleep(2000);
                    Adminskaya();
                }
                else
                {
                    Console.WriteLine("Пользователи еще не зарегистрированы!");
                    Thread.Sleep(2000);
                    Adminskaya();
                }
            } while (true);
        }
        public void AddGameAdmin()
        {
            Console.Clear();
            Console.WriteLine("  <Добавить игру>");
            Console.Write("Сколько игр хотите добавить: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < quantity; i++)
            {
                Console.Write("Введите название {0} - й игры: ", i + 1);
                string NameGame = Console.ReadLine();
                Abstract.Game.Add(NameGame);

                using (var writer = new StreamWriter(@"Game.txt", true))
                {
                    writer.WriteLine("\n" + NameGame);
                }
                Console.Write("Введите cтоимость {0} - й игры: ", i + 1);
                int PayGame = Convert.ToInt32(Console.ReadLine());
                Abstract.PayGame.Add(Convert.ToString(PayGame));

                using (var writer = new StreamWriter(@"Pay.txt", true))
                {
                    writer.WriteLine("\n" + PayGame);
                }
            }
            Console.WriteLine("Все игры были добавлены!");
            Thread.Sleep(2000);
            Adminskaya();
        }
    }
}
