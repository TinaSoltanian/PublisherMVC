using MVCPublishersProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MVCPublishersProject.DataBase;

namespace MVCPublishersProject.Controllers
{
    public class BaseController<T> : Controller where T : BusinessObject
    {
        //
        // GET: /Base/

        protected PublishersDB context;
        protected DbSet<T> Set;

        protected virtual void InitializeViewBag()
        {
        }

        protected T FromID(long id)
        {
            return this.Set
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            //context = new PublishersDB();
            context = BataBaseContext.DataBase;
            Set = context.Set<T>();
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
        public virtual ActionResult Create(T instance)
        {
            InitializeViewBag();
            if (!this.ModelState.IsValid)
            {
                //this.InitializeViewBag(ViewBagMode.Create);
                return View(instance);
            }

            this.Set.Add(instance);
            this.context.SaveChanges();

            return RedirectToAction("Index");
        }

        public virtual ActionResult Edit(long id)
        {
            //this.InitializeViewBag(ViewBagMode.Edit);
            return View(this.FromID(id));
        }

        [HttpPost]
        public virtual ActionResult Edit(T instance)
        {
            if (!ModelState.IsValid)
            {
                return View(instance);
            }

            this.context.Entry(instance).State = EntityState.Modified;
            this.context.SaveChanges();

            return RedirectToAction("Index");
        }

        public virtual ActionResult Delete(long id)
        {
            return View(this.FromID(id));
        }

        [HttpPost]
        public virtual ActionResult Delete(T instance)
        {

            this.context.Entry(instance).State = EntityState.Deleted;
            this.context.SaveChanges();

            return RedirectToAction("Index");
        }

        public virtual ActionResult Details(long id)
        {
            return View(FromID(id));
        }
    }
}