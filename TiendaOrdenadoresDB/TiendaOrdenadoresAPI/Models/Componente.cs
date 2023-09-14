using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaOrdenadoresAPI.Models
{
	public class Componente
    {
        public int Id { get; set; }

        [MinLength(1, ErrorMessage = "La descripcion no puede estar vacia")]
        [Required]
        public string Description { get; set; } = null!;

        [MinLength(1, ErrorMessage = "El numero de serie tiene que tener por lo menos un caracter")]
        [Required]
        [Column(Order = 2)]
        public string NumeroDeSerie { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "La categoria no puede ser negativo")]
        [Required]
        public int Categoria { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El precio no puede ser negativo")]
        [Required]
        public int Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El calor no puede ser negativo")]
        [Required]
        public int Calor { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El almacenamiento no puede ser negativo")]
        [Required]
        public long Almacenamiento { get; set; }

        [MinLength(1, ErrorMessage = "La unidad de medida tiene que tener por lo menos un caracter")]
        [Required]
        public string UnidadMedida { get; set; } = null!;
 

    }
}
