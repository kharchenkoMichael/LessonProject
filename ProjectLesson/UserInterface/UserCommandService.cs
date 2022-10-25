

using BussinesLogic;

namespace UserInterface
{
    public class UserCommandService
    {
        private ProcedurService _procedurService;
        public UserCommandService(ProcedurService procedurService)
        {
            _procedurService = procedurService;
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
        public void ShowFutureRecord()
        {

        }
        public void CancelRecord()
        {

        }
        public void ShowPastRecord()
        {

        }
    }
}
