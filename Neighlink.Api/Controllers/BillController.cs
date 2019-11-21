using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;
using System.Collections.Generic;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController :ControllerBase
    {
        private IBillService billService;

        public BillController(IBillService billService)
        {
            this.billService = billService;
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
        public ActionResult<IEnumerable<Bill>> GetBillsByPaymentCategory(int PaymentCategoryId)
        {
            return Ok(billService.GetBillsByPaymentCategory(PaymentCategoryId));
        }

        [HttpGet("by-building/{BuildingId}")]
        public ActionResult<IEnumerable<Bill>> GetBillByBuilding(int BuildingId)
        {
            return Ok(billService.GetBillsByBuilding(BuildingId));
        }

        [HttpGet("by-condominium/{CondominiumId}")]
        public ActionResult<IEnumerable<Bill>> GetBillsByCondominium(int CondominiumId)
        {
            return Ok(billService.GetBillsByCondominium(CondominiumId));
        }

        [HttpGet("byId/{id}")]
        public ActionResult<Bill> Get(int id)
        {
            return Ok(billService.Get(id));
        }
    }
}