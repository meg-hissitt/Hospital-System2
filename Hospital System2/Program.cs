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
        }
        static List<User> users = new List<User>();

        static string usersFilePath = @"users.json";
        static void Main(string[] args)
        {
            LoadUsers();

            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Login();
            }
            else if (choice == "2")
            {
                Register();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
        static void LoadUsers()
        {
            if (File.Exists(usersFilePath))
            {
                string json = File.ReadAllText(@"users.json");
            }
        }
        static void SaveUsers()
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(@"users.json", json);
        }
        static void Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            var user = users.Find(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                Console.WriteLine("Login successfull.");
            }
            else
            {
                Console.WriteLine("Login unsuccesfull");
            }
        }
        static void Register()
        {
            Console.Write("Enter your first and last name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your address: ");
            string address = Console.ReadLine();

            Console.Write("Enter your patient number: ");
            string patienID = Console.ReadLine();

            Console.Write("Create a username: ");
            string username = Console.ReadLine();

            Console.Write("Create a password: ");
            string password = Console.ReadLine();

            User newUser = new User { Username = username, Password = password };
            users.Add(newUser);
            SaveUsers();
        }
    }



}

