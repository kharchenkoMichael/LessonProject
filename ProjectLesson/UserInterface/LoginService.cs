


using Storage;
using System.Net.Http.Json;
using System.Numerics;
using System.Text.Json;

namespace UserInterface
{
    public class LoginService
    {
       
        public User Registration()
        {
            string phone = "";
            string password = "";
            User user = null;
            while (true)
            {
                Console.WriteLine("Enter your phone");
                phone = Console.ReadLine();
                Console.WriteLine("Enter your password");
                password = Console.ReadLine();
                Console.WriteLine("Enter your password again");
                var secondPassword = Console.ReadLine();
                if (password != secondPassword)
                { 
                    Console.WriteLine("Not same passwords");
                    continue;
                }
                using var client = new HttpClient();
                user = new User() {Phone = phone, Password = password, IsAdmin = false};
                var response = client.PostAsync($"{Constants.BaseURL}/api/user", JsonContent.Create(user)).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    Console.WriteLine("We couldn't create you account, maybe this phone already exist");
                    continue;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Success");
            Console.WriteLine("+ - Add your data");
            var command = Console.ReadLine();
            if (command == "+")
            {
                AddUserDetails(user);
            }
            return user;
        }
        private void AddUserDetails(User user)
        {
            Console.WriteLine("Enter your name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter your lastname");
            user.LastName = Console.ReadLine();
            using var client = new HttpClient();
            client.PutAsync($"{Constants.BaseURL}/api/user", JsonContent.Create(user)).Wait();
        }
        public User Enter()
        {
            User? user = null;
            string phone = "";
            string password = "";
            while (true)
            {
                Console.WriteLine("Enter your phone");
                phone = Console.ReadLine();
                Console.WriteLine("Enter your password");
                password = Console.ReadLine();
                using var client = new HttpClient();
                var responce = client.GetAsync($"{Constants.BaseURL}/api/user/{phone}/{password}").Result;
                var text = responce.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrEmpty(text))
                {
                    break;
                }
                user = JsonSerializer.Deserialize<User>(text, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                if (user != null)
                {
                    break;
                }

            }
            return user;
        }
    }
}
