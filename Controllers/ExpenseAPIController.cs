//using Project_Expense_Tracker.context;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace Project_Expense_Tracker.Controllers
//{


//    public class ExpenseAPIController : ApiController
//    {
//        DB_Expense_TrackerEntities dbcontext = new DB_Expense_TrackerEntities();
//        public class IEnumerable<expenses> Get()
//        {
//            using (DB_Expense_TrackerEntities dbcontext = new DB_Expense_TrackerEntities())
//            {
//                // return dbcontext.expenses.Include(e => e.category).ToList();
//                return dbcontext.expenses.Include(e => e.category).ToList();
//            }
//        }

//        public expense Get(int id)
//        {
//            using (DB_Expense_TrackerEntities dbcontext = new DB_Expense_TrackerEntities())
//            {
//                // return dbcontext.expenses.Include(e => e.expenses).FirstOrDefault(e => e.id = id);
//                return dbcontext.expenses.Include(e => e.category).FirstOrDefault(e => e.id == id);
//            }
//        }

//        [HttpGet]
//        public IEnumerable<expense> CategoryView(int id)
//        {
//            return dbcontext.expenses.Include(e => e.category).Where(e => e.CAT_id == id).ToList;
//        }

//    }
//}
