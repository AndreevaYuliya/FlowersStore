using FlowersStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FlowersStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        FlowersStoreDB db = new FlowersStoreDB();
        private List<Cart> carts;

        public ActionResult Index()
        {
            List<Cart> carts = (from cart in db.Carts
                                       join
                                       flowers in db.Flowers
                                       on cart.FlowerId equals flowers.Id
                                       select new
                                       {
                                           FlowerName = flowers.Flower_name,
                                           FlowerPrice = flowers.Price,
                                           Quantity = cart.Quantity
                                       }
                                       ).AsEnumerable().Select(fl => new Cart
                                       {
                                           FlowerName = fl.FlowerName,
                                           FlowerPrice = fl.FlowerPrice,
                                           Quantity = fl.Quantity
                                       }).ToList();
            return View(carts);



           // return View(db.Carts.ToList());
        }

        public ActionResult Add()
        {
            Cart carts = new Cart();

            var item = (from cart in db.Carts
                                       join
                                       flowers in db.Flowers
                                       on cart.FlowerId equals flowers.Id
                                       select new
                                       {
                                           FlowerName = flowers.Flower_name,
                                           FlowerPrice = flowers.Price,
                                           Quantity = cart.Quantity
                                       }
                                       ).AsEnumerable().Select(fl => new Cart
                                       {
                                           FlowerName = fl.FlowerName,
                                           FlowerPrice = fl.FlowerPrice,
                                           Quantity = fl.Quantity
                                       });
            carts = (Cart)item;
            db.Carts.Add(carts);

            return View(carts);
      
        }
        
     
        





        // GET: ShoppingCart

        /*
        public ActionResult Index()
        {
            ShoppingCart cart = (ShoppingCart)Session["ShoppingCart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session["ShoppingCart"] = cart;
            }
            return View(cart);
        }
      
        public ActionResult CreateOrUpdate(CartViewModel value)
        {
            ShoppingCart cart = (ShoppingCart)Session["ShoppingCart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session["ShoppingCart"] = cart;
            }   
            
            {
                Flower flower = db.Flowers.Find(value.Id);
                if (flower != null)
                {
                    if (value.Quantity == 0)
                    {
                        cart.AddItem(value.Id, flower);
                    }
                    else
                    {
                        cart.SetItemQuantity(value.Id, value.Quantity, flower);
                    }
                }
            }

            Session["CartCount"] = cart.GetItems().Count();
            return View("Index", cart);
        }
        

        */





        /*

        // GET: Shop
        public async Task<ActionResult> Index()
        {
            return View(await db.Flowers.ToListAsync());
        }

        public ActionResult Cart()
        {
            return View();
        }

        public async Task<ActionResult> AddInCart(Cart id)
        {
           // var cart = ShoppingCart.GetCart(this.HttpContext);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flower = await db.Flowers.FindAsync(id);
            if (flower == null)
            {
                return HttpNotFound();
            }
            db.Carts.Add(id);   
            db.SaveChanges();
            return RedirectToAction("Index", "Flowers", flower);
        }

*/





        /*
        FlowersStoreDB storeDB = new FlowersStoreDB();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCartFlower(int? flowerId)
        { 
            
            // Retrieve the album from the database     
            var addedFlower = storeDB.Flowers
                .FirstOrDefault(flower => flower.Id == flowerId);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCartFlower(addedFlower);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
            
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int flowerId)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string flowerName = storeDB.Carts
                .Single(item => item.RecordId == flowerId).Flower.Flower_name;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(flowerId);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(flowerName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = flowerId
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
          */
    }
}