using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaOrdenadoresAPI.Models
{
	public class Ordenador
    {
        public int Id { get; set; }

        [MinLength(1, ErrorMessage = "La descripcion no puede estar vacia")]
        [Required]
        public string Descripcion { get; set; } = null!;

        [MinLength(1, ErrorMessage = "El numero de serie tiene que tener por lo menos un caracter")]
        [Required]
        public string NumeroDeSerie { get; set; } = null!;

        public List<OrdenadorComponente> OrdenadorComponentes { get; set; } = new();


        [NotMapped]
        public double Precio
        {
            get => OrdenadorComponentes.Sum(x => x.Componente.Precio);
        }

        [NotMapped]
        public double Calor
        {
            get => OrdenadorComponentes.Sum(x => x.Componente.Calor);
        }
    }

}

