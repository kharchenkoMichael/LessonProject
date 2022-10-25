

using BussinesLogic;
using Storage;

namespace UserInterface
{
    public class LoginService
    {
        private UserService _userService;

        public LoginService(UserService userService)
        {
            _userService = userService;
        }
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
            var user = _userService.CreateUser(phone, password);
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
            _userService.UpdateUser(user);
        }
        public User Enter()
        {
            User user = null;
            string phone = "";
            string password = "";
            while (true)
            {
                Console.WriteLine("Введите свой phone");
                phone = Console.ReadLine();
                Console.WriteLine("Введите свой password");
                password = Console.ReadLine();
                user = _userService.Login(phone, password);
                if (user != null)
                {
                    break;
                }

            }
            return user;
        }
    }
}
