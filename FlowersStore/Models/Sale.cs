namespace FlowersStore.Models
{
    using System;

    public partial class Sale
    {
        public int id { get; set; }

        public int id_employee { get; set; }

        public int? id_flowers { get; set; }

        public int? id_bouquets { get; set; }

        public int id_customer { get; set; }

        public int quantity { get; set; }

        public DateTime date_sale { get; set; }

        public virtual Bouquet bouquet { get; set; }

        public virtual Customer customer { get; set; }

        public virtual Employee employee { get; set; }

        public virtual Flower flower { get; set; }
    }
}
