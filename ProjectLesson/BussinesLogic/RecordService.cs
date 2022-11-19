

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
        public IEnumerable<Record> GetFutureRecords(string userPhone)
        {

           return _dataBase.Records.Where(item => item.DateTime > DateTime.Now && item.UserPhone == userPhone);
        }
        public IEnumerable<Record> GetHistoryRecords(string userPhone)
        {

            return _dataBase.Records.Where(item => item.DateTime < DateTime.Now && item.UserPhone == userPhone);
        }
        public IEnumerable<(DateTime,DateTime)> GetRecordsOnWeek()
        {
            return _dataBase.Records.Where(item => item.DateTime > DateTime.Now && item.DateTime < DateTime.Now.AddDays(7))
                .Join(_dataBase.Procedurs, record => record.Procedur, procedur => procedur.Name, (record, procedur) => (record.DateTime, record.DateTime.Add(procedur.Time)));
        }
        public Record CreateRecord(Record record)
        {
        
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
        public void DeleteRecord(int id)
        {
            var record = _dataBase.Records.FirstOrDefault(item => item.Id == id);
            if (record == null)
            {
                //TODO:throw error not found
                return;
            }
            _dataBase.Records.Remove(record);
            _dataBase.Save();
        }
        public IEnumerable<Record> GetAllNotApproveRecords()
        {
            return _dataBase.Records.Where(item => !item.IsApproved);
        }
        public void ApproveRecord(Record record)
        {
            record.IsApproved = true;
            _dataBase.Save();
        }
    }
}
