using Neighlink.Entity;
using System.Collections.Generic;
namespace Neighlink.Repository
{
    public interface IBillRepository :ICrudRepository<Bill>
    {
        IEnumerable<Bill> GetBillByPaymentCategory(int PaymentCategoryId);
        IEnumerable<Bill> GetBillByBuilding(int PaymentCategoryId);
    }
}