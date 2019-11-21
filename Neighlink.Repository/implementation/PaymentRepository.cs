using System.Collections.Generic;
using System.Linq;
using Neighlink.Entity;
using Neighlink.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Neighlink.Repository.implementation
{
    public class PaymentRepository : IPaymentRepository
    {
        private ApplicationDbContext context;
        public PaymentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
             try
            {
                var result = new Payment();
                result = context.Payments.Single(x => x.Id == id);
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch(System.Exception)
            {
            throw;
            }
        }

        public Payment Get(int id)
        {
             var result = new Payment();
            try{
                result = context.Payments.Single(x =>x.Id == id);
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Payment> GetAll()
        {
            var result = new List<Payment>();
            try
            {
                result = context.Payments.ToList();
            }catch(System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Payment entity)
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

        public bool Update(Payment entity)
        {
            try{
                var paymentOrigin = context.Payments.Single(
                    x=> x.Id == entity.Id
                );

                paymentOrigin.Id = entity.Id;
                paymentOrigin.Amount = entity.Amount;
                paymentOrigin.PhotoUrl = entity.PhotoUrl;
                paymentOrigin.Status = entity.Status;
                paymentOrigin.PaymentDate = entity.PaymentDate;

                context.Update(paymentOrigin);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

         public IEnumerable<Payment> GetPaymentsByBill(int billId)
        {
             try
            {
                var payments = context.Payments.Where(x => x.BillId == billId);
                return payments;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public IEnumerable<Payment> GetPaymentsByUser(int userId)
        {
            try
            {
                var payments = context.Payments.Where(x => x.UserId == userId);
                return payments;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public IEnumerable<Payment> GetPaymentsByCondominium(int condominiumId)
        {
            try
            {
                var users = context.Users.Include(x => x.Payments).Where(y => y.CondominiumId == condominiumId);
                return users.SelectMany(x => x.Payments);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        
    }
}