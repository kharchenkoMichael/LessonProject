

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
        public IEnumerable<(DateTime,DateTime)> GetRecordsOnWeek()
        {
            return _dataBase.Records.Where(item => item.DateTime > DateTime.Now && item.DateTime < DateTime.Now.AddDays(7))
                .Join(_dataBase.Procedurs, record => record.Procedur, procedur => procedur.Name, (record, procedur) => (record.DateTime, record.DateTime.Add(procedur.Time)));
        }
    }
}
