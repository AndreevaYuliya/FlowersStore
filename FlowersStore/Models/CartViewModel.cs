using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowersStore.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        /*
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
        */
    }
}