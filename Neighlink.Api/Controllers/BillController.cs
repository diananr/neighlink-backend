
using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;
using System.Collections.Generic;

namespace Neighlink.Api.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController:ControllerBase
    {
        private IBillService billService;

        public BillController(IBillService billService)
        {
            this.billService = billService;
        }

        [HttpGet]

        public ActionResult Get()
        {
            return Ok(
                billService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Bill bill)
        {
            return Ok(
                billService.Save(bill)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Bill bill)
        {
            return Ok(
                billService.Update(bill)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                billService.Delete(id)
            );
        }

         [HttpGet("by-paymentcategory/{PaymentCategoryId}")]
        public ActionResult<IEnumerable<Bill>> GetBills(int PaymentCategoryId)
        {
            return Ok(billService.GetBillByPaymentCategory(PaymentCategoryId));
        }

         [HttpGet("by-building/{building_id}")]
        public ActionResult<IEnumerable<User>> GetBills_2(int building_id)
        {
            return Ok(billService.GetBillByBuilding(building_id));
        }
        
      
    }
}