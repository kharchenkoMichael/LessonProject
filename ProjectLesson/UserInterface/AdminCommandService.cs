
using BussinesLogic;
using Storage;
using System.Runtime.CompilerServices;

namespace UserInterface
{
    public class AdminCommandService
    {
        private RecordService _recordService;
        private ProcedurService _procedurService;
        private UserService _userService;
       
        public AdminCommandService(RecordService recordService, ProcedurService procedurService, UserService userService)
        {
            _procedurService = procedurService;
            _recordService = recordService;
            _userService = userService; 
        }
        public void ApproveRecord(User myUser)
        {
            throw new NotImplementedException();
        }

        public void CancelRecord()
        {
            int index = 1;
            var records = _recordService.GetFutureRecords().ToList();
            foreach (var item in records)
            {
                Console.WriteLine($"{index++} : {item.DateTime}, {item.Procedur},{item.UserPhone}, {item.IsApproved}");
            }
            while (true)
            {
                Console.WriteLine("Введите число которое хотите удалить");
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    if (index > 0 && index <= records.Count())
                    {
                        break;
                    }
                }
            }
            var record = records[index - 1];
            _recordService.DeleteRecord(record);
            Console.WriteLine("Ваша дата успешно удалена");
        }

        public void CreateNewRecord()
        {
            string procedurName = "";
            string phone = "";
            DateTime date = new DateTime();
            while (true)
            {
                Console.WriteLine("Введите название процедуры");
                procedurName = Console.ReadLine();
                var procedur = _procedurService.GetProcedurByName(procedurName);
                if (procedur != null)
                {
                    break;
                }

            }
            while (true)
            {
                Console.WriteLine("Введите дату");
                string dateString = Console.ReadLine();
                if (DateTime.TryParse(dateString, out date))
                {
                    break;
                }


            }
            while (true)
            {
                Console.WriteLine("Введите номер телефона клиента");
                phone = Console.ReadLine();
                var user = _userService.GetUserByPhone(phone);
                if(user != null)
                {
                    break;
                }

            }
            _recordService.CreateRecord(procedurName, date, phone,true);
            Console.WriteLine("Запись добавлена");
        }

        public void ShowAllFutureRecords()
        {
            var records = _recordService.GetFutureRecords();
            foreach (var record in records.OrderBy(item => item.DateTime))
            {
                Console.WriteLine($"{record.Procedur}, {record.UserPhone}, {record.DateTime}, {record.IsApproved}");
            }
        }

        public void ShowAllHistoryRecords()
        {
            var records = _recordService.GetHistoryRecords();
            foreach(var record in records.OrderBy(item => item.DateTime))
            {
                Console.WriteLine($"{record.Procedur}, {record.UserPhone}, {record.DateTime}, {record.IsApproved}");
            }
        }

        public void ShowAllNotApproveRecord()
        {
            var records = _recordService.GetAllNotApproveRecords();
            foreach( var record in records.OrderBy(item => item.DateTime))
            {
                Console.WriteLine($"{record.Procedur}, {record.UserPhone}, {record.DateTime}, {record.IsApproved}");
            }
        }
    }
}
