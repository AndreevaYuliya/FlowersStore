using FlowersStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FlowersStore.Controllers
{
    public class Payment_methodController : Controller
    {
        private FlowersStoreDB db = new FlowersStoreDB();

        // GET: Payment_method
        public ActionResult Index()
        {
            var payment_method = db.Payment_method.Include(p => p.customer);
            return View(payment_method.ToList());
        }

        // GET: Payment_method/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_method payment_method = db.Payment_method.Find(id);
            if (payment_method == null)
            {
                return HttpNotFound();
            }
            return View(payment_method);
        }

        // GET: Payment_method/Create
        public ActionResult Create()
        {
            ViewBag.id_customer = new SelectList(db.Customers, "id", "surname");
            return View();
        }

        // POST: Payment_method/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_customer,payment_method1")] Payment_method payment_method)
        {
            if (ModelState.IsValid)
            {
                db.Payment_method.Add(payment_method);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_customer = new SelectList(db.Customers, "id", "surname", payment_method.id_customer);
            return View(payment_method);
        }

        // GET: Payment_method/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_method payment_method = db.Payment_method.Find(id);
            if (payment_method == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_customer = new SelectList(db.Customers, "id", "surname", payment_method.id_customer);
            return View(payment_method);
        }

        // POST: Payment_method/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_customer,payment_method1")] Payment_method payment_method)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment_method).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_customer = new SelectList(db.Customers, "id", "surname", payment_method.id_customer);
            return View(payment_method);
        }

        // GET: Payment_method/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment_method payment_method = db.Payment_method.Find(id);
            if (payment_method == null)
            {
                return HttpNotFound();
            }
            return View(payment_method);
        }

        // POST: Payment_method/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment_method payment_method = db.Payment_method.Find(id);
            db.Payment_method.Remove(payment_method);
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
