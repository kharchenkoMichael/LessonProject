
using BussinesLogic;
using Storage;
using System.Runtime.CompilerServices;

namespace UserInterface
{
    public class AdminCommandService
    {
        private RecordService _recordService;
        public AdminCommandService(RecordService recordService)
        {
            _recordService = recordService;
        }
        public void ApproveRecord(User myUser)
        {
            throw new NotImplementedException();
        }

        public void CancelRecord(User myUser)
        {
            throw new NotImplementedException();
        }

        public void CreateNewRecord(string phone)
        {
            throw new NotImplementedException();
        }

        public void ShowAllFutureRecords()
        {
            var records = _recordService.GetFutureRecords();
            foreach (var record in records.OrderBy(item => item.DateTime))
            {
                Console.WriteLine($"{record.Procedur}, {record.UserPhone}, {record.DateTime}");
            }
        }

        public void ShowAllHistoryRecords()
        {
            var records = _recordService.GetHistoryRecords();
            foreach(var record in records.OrderBy(item => item.DateTime))
            {
                Console.WriteLine($"{record.Procedur}, {record.UserPhone}, {record.DateTime}");
            }
        }

        public void ShowAllNotApproveRecord(User myUser)
        {
            throw new NotImplementedException();
        }
    }
}
