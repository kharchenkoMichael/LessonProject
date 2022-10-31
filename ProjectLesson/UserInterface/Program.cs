

using BussinesLogic;
using Storage;
using UserInterface;

User myUser = null;
var procedurService = new ProcedurService();
var recordService = new RecordService();
var userCommandService = new UserCommandService(procedurService,recordService);
var userService = new UserService();
var loginService = new LoginService(userService);
while (true)
{
    Console.WriteLine("Выберите команду");
    Console.WriteLine("1 - вход");
    Console.WriteLine("2 - Регистрация");

    var command = Console.ReadLine();
    switch (command)
    {
        case "1":
           myUser = loginService.Enter();
            break;
        case "2":
           myUser = loginService.Registration();
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
while (true)
{
    Console.WriteLine("Выберите команду");
    Console.WriteLine("1 - посмотреть доступные процедуры");
    Console.WriteLine("2 - посмотреть свободные даты на ближайшую неделю");
    Console.WriteLine("3 - записаться");
    Console.WriteLine("4 - посмотреть список всех моих ближайших процедур");
    Console.WriteLine("5 - отказаться от процедуры");
    Console.WriteLine("6 - посмотреть историю моих записей");
    var command = Console.ReadLine();
    switch (command)
    {
        case "1":
            userCommandService.ShowAllProcedurs();
            break;
        case "2":
            userCommandService.ShowFreeDates();
            break;
        case "3":
            userCommandService.CreateNewRecord(myUser.Name);
            break;
        case "4":
            userCommandService.ShowFutureRecord(myUser);
            break;
        case "5":
            userCommandService.CancelRecord();
            break;
        case "6":
            userCommandService.ShowPastRecord(myUser);
            break;
    }
}