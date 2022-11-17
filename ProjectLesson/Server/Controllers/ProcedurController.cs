using BussinesLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedurController : ControllerBase
    {
        private ProcedurService _procedurService;
        public ProcedurController(ProcedurService procedurService)
        {
            _procedurService = procedurService;
        }

        [HttpGet("{procedurName}")]
        public Procedur? GetProcedutByName(string procedurName)
        {
            return _procedurService.GetProcedurByName(procedurName);
        }
        [HttpGet]
        public List<Procedur> GetAllProcedurs()
        {
            return _procedurService.GetAllProcedurs().ToList();
        } 
    }
}
