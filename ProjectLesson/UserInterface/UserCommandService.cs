

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

        }
        public void CreateNewRecord()
        {

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
