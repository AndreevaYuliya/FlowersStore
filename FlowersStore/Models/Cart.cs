using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowersStore.Models
{
    public partial class Cart
    {
        [Key]
        public int RecordId { get; set; }

        public int CartId { get; set; }

        public int BouquetId { get; set; }

        public int FlowerId { get; set; }
        public string FlowerName { get; set; }
        public string BouquetName { get; set; }
        public decimal FlowerPrice { get; set; }
        public decimal BouquetPrice { get; set; }
        public float Bill { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }
        public string Picture { get; set; }
        public virtual Bouquet Bouquet { get; set; }
        public virtual Flower Flower { get; set; } 
    }
}
