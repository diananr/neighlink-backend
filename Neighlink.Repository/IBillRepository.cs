using Neighlink.Entity;
using System.Collections.Generic;
namespace Neighlink.Repository
{
    public interface IBillRepository :ICrudRepository<Bill>
    {
          IEnumerable<Bill> GetBillByPaymentCategory(PaymentCategory paymentCategory_id);
          IEnumerable<Bill> GetBillByBuilding(Building building_id);
    }
}