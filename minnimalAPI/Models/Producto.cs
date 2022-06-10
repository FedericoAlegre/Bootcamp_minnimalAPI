using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace minnimalAPI.Models
{
    public class Producto
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        
        [StringLength(100)]
        [Required]
        public string ProductName { get; set; }
        [Required]
        [StringLength(100)]
        public string Category { get; set; }
        [Required]
        public DateTime FechaBaja { get; set; }        
    }
}
