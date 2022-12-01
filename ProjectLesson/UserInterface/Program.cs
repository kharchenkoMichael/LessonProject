


using Storage;
using UserInterface;

User myUser = null;
var adminCommandService = new AdminCommandService();
var userCommandService = new UserCommandService();
var loginService = new LoginService();
while (true)
{
    while (true)
    {
        Console.WriteLine("Choose command");
        Console.WriteLine("1 - Login");
        Console.WriteLine("2 - Registration");

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
                Console.WriteLine("There is not so command");
                break;


        }
        if (myUser != null)
        {
            break;
        }
    }
    if (!myUser.IsAdmin)
    {
        UserCommands(myUser, userCommandService);
    }
    else
    {
        AdminCommands(myUser, adminCommandService);
    }
}
static void AdminCommands(User myUser, AdminCommandService adminCommandService)
{
    while (true)
    {
        Console.WriteLine("Choosse your command");
        Console.WriteLine("1 - Look all history records of all users");
        Console.WriteLine("2 - Look all future records of all users");
        Console.WriteLine("3 - create record for client");
        Console.WriteLine("4 - Cancel record");
        Console.WriteLine("5 - Look all not approved records");
        Console.WriteLine("6 - Approve record");
        Console.WriteLine("7 - Logout");
        var command = Console.ReadLine();
        switch (command)
        {
            case "1":
                adminCommandService.ShowAllHistoryRecords();
                break;
            case "2":
                adminCommandService.ShowAllFutureRecords();
                break;
            case "3":
                adminCommandService.CreateNewRecord();
                break;
            case "4":
                adminCommandService.CancelRecord();
                break;
            case "5":
                adminCommandService.ShowAllNotApproveRecord();
                break;
            case "6":
                adminCommandService.ApproveRecord();
                break;
            case "7":
                return;
        }
    }
}


static void UserCommands(User myUser, UserCommandService userCommandService)
{
    while (true)
    {
        Console.WriteLine("Choose command");
        Console.WriteLine("1 - Look all procedurs");
        Console.WriteLine("2 - Look empty time for record");
        Console.WriteLine("3 - Create record");
        Console.WriteLine("4 - Look list future records");
        Console.WriteLine("5 - Cancel record");
        Console.WriteLine("6 - Look history records");
        Console.WriteLine("7 - Logout");
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
                userCommandService.CreateNewRecord(myUser.Phone);
                break;
            case "4":
                userCommandService.ShowFutureRecord(myUser);
                break;
            case "5":
                userCommandService.CancelRecord(myUser);
                break;
            case "6":
                userCommandService.ShowPastRecord(myUser);
                break;
            case "7":
                return;
        }
    }
}