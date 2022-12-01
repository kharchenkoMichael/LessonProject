

using Storage;
using Storage.Response;

namespace BussinesLogic
{
    public class RecordService
    {
        private DataBase _dataBase;
        public RecordService(DataBase dataBase)
        {
            _dataBase = dataBase;
        }
        public IEnumerable<Record> GetFutureRecords(string userPhone)
        {

           return _dataBase.Records.Where(item => item.DateTime > DateTime.Now && item.UserPhone == userPhone);
        }
        public IEnumerable<Record> GetHistoryRecords(string userPhone)
        {

            return _dataBase.Records.Where(item => item.DateTime < DateTime.Now && item.UserPhone == userPhone);
        }
        public IEnumerable<RecordTuppleResponse> GetRecordsOnWeek()
        {
            return _dataBase.Records.Where(item => item.DateTime > DateTime.Now && item.DateTime < DateTime.Now.AddDays(7))
            .Join(_dataBase.Procedurs, record => record.ProcedurId, procedur => procedur.Id,
            (record, procedur) => new RecordTuppleResponse() { RecordStart = record.DateTime, RecordEnd = record.DateTime.Add(procedur.Time) });
        }
        public Record CreateRecord(Record record)
        {
        
            _dataBase.Records.Add(record);
            _dataBase.SaveChanges();
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
            _dataBase.SaveChanges();
        }
        public IEnumerable<Record> GetAllNotApproveRecords()
        {
            return _dataBase.Records.Where(item => !item.IsApprove);
        }
        public void ApproveRecord(Record record)
        {
            record.IsApprove = true;
            _dataBase.SaveChanges();
        }
    }
}
