using System.Collections.Generic;

namespace TiendaOrdenadoresDB.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public double Precio { get; set; }
        public double Calor { get; set; }
        public List<OrdenadorPedido> OrdenadorPedido { get; set; } = new();
    }
}

