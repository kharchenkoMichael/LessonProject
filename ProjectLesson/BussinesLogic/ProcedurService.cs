

using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Storage;

namespace BussinesLogic
{
    public class ProcedurService
    {
        private DataBase _dataBase;
        public ProcedurService(DataBase dataBase)
        {
            _dataBase = dataBase;

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
