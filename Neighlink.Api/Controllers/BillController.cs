namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController:ControllerBase
    {
        private IBillService billService;
        public BuillController(IBillService billService)
        {
            this.billService=billService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(billService.GetAll());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Bill bill)
        {
            return Ok(billService.Save(bill));
        }

         [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(billService.Delete(id));
        }
    }
}