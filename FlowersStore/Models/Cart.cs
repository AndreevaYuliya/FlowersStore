using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowersStore.Models
{
    public partial class Cart
    {
        [Key]
        public int RecordId { get; set; }

        public string CartId { get; set; }

        public int BouquetId { get; set; }

        public int FlowerId { get; set; }
        public string FlowerName { get; set; }
        public string BouquetName { get; set; }
        public decimal FlowerPrice { get; set; }
        public decimal BouquetPrice { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }
        public virtual Bouquet Bouquet { get; set; }
        public virtual Flower Flower { get; set; }
     






        /*
        private List<Cart> cartCollection = new List<Cart>();

        public void AddItemFlower(Flower flower, int quantity)
        {
            Cart cart = cartCollection
                .Where(f => f.Flower.Id == flower.Id)
                .FirstOrDefault();

            if (cart == null)
            {
                cartCollection.Add(new Cart
                {
                    Flower = flower,
                    Quantity = quantity
                });
            }
            else
            {
                cart.Quantity += quantity;
            }
        }

        public void RemoveLine(Flower flower)
        {
            cartCollection.RemoveAll(l => l.Flower.Id == flower.Id);
        }

        public decimal ComputeTotalValue()
        {
            return cartCollection.Sum(e => e.Flower.Price * e.Quantity);

        }
        public void Clear()
        {
            cartCollection.Clear();
        }

        public IEnumerable<Cart> Carts
        {
            get { return cartCollection; }
        }
        */
    }

    public class CartLine
    {
        private List<Cart> cartCollection = new List<Cart>();
        public IEnumerable<Cart> Carts { get { return cartCollection; } }

        public void AddItemFlower(
            Flower flower, 
            string flowerName,
            decimal price,
            int quantity)
        {
            Cart cart = cartCollection
                .Where(f => f.Flower.Id == flower.Id)
                .FirstOrDefault();

            if (cart == null)
            {
                cartCollection.Add(new Cart
                {
                    Flower = flower,
                    FlowerName = flowerName,
                    FlowerPrice = price,
                    Quantity = quantity
                });
            }
            else
            {
                cart.Quantity += quantity;
            }
        }

        public void RemoveLine(Flower flower)
        {
            cartCollection.RemoveAll(l => l.Flower.Id == flower.Id);
        }

        public decimal ComputeTotalValue()
        {
            return cartCollection.Sum(e => e.Flower.Price * e.Quantity);

        }
        public void Clear()
        {
            cartCollection.Clear();
        }
       
    }
}
