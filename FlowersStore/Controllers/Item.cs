using FlowersStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowersStore.Controllers
{
    public class Item : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        private Flower flower = new Flower();

        public Flower Flower
        {
            get { return flower; }
            set { flower = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Item(Flower flower)
        {
            this.flower = flower;
        }

    }
}