namespace TiendaOrdenadoresDB.Models
{
    public class OrdenadorPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int OrdenadorId { get; set; }
        public Pedido Pedido { get; set; } = null!;
        public Ordenador Ordenador { get; set; } = null!;
    }
}

