using FlowersStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FlowersStore.Controllers
{
    public class SalesController : Controller
    {
        private FlowersStoreDB db = new FlowersStoreDB();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.bouquet).Include(s => s.customer).Include(s => s.employee).Include(s => s.flower);
            return View(sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name");
            ViewBag.id_customer = new SelectList(db.Customers, "id", "surname");
            ViewBag.id_employee = new SelectList(db.Employees, "id", "surname");
            ViewBag.id_flowers = new SelectList(db.Flowers, "Id", "Flower_name");
            return View();
        }

        // POST: Sales/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_employee,id_flowers,id_bouquets,id_customer,quantity,date_sale")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name", sale.id_bouquets);
            ViewBag.id_customer = new SelectList(db.Customers, "id", "surname", sale.id_customer);
            ViewBag.id_employee = new SelectList(db.Employees, "id", "surname", sale.id_employee);
            ViewBag.id_flowers = new SelectList(db.Flowers, "Id", "Flower_name", sale.id_flowers);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name", sale.id_bouquets);
            ViewBag.id_customer = new SelectList(db.Customers, "id", "surname", sale.id_customer);
            ViewBag.id_employee = new SelectList(db.Employees, "id", "surname", sale.id_employee);
            ViewBag.id_flowers = new SelectList(db.Flowers, "Id", "Flower_name", sale.id_flowers);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_employee,id_flowers,id_bouquets,id_customer,quantity,date_sale")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name", sale.id_bouquets);
            ViewBag.id_customer = new SelectList(db.Customers, "id", "surname", sale.id_customer);
            ViewBag.id_employee = new SelectList(db.Employees, "id", "surname", sale.id_employee);
            ViewBag.id_flowers = new SelectList(db.Flowers, "Id", "Flower_name", sale.id_flowers);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
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
