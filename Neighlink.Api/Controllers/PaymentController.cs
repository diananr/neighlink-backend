using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Neighlink.Entity;
using Neighlink.Service;

namespace Neighlink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController :ControllerBase
    {
    private IPaymentService paymentService;
    public PaymentController(IPaymentService paymentService)
    {
        this.paymentService = paymentService;
    }

    [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                paymentService.GetAll()
            );
        }

    [HttpPost]
        public ActionResult Post([FromBody] Payment payment)
        {
            return Ok(
                paymentService.Save(payment)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Payment payment)
        {
            return Ok(
                paymentService.Update(payment)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                paymentService.Delete(id)
            );
        }

        [HttpGet("by-bill/{billId}")]
        public ActionResult<IEnumerable<Bill>> GetBills(int billId)
        {
            return Ok(paymentService.GetPaymentByBill(billId));
        }
                        
        [HttpGet("by-user/{userId}")]
        public ActionResult<IEnumerable<User>> GetUsers(int userId)
        {
            return Ok(paymentService.GetPaymentsByUser(userId));
        }


    }
}