using System.Collections.Generic;
using Neighlink.Entity;
using Neighlink.Repository.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Neighlink.Repository.implementation
{
    public class BillRepository : IBillRepository
    {
        private ApplicationDbContext context;
        public BillRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var result = new Bill();
                result=context.Bills.Single(x =>x.Id ==id);
                context.Remove(result);
                context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Bill Get(int id)
        {
            var result= new Bill();
            try
            {
                result=context.Bills.Single(x=>x.Id==id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Bill> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Save(Bill entity)
        {
            try
            {
                var matchingBuilding = context.Buildings.Include(y => y.Users).Where(x => x.Id == entity.BuildingId).FirstOrDefault();
                var amountOfOwners = matchingBuilding.Users.Count;

                context.Add(entity);
                context.SaveChanges();

                foreach (var user in matchingBuilding.Users)
                {
                    Payment payment = new Payment()
                    {
                        Amount = Convert.ToInt32(entity.Amount / amountOfOwners),
                        BillId = entity.Id,
                        UserId = user.Id
                    };

                    if (user.Payments == null)
                        user.Payments = new List<Payment>();

                    user.Payments.Add(payment);
                }

                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Bill entity)
        {
            try
            {
                var billOrigin=context.Bills.Single(x=>x.Id==entity.Id);
                billOrigin.Name=entity.Name;
                billOrigin.Amount=entity.Amount;
                billOrigin.Description=entity.Description;
                billOrigin.PaymentCategoryId=entity.PaymentCategoryId;
                billOrigin.BuildingId=entity.BuildingId;
                billOrigin.Status=entity.Status;
                context.Update(billOrigin);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Bill> GetBillsByPaymentCategory(int PaymentCategoryId)
        {
            try
            {
                var bills = context.Bills.Where(x => x.PaymentCategoryId == PaymentCategoryId);
                return bills;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public IEnumerable<Bill> GetBillsByBuilding(int BuildingId)
        {
            try
            {
                var bills = context.Bills.Where(x => x.BuildingId == BuildingId);
                return bills;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public IEnumerable<Bill> GetBillsByCondominium(int CondominiumId)
        {
            try
            {
                var buildings = context.Buildings.Include(x => x.Bills).Where(y => y.CondominiumId == CondominiumId);
                return buildings.SelectMany(x => x.Bills);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}