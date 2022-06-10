using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace minnimalAPI.Models
{
    public class Caracteristicas
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaracteristicaID { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ancho { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Largo { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Peso { get; set; }
        [Required]
        [ForeignKey("Producto")]
        public int ProductID { get; set; }
    }
}
