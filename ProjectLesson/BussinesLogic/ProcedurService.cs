

using Storage;

namespace BussinesLogic
{
    public class ProcedurService
    {
        private DataBase _dataBase;
        public ProcedurService()
        {
            _dataBase = new DataBase();
            _dataBase.InitDataBase();
        }
        public IEnumerable<Procedur> GetAllProcedurs()
        {
            return _dataBase.Procedurs;
        } 
    }
}
