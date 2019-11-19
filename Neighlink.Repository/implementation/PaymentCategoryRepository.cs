using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Neighlink.Entity;
using Neighlink.Repository.Context;

namespace Neighlink.Repository.implementation
{
    public class PaymentCategoryRepository : IPaymentCategoryRepository
    {
        private ApplicationDbContext context;
        public PaymentCategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var result = new PaymentCategory();
                result = context.PaymentCategories.Single(x => x.Id == id);
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch(System.Exception)
            {
            throw;
            }
        }

        public PaymentCategory Get(int id)
        {
            var result = new PaymentCategory();
            try{
                result = context.PaymentCategories.Single(x =>x.Id == id);
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<PaymentCategory> GetAll()
        {
            var result = new List<PaymentCategory>();
            try
            {
                result = context.PaymentCategories.ToList();
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(PaymentCategory entity)
        {
            try{
                context.Add(entity);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(PaymentCategory entity)
        {
            try{
                var paymentcategoryOrigin = context.PaymentCategories.Single(
                    x=> x.Id == entity.Id
                );

                paymentcategoryOrigin.Id = entity.Id;
                paymentcategoryOrigin.Name = entity.Name;
                paymentcategoryOrigin.Status = entity.Status;
                paymentcategoryOrigin.Description = entity.Description;
                context.Update(paymentcategoryOrigin);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<PaymentCategory> GetBuildingsByCondominium(int condominiumId)
        {
            try
            {
                var paymentCategories = context.PaymentCategories.Where(x => x.CondominiumId == condominiumId);
                return paymentCategories;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

    }
}