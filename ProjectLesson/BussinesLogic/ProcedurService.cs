

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
        public Procedur? GetProcedurByName(string procedurName)
        {
            return _dataBase.Procedurs.FirstOrDefault(item => item.Name == procedurName);
        }
    }
}
