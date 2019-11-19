using Neighlink.Entity;
using System.Collections.Generic;

namespace Neighlink.Repository
{
    public interface IPaymentCategoryRepository:ICrudRepository<PaymentCategory>
    {
         IEnumerable<Building> GetBuildingsByCondominium(int condominiumId);
    }
}