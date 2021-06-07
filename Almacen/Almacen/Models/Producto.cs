using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es oblgatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La existencia del producto es oblgatorio")]
        public int Existencia { get; set; }
        [Required(ErrorMessage = "La descripción del producto es oblgatorio")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es oblgatorio")]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Precio { get; set; }
    }
}
