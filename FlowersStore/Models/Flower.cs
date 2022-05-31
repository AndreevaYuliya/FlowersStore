using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowersStore.Models
{
    public partial class Flower
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flower()
        {
            Ordereds = new HashSet<Ordered>();
            Sales = new HashSet<Sale>();
            Supplies = new HashSet<Supply>();
        }

        public int Id { get; set; }

        public short Id_type { get; set; }

        [Required]
        [StringLength(50)]
        public string Flower_name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int Id_supplier { get; set; }

        public int Markup { get; set; }

        public int Account_number { get; set; }

        public int Actual_quantity { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public int Flower_size { get; set; }

        public virtual Type Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordered> Ordereds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
