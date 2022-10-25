

using BussinesLogic;
using Storage;

void Enter()
{ 
 //TODO : доделать вход
}
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
            Enter();
            break;
        case "2":
            Registration();
            break;
        default:
            Console.WriteLine("Нет такой команды,попробуйте еще");
            break;


    }

}
void Registration()
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

}
void AddUserDetails(User user)
{
    Console.WriteLine("Введите ваше имя");
    user.Name = Console.ReadLine();
    Console.WriteLine("Введите вашу фамилию");
    user.LastName = Console.ReadLine();
    userService.UpdateUser(user);
}