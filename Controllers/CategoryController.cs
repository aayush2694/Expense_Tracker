using Project_Expense_Tracker.context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Expense_Tracker.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        //category crud
        DB_Expense_TrackerEntities dbObj = new DB_Expense_TrackerEntities();
        public ActionResult Category(category obj)
        {
            if (obj != null)
                return View(obj);
            else
                return View();
        }

        [HttpPost]

        //updates the records
        public ActionResult AddCategory(category model)
        {
            category obj = new category();
            if (ModelState.IsValid)
            {

                obj.CAT_id = model.CAT_id;
                obj.CATEGORY_TITLE = model.CATEGORY_TITLE;
                obj.CATEGORY_AMOUNT = model.CATEGORY_AMOUNT;

                if (model.CAT_id == 0)
                {
                    dbObj.categories.Add(obj);
                    dbObj.SaveChanges();
                }

                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }
            }
            ModelState.Clear();
            return View("Category");
        }

       
        //returns the list
        public ActionResult CategoryList()
        {
            var res = dbObj.categories.ToList();
            return View();
        }

        [HttpGet]
        //delete
        public ActionResult Delete(int id)
        {
            var res = dbObj.categories.Where(x => x.CAT_id == id).First();
            dbObj.categories.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.categories.ToList();
            return RedirectToAction("CategoryList",list);

        }


        //expense crud

        public ActionResult Expense()
        {
            var list = dbObj.categories.ToList();
            ViewBag.CAT_id = new SelectList(list, "CAT_id", "CATEGORY_TITLE");
            return View();
        }

        [HttpPost]
        public ActionResult AddExpense(expense model)
        {
            expense obj = new expense();
            if(ModelState.IsValid)
            {
                obj.EXPENSE_TITLE = model.EXPENSE_TITLE;
                obj.EXPENSE_AMOUNT = model.EXPENSE_AMOUNT;
                obj.CAT_id = model.CAT_id;
                obj.DISCRIPTION = model.DISCRIPTION;
                obj.DATE_TIME = DateTime.Now;

                dbObj.expenses.Add(obj);
                dbObj.SaveChanges();

                return RedirectToAction("Expense");
            }
            ModelState.Clear();
            return View("Expense");

        }
        

        public ActionResult Delete()
        {
            return View();
        }
        //expenses
        public ActionResult ExpenseList()
        {
            var res = dbObj.expenses.ToList();
            ViewBag.id = new SelectList(res, "id", "EXPENSE_TITLE");

            var list = dbObj.expenses.ToList();
            dbObj.SaveChanges();
            return View(res);
        }

        //editexpenses
        [HttpPost]
        public ActionResult EditExpense(expense Ed )
        {
            var list = dbObj.categories.ToList();
            ViewBag.CAT_id = new SelectList(list, "CAT_id", "CATEGORY_TITLE");

            expense Eobj = new expense();
            if(ModelState.IsValid)
            {
                Eobj.EXPENSE_TITLE = Ed.EXPENSE_TITLE;
                Eobj.EXPENSE_AMOUNT = Ed.EXPENSE_AMOUNT;
                Eobj.DISCRIPTION = Ed.DISCRIPTION;
                Eobj.DATE_TIME = Ed.DATE_TIME;

                dbObj.Entry(Eobj).State = EntityState.Modified;

                dbObj.SaveChanges();
                TempData["msg"] = "Record Updated Successfully";

                return RedirectToAction("ExpenseList");
            }
            ModelState.Clear();
            return View();
        }

        //deletexpenses
        public ActionResult DeleteExpense(int ExpenseID)
        {
            var res = dbObj.expenses.Where(x => x.id == ExpenseID).First();
            dbObj.expenses.Remove(res);
            dbObj.SaveChanges();

            var List = dbObj.expenses.ToList();

            return View( "ExpenseList",List);
        }

        //dashboardview
        public ActionResult Dashboard()
        {
            return View();
        }

        //total expenses

        [HttpGet]
        public ActionResult TotalLimit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTotalLimit(totallimit model)
        {
            totallimit obj = new totallimit();
            obj.TOTAL_LIMIT = model.TOTAL_LIMIT;

            dbObj.totallimits.Add(obj);
            dbObj.SaveChanges();
            return View();
        }


    }

    

}