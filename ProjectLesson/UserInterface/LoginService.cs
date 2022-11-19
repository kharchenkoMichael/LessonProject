


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
            while (true)
            {
                Console.WriteLine("Введите свой номер телефона");
                phone = Console.ReadLine();
                Console.WriteLine("Введите свой пароль");
                password = Console.ReadLine();
                Console.WriteLine("Введите повторно свой пароль");
                var secondPassword = Console.ReadLine();
                if (password == secondPassword)
                {
                    break;
                }
            }
            using var client = new HttpClient();
            var user = new User() {Phone = phone, Password = password};
            client.PostAsync($"{Constants.BaseURL}/api/user", JsonContent.Create(user)).Wait();
            Console.WriteLine("Вы успешно зарегистрованы");
            Console.WriteLine("+ - добавить ваши данные");
            var command = Console.ReadLine();
            if (command == "+")
            {
                AddUserDetails(user);
            }
            return user;
        }
        private void AddUserDetails(User user)
        {
            Console.WriteLine("Введите ваше имя");
            user.Name = Console.ReadLine();
            Console.WriteLine("Введите вашу фамилию");
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
                Console.WriteLine("Введите свой phone");
                phone = Console.ReadLine();
                Console.WriteLine("Введите свой password");
                password = Console.ReadLine();
                using var client = new HttpClient();
                var responce = client.GetAsync($"{Constants.BaseURL}/api/user/{phone}/{password}").Result;
                user = JsonSerializer.Deserialize<User>(responce.Content.ReadAsStringAsync().Result);
                if (user != null)
                {
                    break;
                }

            }
            return user;
        }
    }
}
