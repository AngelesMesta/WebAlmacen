using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Almacen.Models
{
    public class ES
    {
        [Key]
        public int IDMovimiento { get; set; }

        [Required]
        public int Tipo { get; set; }
        [Required(ErrorMessage = "Es necesario registrar el Id del producto")]
        public int IdPro { get; set; }
        [Required(ErrorMessage = "Es necesario registrar la cantidad")]
        public int cantidad { get; set; }
        [Required(ErrorMessage = "El nombre del usuario es oblgatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "El campo fecha es oblgatorio")]
        public DateTime FechaMov { get; set; }
        [Required(ErrorMessage = "El número de la bodega de salida es oblgatorio")]
        public string BodegaSalida { get; set; }
        [Required(ErrorMessage = "El número de la bodega de entrada es oblgatorio")]
        public string BodegaEntrada { get; set; }

    }
}
