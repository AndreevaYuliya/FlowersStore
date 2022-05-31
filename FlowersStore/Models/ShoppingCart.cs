using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowersStore.Models
{
    public class ShoppingCart
    {
        private List<CartItem> items = new List<CartItem>();
        public ShoppingCart()
        {

        }
        public List<CartItem> GetItems()
        {
            return this.items;
        }

        public void AddItem(int id, Flower flower)
        {
            CartItem cartItem;
            for (int i = 0; i < items.Count(); i++)
            {
                cartItem = items[i];
                if (cartItem.GetItemId() == id)
                {
                    cartItem.IncrementItemQuantity();
                    return;
                }
            }
            CartItem newCartItem = new CartItem(flower);
            items.Add(newCartItem);
        }

        public void SetItemQuantity(int id, int quantity, Flower flower)
        {
            CartItem cartItem;
            for (int i = 0; i < items.Count(); i++)
            {
                cartItem = items[i];
                if (cartItem.GetItemId() == id)
                {
                    if (quantity <= 0)
                    {
                        items.Remove(cartItem);
                    }
                    else
                    {
                        cartItem.Quantity = quantity;
                    }
                    return;
                }
            }
            CartItem newCartItem = new CartItem(flower);
            items.Add(newCartItem);
        }

        public double GetTotalValue()
        {
            double sum = 0;
            for (int i = 0; i < items.Count(); i++)
            {
                sum += items[i].GetTotalCost();
            }
            return sum;
        }   
    }
}
