namespace TiendaOrdenadoresAPI.Models
{
    public class OrdenadorComponente
    {
        public int Id { get; set; }
        public int ComponenteId { get; set; }
        public int OrdenadorId { get; set; }
        public Componente Componente { get; set; } = null!;
        public Ordenador Ordenador { get; set; } = null!;
    }
}
