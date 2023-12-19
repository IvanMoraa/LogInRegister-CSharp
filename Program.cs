using System;
using System.Collections.Generic;

namespace LoginSystem
{

    class Program
    {
        private const string CompanyTitleName = "EXAMPLE";
        private static readonly Dictionary<string, string> UserCredentials = new Dictionary<string, string>();

        static void Main()
        {
            while (true)
            {
                DisplayMenu();

                int optionSelected;
                while (!int.TryParse(Console.ReadLine(), out optionSelected))
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }

                switch (optionSelected)
                {
                    case 1:
                        ProcessLogin();
                        break;

                    case 2:
                        ProcessRegistration();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine($"Welcome to {CompanyTitleName}");
            Console.WriteLine("==============================");
            Console.WriteLine("1.- LogIn");
            Console.WriteLine("2.- Register");
            Console.WriteLine("==============================");
        }

        private static void ProcessLogin()
        {
            Console.WriteLine("Please enter your username:");
            string loginUsername = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string loginPassword = Console.ReadLine();
                if (ValidateLogin(loginUsername, loginPassword))
                {
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("Login failed. Invalid username or password.");
                }
        }

        private static void ProcessRegistration()
        {
            Console.WriteLine("Please enter a new username:");
            string newUsername = Console.ReadLine();
            Console.WriteLine("Please enter a password:");
            string newPassword = Console.ReadLine();
            RegisterUser(newUsername, newPassword);
        }
        private static void RegisterUser(string username, string password)
        {
            if (UserCredentials.ContainsKey(username))
            {
                Console.WriteLine("Username already exists. Please choose another one.");
            }
            else
            {
                UserCredentials.Add(username, password);
                Console.WriteLine("Registration successful!");
            }
        }

        private static bool ValidateLogin(string username, string password)
        {
            if (UserCredentials.TryGetValue(username, out string storedPassword))
            {
                return storedPassword == password;
            }
            return false;
        }
    }
}
