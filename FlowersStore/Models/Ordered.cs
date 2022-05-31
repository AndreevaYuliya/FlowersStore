using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowersStore.Models
{
    [Table("ordered")]
    public partial class Ordered
    {
        [Key]
        [Column(Order = 0)]
        public int Id_order { get; set; }

        public int? Id_flower { get; set; }

        public int? Id_bouquets { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }
        public decimal Unit_priceFlower { get; set; }
        public decimal Unit_priceBouquet { get; set; }
        public string Flower_name { get; set; }
        public string Bouquet_name { get; set; }

        public virtual Bouquet Bouquet { get; set; }

        public virtual Flower Flower { get; set; }

        public virtual Order Order { get; set; }
    }
}
