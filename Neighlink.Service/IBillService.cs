using Neighlink.Entity;
using System.Collections.Generic;

namespace Neighlink.Service
{
    public interface IBillService:ICrudService<Bill>
    {
          IEnumerable<Bill> GetBillByPaymentCategory(PaymentCategory paymentCategory_id);
           IEnumerable<Bill> GetBillByBuilding(Building building_id);
    }
}