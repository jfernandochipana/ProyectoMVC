using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBasico.Models
{
    public class Auricular : Producto
    {
        public int potenciaWatts    { get; set; }

    }
}
