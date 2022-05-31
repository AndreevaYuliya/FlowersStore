using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowersStore.Models
{
    public class CartItem
    {        
        public CartItem()
        {

        }
        public CartItem(Flower item)
        {
            FlowerItem = item;
            Quantity = 1;
        }
        public Flower FlowerItem { get; set; }
        public int Quantity { get; set; }

        public int GetItemId()
        {
            return FlowerItem.Id;
        }

        public string GetItemName()
        {
            return FlowerItem.Flower_name;
        }

        public void IncrementItemQuantity()
        {
            Quantity = Quantity + 1;
        }
     

        public double GetTotalCost()
        {
            return Quantity;
        }
        
    }
}