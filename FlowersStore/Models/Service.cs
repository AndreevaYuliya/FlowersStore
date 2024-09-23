namespace FlowersStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            ordered_services = new HashSet<Ordered_services>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string service_name { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        [Column(TypeName = "image")]
        public byte[] picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordered_services> ordered_services { get; set; }
    }
}
