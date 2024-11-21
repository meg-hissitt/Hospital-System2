namespace Hospital_System2
{
    using Newtonsoft.Json;
    using System;

    class Program
    {
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string PatientID { get; set; }

        }

        string usersFilePath = @"users.json";
        public static void Main(string[] args)
        {
            UserManager uman = new UserManager();

            uman.LoadUsers();

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.Write("What would you like to do? ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    uman.Login();
                }
                else if (choice == "2")
                {
                    uman.Register();
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        }
    }



