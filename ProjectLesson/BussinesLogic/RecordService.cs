

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

           return _dataBase.Records.Where(item => item.DateTime > DateTime.Now && item.UserPhone == user.Phone);
        }
        public IEnumerable<Record> GetHistoryRecords(User user)
        {

            return _dataBase.Records.Where(item => item.DateTime < DateTime.Now && item.UserPhone == user.Phone);
        }
        public IEnumerable<(DateTime,DateTime)> GetRecordsOnWeek()
        {
            return _dataBase.Records.Where(item => item.DateTime > DateTime.Now && item.DateTime < DateTime.Now.AddDays(7))
                .Join(_dataBase.Procedurs, record => record.Procedur, procedur => procedur.Name, (record, procedur) => (record.DateTime, record.DateTime.Add(procedur.Time)));
        }
        public Record CreateRecord(string procedurName, DateTime dateTime,string userPhone)
        {
            var record = new Record();
            record.Procedur = procedurName;
            record.DateTime = dateTime;
            record.UserPhone = userPhone;
            _dataBase.Records.Add(record);
            _dataBase.Save();
            return record;


        }
        public IEnumerable<Record> GetFutureRecords()
        {

            return _dataBase.Records.Where(item => item.DateTime > DateTime.Now);
        }
        public IEnumerable<Record> GetHistoryRecords()
        {

            return _dataBase.Records.Where(item => item.DateTime < DateTime.Now);
        }
        public void DeleteRecord(Record record)
        {
            _dataBase.Records.Remove(record);
            _dataBase.Save();
        }
    }
}
