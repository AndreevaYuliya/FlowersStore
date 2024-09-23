using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowersStore.Models
{
    [Table("order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<Ordered>();
            ordered_services = new HashSet<Ordered_services>();
        }

        public int Id { get; set; }

        public int Id_customer { get; set; }

        [Required]
        [StringLength(255)]
        public string Customer_city { get; set; }

        [Required]
        [StringLength(255)]
        public string Customer_address { get; set; }

        public DateTime Registration_date { get; set; }

        public DateTime Delivery_date { get; set; }

        public int Id_delivery { get; set; }

        [Column(TypeName = "money")]
        public decimal Delivery_cost { get; set; }
        public decimal Total { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual Delivery Delivery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordered> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordered_services> ordered_services { get; set; }
        public List<Order> Items;
    }
}
