using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Hospital_System2.Program;

namespace Hospital_System2
{
    class UserManager
    {
        public string json { get; set; }
        public void LoadUsers()
        {
            if (File.Exists(@"users.json"))
            {
                json = File.ReadAllText(@"users.json");
            }
            else
            {
                File.Create(@"users.json").Close();
                json = File.ReadAllText(@"users.json");
            }

        }
        public void Login()
        {
            LoadUsers();
            List<User> userList = JsonConvert.DeserializeObject<List<User>>(this.json);
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            foreach (var user in userList)
            {
                if (user.Username == username && user.Password == password)
                {
                    Console.WriteLine("Login successfull.");
                }
                else
                {
                    Console.WriteLine("Login unsuccesfull");
                }
            }

        }
        void SaveUsers(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(@"users.json", json);
        }
        public void Register()
        {
            Console.Write("Enter your first and last name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your address: ");
            string address = Console.ReadLine();

            Console.Write("Enter your patient number: ");
            string patientID = Console.ReadLine();

            Console.Write("Create a username: ");
            string username = Console.ReadLine();

            Console.Write("Create a password: ");
            string password = Console.ReadLine();

            List<User> userList = JsonConvert.DeserializeObject<List<User>>(this.json);
            User newUser = new User {Name = name, Address = address, PatientID = patientID, Username = username, Password = password };
            userList.Add(newUser);
            SaveUsers(userList);
        }
    }
}
