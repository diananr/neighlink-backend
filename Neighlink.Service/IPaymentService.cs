using System.Collections.Generic;
using Neighlink.Entity;

namespace Neighlink.Service
{
    public interface IPaymentService:ICrudService<Payment>
    {
         IEnumerable<Payment> GetPaymentByBill(int billId);
         IEnumerable<Payment> GetPaymentsByUser(int userId);
    }
}