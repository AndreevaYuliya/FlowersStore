using FlowersStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FlowersStore.Controllers
{
    public class SuppliesController : Controller
    {
        private FlowersStoreDB db = new FlowersStoreDB();

        // GET: Supplies
        public ActionResult Index()
        {
            var supplies = db.Supplies.Include(s => s.bouquet).Include(s => s.flower).Include(s => s.supplier);
            return View(supplies.ToList());
        }

        // GET: Supplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // GET: Supplies/Create
        public ActionResult Create()
        {
            ViewBag.id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name");
            ViewBag.id_flowers = new SelectList(db.Flowers, "Id", "Flower_name");
            ViewBag.id_supplier = new SelectList(db.Suppliers, "id", "supplier_name");
            return View();
        }

        // POST: Supplies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_supplier,id_flowers,id_bouquets,quantity,price,date_supply")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Supplies.Add(supply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name", supply.id_bouquets);
            ViewBag.id_flowers = new SelectList(db.Flowers, "Id", "Flower_name", supply.id_flowers);
            ViewBag.id_supplier = new SelectList(db.Suppliers, "id", "supplier_name", supply.id_supplier);
            return View(supply);
        }

        // GET: Supplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name", supply.id_bouquets);
            ViewBag.id_flowers = new SelectList(db.Flowers, "Id", "Flower_name", supply.id_flowers);
            ViewBag.id_supplier = new SelectList(db.Suppliers, "id", "supplier_name", supply.id_supplier);
            return View(supply);
        }

        // POST: Supplies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_supplier,id_flowers,id_bouquets,quantity,price,date_supply")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name", supply.id_bouquets);
            ViewBag.id_flowers = new SelectList(db.Flowers, "Id", "Flower_name", supply.id_flowers);
            ViewBag.id_supplier = new SelectList(db.Suppliers, "id", "supplier_name", supply.id_supplier);
            return View(supply);
        }

        // GET: Supplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supply supply = db.Supplies.Find(id);
            db.Supplies.Remove(supply);
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
