using FlowersStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FlowersStore.Controllers
{
    public class Ordered_servicesController : Controller
    {
        private FlowersStoreDB db = new FlowersStoreDB();

        // GET: Ordered_services
        public ActionResult Index()
        {
            var ordered_services = db.Ordered_services.Include(o => o.order).Include(o => o.service);
            return View(ordered_services.ToList());
        }

        // GET: Ordered_services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordered_services ordered_services = db.Ordered_services.Find(id);
            if (ordered_services == null)
            {
                return HttpNotFound();
            }
            return View(ordered_services);
        }

        // GET: Ordered_services/Create
        public ActionResult Create()
        {
            ViewBag.id_order = new SelectList(db.Orders, "Id", "Customer_city");
            ViewBag.id_services = new SelectList(db.Services, "id", "service_name");
            return View();
        }

        // POST: Ordered_services/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_order,id_services,quantity")] Ordered_services ordered_services)
        {
            if (ModelState.IsValid)
            {
                db.Ordered_services.Add(ordered_services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_order = new SelectList(db.Orders, "Id", "Customer_city", ordered_services.id_order);
            ViewBag.id_services = new SelectList(db.Services, "id", "service_name", ordered_services.id_services);
            return View(ordered_services);
        }

        // GET: Ordered_services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordered_services ordered_services = db.Ordered_services.Find(id);
            if (ordered_services == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_order = new SelectList(db.Orders, "Id", "Customer_city", ordered_services.id_order);
            ViewBag.id_services = new SelectList(db.Services, "id", "service_name", ordered_services.id_services);
            return View(ordered_services);
        }

        // POST: Ordered_services/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_order,id_services,quantity")] Ordered_services ordered_services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordered_services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_order = new SelectList(db.Orders, "Id", "Customer_city", ordered_services.id_order);
            ViewBag.id_services = new SelectList(db.Services, "id", "service_name", ordered_services.id_services);
            return View(ordered_services);
        }

        // GET: Ordered_services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordered_services ordered_services = db.Ordered_services.Find(id);
            if (ordered_services == null)
            {
                return HttpNotFound();
            }
            return View(ordered_services);
        }

        // POST: Ordered_services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordered_services ordered_services = db.Ordered_services.Find(id);
            db.Ordered_services.Remove(ordered_services);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
