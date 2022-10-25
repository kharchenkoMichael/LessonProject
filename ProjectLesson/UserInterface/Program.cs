

using BussinesLogic;
using Storage;
User myUser = null;
var userService = new UserService();
while (true)
{
    Console.WriteLine("Выберите команду");
    Console.WriteLine("1 - вход");
    Console.WriteLine("2 - Регистрация");

    var command = Console.ReadLine();
    switch (command)
    {
        case "1":
           myUser = Enter();
            break;
        case "2":
           myUser = Registration();
            break;
        default:
            Console.WriteLine("Нет такой команды,попробуйте еще");
            break;


    }
    if (myUser != null)
    {
        break;
    }
}
User Registration()
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
        if(password == secondPassword)
        {
            break;
        }
    }
    var user =  userService.CreateUser(phone,password);
    Console.WriteLine("Вы успешно зарегистрованы");
    Console.WriteLine("+ - добавить ваши данные");
    var command = Console.ReadLine();
    if(command == "+")
    {
        AddUserDetails(user);
    }
    return user;
}
void AddUserDetails(User user)
{
    Console.WriteLine("Введите ваше имя");
    user.Name = Console.ReadLine();
    Console.WriteLine("Введите вашу фамилию");
    user.LastName = Console.ReadLine();
    userService.UpdateUser(user);
}
User Enter()
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
        user = userService.Login(phone,password);
        if(user != null)
        {
            break;
        }

    }
    return user;
}