using MVCPublishersProject.DataBase;
using MVCPublishersProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPublishersProject.Controllers
{
    public class PublisherController : Controller
    {
        protected PublishersDB context;
        protected DbSet Set;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            context = BataBaseContext.DataBase;
            Set = context.Publisher;
            base.Initialize(requestContext);
        }

        protected void InitializeViewBag()
        {
            ViewBag.Phones = context.PhoneType;
        }



        public virtual ActionResult Index()
        {
            return View(this.Set);
        }

        public virtual ActionResult Create()
        {
            InitializeViewBag();
            return View();
        }

        [HttpPost]
        public JsonResult Create(Publisher publisher)
        {
            try
            {
                InitializeViewBag();


                if (ModelState.IsValid)
                {
                    // Perform Update
                    if (publisher.ID > 0)
                    {

                        var SUB = context.Phone.Where(p => p.Publisher.ID == publisher.ID);

                        foreach (Phone ss in SUB)
                            context.Phone.Remove(ss);

                        foreach (Phone ss in publisher.Phone)
                            context.Phone.Add(ss);

                        context.Entry(publisher).State = EntityState.Modified;
                    }
                    //Perform Save
                    else
                    {
                        // the model that gets posted to the WebApi controller is 
                        // detached from any entity-framework(EF) context, 
                        // the only option is to load the object graph
                        List<Phone> phones = publisher.Phone.ToList();

                        foreach (var item in phones)
                        {
                            publisher.Phone.Remove(item);
                        }

                        foreach (var item in phones)
                        {
                            publisher.Phone.Add(item);
                        }

                        context.Entry(publisher).State = EntityState.Added;
                        context.Publisher.Add(publisher);
                    }

                    context.SaveChanges();

                    // If Sucess== 1 then Save/Update Successfull else there it has Exception
                    return Json(new { Success = 1, ID = publisher.ID, ex = "" });
                }
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            InitializeViewBag();
            Publisher publisher = context.Publisher.Find(id);
            //Call Create View
            return View("Create", publisher);
        }   

        public ActionResult Delete(int id)
        {
            Publisher publisher = context.Publisher.FirstOrDefault(m => m.ID == id);
            return View(publisher);
        }

        //
        // POST: /Publisher/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Publisher publisher = context.Publisher.FirstOrDefault(m => m.ID == id);
                context.Publisher.Remove(publisher);

                context.Entry(publisher).State = EntityState.Deleted;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            Publisher publisher = context.Publisher.FirstOrDefault(m => m.ID == id);
            return View(publisher);
        }
    }
}
