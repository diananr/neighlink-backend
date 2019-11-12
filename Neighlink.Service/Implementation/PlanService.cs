using Neighlink.Entity;
using Neighlink.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neighlink.Service.Implementation
{
    public class PlanService : IPlanService
    {
        private ApplicationDbContext dbContext;

        public PlanService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int AddNewPlan(Plan plan)
        {
            dbContext.Plans.Add(plan);
            dbContext.SaveChanges();

            return plan.Id;
        }
    }
}
