

using BussinesLogic;
using Storage;

namespace UserInterface
{
    public class UserCommandService
    {
        private RecordService _recordService;
        private ProcedurService _procedurService;
        public UserCommandService(ProcedurService procedurService, RecordService recordService)
        {
            _procedurService = procedurService;
            _recordService = recordService;
        }

        public void ShowAllProcedurs()
        {
            var procedurs = _procedurService.GetAllProcedurs();
            foreach (var item in procedurs)
            {
                Console.WriteLine($"{item.Name}, {item.Price}, {item.Time}");
            }
            Console.WriteLine("------------------");
        }
        public void ShowFreeDates()
        {
            var records = _recordService.GetRecordsOnWeek();
            Console.WriteLine("Я работа с 10 - 18, но у меня уже есть записи на такое то время");
            foreach (var item in records.OrderBy(item => item.Item1))
            {
                Console.WriteLine($"{item.Item1} - {item.Item2}");
            }
            Console.WriteLine("-------------------");
        }
        public void CreateNewRecord(string userName)
        {
            string procedurName = "";
            DateTime date = new DateTime();
            while (true)
            {
                Console.WriteLine("Введите название процедуры");
                procedurName = Console.ReadLine();
                var procedur = _procedurService.GetProcedurByName(procedurName);
                if(procedur != null)
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
            _recordService.CreateRecord(procedurName, date, userName);
            Console.WriteLine("Запись добавлена");
        }
        public void ShowFutureRecord(User user)
        {
            var records = _recordService.GetFutureRecords(user);
            foreach(var item in records)
            {
                Console.WriteLine($"{item.DateTime}, {item.Procedur}");
            }
        }
        public void CancelRecord()
        {

        }
        public void ShowPastRecord(User user)
        {
            var records = _recordService.GetHistoryRecords(user);
            foreach (var item in records)
            {
                Console.WriteLine($"{item.DateTime}, {item.Procedur}");
            }
        }
    }
}
