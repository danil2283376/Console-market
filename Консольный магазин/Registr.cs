using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Reflection;

namespace ConsoleApp2
{
    class Registr
    {
        public string[] Login = File.ReadAllLines(@"Login.txt");
        public string[] Password = File.ReadAllLines(@"Password.txt");
        public void Verification()
        {
            do
            {
                Console.WriteLine("1) Войти           2) Регистрация        3) Войти как админ");
                Console.Write("Ввод: ");
                string input = Console.ReadLine();
                if (input == "") {
                    Console.WriteLine("Вы нечего не ввели");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    if (Convert.ToInt32(input) >= 1 && Convert.ToInt32(input) <= 3)
                    {
                        switch (input)
                        {
                            case "1":
                                Console.Clear();
                                ComeIt();
                                break;
                            case "2":
                                Console.Clear();
                                Registration();
                                break;
                            case "3":
                                Console.Clear();
                                RegisterAdmin();
                                break;
                            //case "":
                            //    Console.WriteLine("Вы нечего не ввели!");
                            //    Thread.Sleep(1500);
                            //    Console.Clear();
                            //    Verification();
                            //    break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Неверное число!");
                                Thread.Sleep(1500);
                                Verification();
                                break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Неверный ввод!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        Verification();
                    }
                }
                
            } while (true);
        }
        public void ComeIt() // Войти
        {
            if (Login.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("Не одного пользователя не зарегистрировалось!");
                Thread.Sleep(2000);
                Console.Clear();
                Verification();
            }
            else
            {
                Console.Write("Введите логин: ");
                string inputLogin = Console.ReadLine();
                if (inputLogin == "") {
                    Console.WriteLine("Вы нечего не ввели!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    ComeIt();
                }

                for (int i = 0; i < Login.Length; i++)
                {
                    if (inputLogin == Login[i])
                    {
                        Abstract.nameUser = Login[i];
                    }
                    else if (inputLogin != Login[Login.Length - 1])
                    {
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("Логин не верный!");
                        Console.WriteLine("Попробуйте сначала!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Verification();
                    }
                }
                Console.Clear();
                Console.WriteLine("Здравствуйте {0}", Abstract.nameUser);
                Console.WriteLine("Введите пароль: ");
                string password = Console.ReadLine();
                for (int i = 0; i < Password.Length; i++)
                {
                    if (password == Password[i])
                    {
                        Console.WriteLine("Вход осуществлен!");
                        Thread.Sleep(2000);
                        Display display = new Display();
                        Console.Clear();
                        display.DisplayInfo();
                    }
                    else if (password != Password[Password.Length - 1])
                    {
                        Console.Beep();
                        Console.Clear();
                        Console.WriteLine("Неверный пароль к учетной записи {0}", Abstract.nameUser);
                        Console.WriteLine("Попробуйте сначала!");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Verification();
                    }
                }
            }
        }
        public void Registration()
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            if (login == "") {
                Console.WriteLine("Вы нечего не ввели!");
                Thread.Sleep(1500);
                Console.Clear();
                Registration();
            }

            for (int i = 0; i < Login.Length; i++)
            {
                if (login == Login[i])
                {
                    Console.WriteLine("Такой пользователь уже существует, выберите другое имя!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Registration();
                }
            }

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            File.AppendAllText(@"Login.txt", "\n" + login);
            File.AppendAllText(@"Password.txt", "\n" + password);
            Console.WriteLine("Вы успешно зарегистрировались!");
            Thread.Sleep(3000);

            var fileName = Assembly.GetExecutingAssembly().Location; // Перезапуск программы
            System.Diagnostics.Process.Start(fileName);
        }
        public void RegisterAdmin()
        {
            string loginAdmin = "AdminDanil";
            string passwordAdmin = "2283376";

            Console.WriteLine("Войти как админ");
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();
            if (login == "") {
                Console.WriteLine("Вы нечего не ввели!");
                Thread.Sleep(1500);
                Console.Clear();
                RegisterAdmin();

            }
            else if (login == loginAdmin)
            {
                Console.Clear();
                Console.WriteLine("Здравствуйте {0}", loginAdmin);
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();

                if (password == passwordAdmin)
                {
                    Admin admin = new Admin();
                    admin.Adminskaya();
                }
                else
                {
                    Console.WriteLine("Хорошая попытка!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Verification();
                }
            }
            else
            {
                Console.WriteLine("Хорошая попытка!");
                Thread.Sleep(2000);
                Console.Clear();
                Verification();
            }
        }
    }
}
