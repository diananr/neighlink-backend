using Neighlink.Entity;
using System.Collections.Generic;

namespace Neighlink.Service
{
    public interface IBillService:ICrudService<Bill>
    {
        IEnumerable<Bill> GetBillByPaymentCategory(int PaymentCategoryId);
        IEnumerable<Bill> GetBillByBuilding(int BuildingId);
    }
}