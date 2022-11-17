using BussinesLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private RecordService _recordService;
        public RecordController(RecordService recordService)
        {
            _recordService = recordService;
        }
        [HttpGet("week")]
        public List<(DateTime, DateTime)> GetRecordsOnWeek()
        {
            return _recordService.GetRecordsOnWeek().ToList();
        }
        [HttpGet("history")]
        public List<Record> GetHistoryRecord()
        {
            return _recordService.GetHistoryRecords().ToList();
        }
        [HttpGet("not-approve")]
        public List<Record> GetAllNotApproveRecords()
        {
            return _recordService.GetAllNotApproveRecords().ToList();
        }
        [HttpGet("future")]
        public List<Record> GetFutureRecords()
        {
            return _recordService.GetFutureRecords().ToList();
        }
        [HttpPost("approve")]
        public IActionResult PostApprove([FromBody] Record record)
        {
            _recordService.ApproveRecord(record);
            return Ok();
        }
        [HttpPost("record")]
        public IActionResult CreateRecord([FromBody]Record record)
        {
            _recordService.CreateRecord(record);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteRecord([FromBody]Record record)
        {
            _recordService.DeleteRecord(record);
            return Ok();
        }
    }
}
