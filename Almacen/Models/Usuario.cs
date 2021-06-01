using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre del usuario es oblgatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La contraseña del usuario es oblgatorio")]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "El puesto del usuario es oblgatorio")]
        public string puesto { get; set; }
    }
}
