

using Storage;

namespace BussinesLogic
{
    public class RecordService
    {
        private DataBase _dataBase;
        public RecordService()
        {
            _dataBase = new DataBase();
            _dataBase.InitDataBase();
        }
        public IEnumerable<Record> GetFutureRecords(User user)
        {

           return _dataBase.Records.Where(item => item.DateTime > DateTime.Now && item.UserName == user.Name);
        }
        public IEnumerable<Record> GetHistoryRecords(User user)
        {

            return _dataBase.Records.Where(item => item.DateTime < DateTime.Now && item.UserName == user.Name);
        }
    }
}
