using FlowersStore.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FlowersStore.Controllers
{
    public class OrderedsController : Controller
    {
        private FlowersStoreDB db = new FlowersStoreDB();

        // GET: Ordereds
        public ActionResult Index()
        {
            var ordereds = db.Ordereds.Include(o => o.Bouquet).Include(o => o.Flower).Include(o => o.Order);
            return View(ordereds.ToList());
        }

        // GET: Ordereds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordered ordered = db.Ordereds.Find(id);
            if (ordered == null)
            {
                return HttpNotFound();
            }
            return View(ordered);
        }

        // GET: Ordereds/Create
        public ActionResult Create()
        {
            ViewBag.Id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name");
            ViewBag.Id_flower = new SelectList(db.Flowers, "Id", "Flower_name");
            ViewBag.Id_order = new SelectList(db.Orders, "Id", "Customer_city");
            return View();
        }

        // POST: Ordereds/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_order,Quantity,Id_flower,Id_bouquets,Unit_priceFlower,Unit_priceBouquet,Flower_name,Bouquet_name")] Ordered ordered)
        {
            if (ModelState.IsValid)
            {
                db.Ordereds.Add(ordered);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name", ordered.Id_bouquets);
            ViewBag.Id_flower = new SelectList(db.Flowers, "Id", "Flower_name", ordered.Id_flower);
            ViewBag.Id_order = new SelectList(db.Orders, "Id", "Customer_city", ordered.Id_order);
            return View(ordered);
        }

        // GET: Ordereds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordered ordered = db.Ordereds.Find(id);
            if (ordered == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name", ordered.Id_bouquets);
            ViewBag.Id_flower = new SelectList(db.Flowers, "Id", "Flower_name", ordered.Id_flower);
            ViewBag.Id_order = new SelectList(db.Orders, "Id", "Customer_city", ordered.Id_order);
            return View(ordered);
        }

        // POST: Ordereds/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_order,Quantity,Id_flower,Id_bouquets,Unit_priceFlower,Unit_priceBouquet,Flower_name,Bouquet_name")] Ordered ordered)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordered).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_bouquets = new SelectList(db.Bouquets, "Id", "Bouquet_name", ordered.Id_bouquets);
            ViewBag.Id_flower = new SelectList(db.Flowers, "Id", "Flower_name", ordered.Id_flower);
            ViewBag.Id_order = new SelectList(db.Orders, "Id", "Customer_city", ordered.Id_order);
            return View(ordered);
        }

        // GET: Ordereds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordered ordered = db.Ordereds.Find(id);
            if (ordered == null)
            {
                return HttpNotFound();
            }
            return View(ordered);
        }

        // POST: Ordereds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordered ordered = db.Ordereds.Find(id);
            db.Ordereds.Remove(ordered);
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
