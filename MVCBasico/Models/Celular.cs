using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBasico.Models
{
    public class Celular : Producto
    {
        public string procesador { get; set; }
        public int memoriaRam {  get; set; }
    }
}
