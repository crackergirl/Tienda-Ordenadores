namespace TiendaOrdenadores.AlmacenComponentes
{
	public class Almacen : IAlmacen, ICloneable
	{
        Dictionary<string, int> stockComponentes; 
        public Almacen()
		{

            stockComponentes = new Dictionary<string, int>()
            {
                { "789-XCS", 1 },
                { "789-XCD", 1 },
                { "789-XCT", 2 },
                { "797-X", 1 },
                { "797-X2", 2 },
                { "797-X3", 1 },
                { "879-FH", 2 },
                { "879-FH-L", 1 },
                { "879-FH-T", 1 },
                { "789-XX", 1 },
                { "789-XX-2", 2 },
                { "789-XX-3", 1 },
                { "788-FG", 1 },
                { "788-FG-2", 1 },
                { "788-FG-3", 1 },
                { "1789-XCS", 1 },
                { "1789-XCD", 1 },
                { "1789-XCT", 0 }
            };
        }

        public void aumentarCantidadComponente(string numeroDeSerie, int cantidad)
        {
            if (stockComponentes.ContainsKey(numeroDeSerie))
            {
                stockComponentes[numeroDeSerie] += cantidad;

            }
            else
            {
                Console.WriteLine("No existe esta componente");
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int dameCantidadComponente(String numeroDeSerie)
        {
            if (stockComponentes.ContainsKey(numeroDeSerie))
            {
                return stockComponentes[numeroDeSerie];
                
            }
            else
            {
                Console.WriteLine("No existe esta componente");
                return 0;
            }
        
        }

        public bool utilizarComponente(string numeroDeSerie, int cantidad)
        {
            if (dameCantidadComponente(numeroDeSerie) < cantidad)
                return false;
            else
            {
                stockComponentes[numeroDeSerie] -= cantidad;
                return true;
            }
               
        }
    }
}

