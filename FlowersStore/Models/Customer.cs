namespace FlowersStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            orders = new HashSet<Order>();
            sales = new HashSet<Sale>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string surname { get; set; }

        [Required]
        [StringLength(255)]
        public string customer_name { get; set; }

        [StringLength(255)]
        public string last_name { get; set; }

        [StringLength(255)]
        public string phone_number { get; set; }

        [Required]
        [StringLength(255)]
        public string eMail { get; set; }

        public int? customer_discount { get; set; }

        [Required]
        public virtual Payment_method payment_method { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> sales { get; set; }
    }
}
