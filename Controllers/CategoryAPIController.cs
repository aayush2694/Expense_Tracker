using Project_Expense_Tracker.context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project_Expense_Tracker.Controllers
{
    public class CategoryAPIController : ApiController
    {
        DB_Expense_TrackerEntities dbcontext = new DB_Expense_TrackerEntities();
        public IEnumerable<category> Get()
        {
            using (DB_Expense_TrackerEntities dbcontext=new DB_Expense_TrackerEntities())
            {
                return dbcontext.categories.ToList();

            }
        }

        public category Get(int id)
        {
            using (DB_Expense_TrackerEntities dbcontext = new DB_Expense_TrackerEntities())
            {
                return dbcontext.categories.FirstOrDefault(p=>p.CAT_id==id);

            }
        }
    }
}
