using FlowersStore.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FlowersStore.Controllers
{
    public class FlowersController : Controller
    {
        private FlowersStoreDB db = new FlowersStoreDB();

        public Flower Flower
        {
            get => default;
            set
            {
            }
        }

        // GET: Flowers
        public ActionResult Index()
        {
            var flowers = db.Flowers.Include(f => f.Type);
            return View(flowers.ToList());
        }

        // GET: Flowers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flower = db.Flowers.Find(id);
            if (flower == null)
            {
                return HttpNotFound();
            }
            return View(flower);
        }

        // GET: Flowers/Create
        public ActionResult Create()
        {
            ViewBag.Id_type = new SelectList(db.Types, "id", "type_of_flowers");
            return View();
        }

        // POST: Flowers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_type,Flower_name,Price,Id_supplier,Markup,Account_number,Actual_quantity,Picture,Flower_size")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                db.Flowers.Add(flower);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_type = new SelectList(db.Types, "id", "type_of_flowers", flower.Id_type);
            return View(flower);
        }

        // GET: Flowers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flower = db.Flowers.Find(id);
            if (flower == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_type = new SelectList(db.Types, "id", "type_of_flowers", flower.Id_type);
            return View(flower);
        }

        // POST: Flowers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_type,Flower_name,Price,Id_supplier,Markup,Account_number,Actual_quantity,Picture,Flower_size, PictureType")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_type = new SelectList(db.Types, "id", "type_of_flowers", flower.Id_type);
            return View(flower);
        }

        // GET: Flowers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flower = db.Flowers.Find(id);
            if (flower == null)
            {
                return HttpNotFound();
            }
            return View(flower);
        }

        // POST: Flowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flower flower = db.Flowers.Find(id);
            db.Flowers.Remove(flower);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int flowerId)
        {
            Flower flower = db.Flowers.Where(x => x.Id == flowerId)
                .FirstOrDefault(f => f.Id == flowerId);

            if (flower != null)
            {
                return File(flower.Picture, flower.PictureType);
            }
            else
            {
                return null;
            }
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
