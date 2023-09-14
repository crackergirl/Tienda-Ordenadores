namespace TiendaOrdenadoresDB.ViewModels
{
    public class OrdenadorComponenteViewModel
    {
        public string NumeroDeSerie { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int ProcesadorId { get; set; }
        public int MemoriaRamId { get; set; }
        public int DiscoDuroId { get; set; }
    }
}
