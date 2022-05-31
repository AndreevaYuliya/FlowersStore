namespace FlowersStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment_method
    {
        [Key]
        public int id_customer { get; set; }

        [Column("payment_method")]
        [Required]
        [StringLength(255)]
        public string payment_method1 { get; set; }

        public virtual Customer customer { get; set; }
    }
}
