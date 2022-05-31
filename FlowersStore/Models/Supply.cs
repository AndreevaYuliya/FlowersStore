namespace FlowersStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("supply")]
    public partial class Supply
    {
        public int id { get; set; }

        public int id_supplier { get; set; }

        public int? id_flowers { get; set; }

        public int? id_bouquets { get; set; }

        public int quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public DateTime date_supply { get; set; }

        public virtual Bouquet bouquet { get; set; }

        public virtual Flower flower { get; set; }

        public virtual Supplier supplier { get; set; }
    }
}
