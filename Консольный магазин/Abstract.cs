using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Abstract
    {
        public string pathGame = @"Game.txt";
        //public static int count = File.ReadAllLines(@"Game.txt").Length;

        //public static string[] Login = File.ReadAllLines(@"Login.txt");
        public static List<string> Login = File.ReadAllLines(@"Login.txt").ToList();
        public static List<string> Password = File.ReadAllLines(@"Password.txt").ToList();
        public string pathPay = @"Pay.txt";
        //public string[] PayGame = File.ReadAllLines(@"Pay.txt");
        //public static string[] Game = File.ReadAllLines(@"Game.txt");

        public static List<string> Game = File.ReadAllLines(@"Game.txt").ToList();
        public static List<string> PayGame = File.ReadAllLines(@"Pay.txt").ToList();

        public string[] GameBasket = File.ReadAllLines(@"Basket.txt");
        public string pathBasket = @"Basket.txt";
        public int countBasket = File.ReadAllLines(@"Basket.txt").Length;
        public static string nameUser { get; set; }
        public static int money { get; set; }
        public static int moneyforadmin { get; set; }
        public static double quantitygame { get; set; }

        public Abstract(int Money, int MoneyForAdmin) // деньги пользователя
        {
            money = Money;
            moneyforadmin = MoneyForAdmin;
        }
        public Abstract(double QuantityGame) // количество купленных игр для Админа
        {
            quantitygame = QuantityGame;
        }
        public Abstract(string NameUser)
        {
            nameUser = NameUser;
        }
        public static List<string> gameBasket = new List<string> { }; // массив для игр в Корзине.

        public static List<string> payBasket = new List<string>(); // массив для денег в Корзине.

        public static List<string> payLibrary = new List<string>(); // массив для игр в библиотеке.
        public virtual void DisplayInfoAbstract()
        {
        }
    }
}
