using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBasico.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VentaId { get; set; }//PK de venta

        [Required]
        public int ClienteId { get; set; }//Datos cliente
        public Cliente cliente { get; set; }

        [Required]
        public string emailComprador { get; set; }//Datos venta
        [Required]
        public string direccionEnvio { get; set; }
        [Required]
        public string medioDePago { get; set; }
        [Required]
        public string nombreTarjeta { get; set; }
        [Required]
        public string numeroTarjeta { get; set; }
        [Required]
        public string fechaVencimientoTarjeta { get; set; }
        [Required]
        public string cvv { get; set; }

        [Required]
        public int ProductoId { get; set; }//Datos producto
        public Producto producto { get; set; }

    }
}
