namespace FlowersStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            sales = new HashSet<Sale>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string surname { get; set; }

        [Required]
        [StringLength(255)]
        public string name_employee { get; set; }

        [Required]
        [StringLength(255)]
        public string last_name { get; set; }

        [Required]
        [StringLength(255)]
        public string adress { get; set; }

        public int phone_number { get; set; }

        [Required]
        [StringLength(255)]
        public string eMail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> sales { get; set; }
    }
}
