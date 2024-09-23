namespace FlowersStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            supplies = new HashSet<Supply>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string supplier_name { get; set; }

        [Required]
        [StringLength(255)]
        public string country { get; set; }

        [Required]
        [StringLength(255)]
        public string city { get; set; }

        [Required]
        [StringLength(255)]
        public string address { get; set; }

        [Required]
        [StringLength(255)]
        public string phone_number { get; set; }

        [Required]
        [StringLength(255)]
        public string eMail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply> supplies { get; set; }
    }
}
