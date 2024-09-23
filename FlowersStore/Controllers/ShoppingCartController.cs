using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using FlowersStore.Models;

namespace FlowersStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        FlowersStoreDB db = new FlowersStoreDB();

        List<Cart> li = new List<Cart>();
    
        public ActionResult IndexFlower()
        {
            if (TempData["cart"] != null)
            {
                float x = 0;
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                foreach (var item in li2)
                {
                    x += item.Bill;
                }

                TempData["total"] = x;
            }
            TempData.Keep();

            return View(db.Flowers.OrderByDescending(x => x.Id).ToList());
        }

        public ActionResult AddFlower(int? id)
        {
            Flower flower = db.Flowers.Where(x => x.Id == id).SingleOrDefault();
            return View(flower);
        }


        [HttpPost]
        public ActionResult AddFlower(int quantity, int id)
        {
            Flower flower = db.Flowers.Where(x => x.Id == id).SingleOrDefault();

            Cart cart = new Cart();
            cart.FlowerName = flower.Flower_name;
            cart.FlowerPrice = flower.Price;
            cart.Quantity = quantity;
            cart.Bill = (float)(cart.FlowerPrice * cart.Quantity);

            if (TempData["cart"] == null)
            {
                li.Add(cart);
                TempData["cart"] = li;
                Session["count"] = 1;
            }
            else
            {
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                li2.Add(cart);
                TempData["cart"] = li2;
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }

            TempData.Keep();

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            if (TempData["cart"] != null)
            {
                float x = 0;
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                foreach (var item in li2)
                {
                    x += item.Bill;
                }

                TempData["total"] = x;
            }
            TempData.Keep();

            List<Flower> flowers = db.Flowers.OrderByDescending(c => c.Id).ToList();
            List<Bouquet> bouquets = db.Bouquets.OrderByDescending(c => c.Id).ToList();

           
              return View(Tuple.Create(flowers, bouquets));
        }

        public ActionResult AddBouquet(int? id)
        {
            Bouquet bouquet = db.Bouquets.Where(x => x.Id == id).SingleOrDefault();
            return View(bouquet);
        }

        [HttpPost]
        public ActionResult AddBouquet(int quantity, int id)
        {
            Bouquet bouquet = db.Bouquets.Where(x => x.Id == id).SingleOrDefault();

            Cart cart = new Cart();

            cart.BouquetName = bouquet.Bouquet_name;
            cart.BouquetPrice = bouquet.Price;
            cart.Quantity = quantity;
            cart.Bill = (float)(cart.BouquetPrice * cart.Quantity);

            if (TempData["cart"] == null)
            {
                li.Add(cart);
                TempData["cart"] = li;
                Session["count"] = 1;
            }
            else
            {
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                li2.Add(cart);
                TempData["cart"] = li2;
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            TempData.Keep();

            return RedirectToAction("Index");
        }
    }
}
