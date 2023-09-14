using System;
namespace TiendaOrdenadores.Componentes.Almacenadores.Memorizadores
{
	public class Memorizador : IMemorizable
	{
        private int calor;
        private int almacenamiento;
        private String descripcion = "";
        private String numeroDeSerie = "";
        private int precio;

        public Memorizador(int calor, int almacenamiento, string descripcion, string numeroDeSerie, int precio)
        {
            Calor = calor;
            Almacenamiento = almacenamiento;
            Descripcion = descripcion;
            NumeroDeSerie = numeroDeSerie;
            Precio = precio;
        }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string NumeroDeSerie
        {
            get => numeroDeSerie;
            set
            {
                if (value.Length > 0)
                {
                    numeroDeSerie = value;
                }
                else
                {
                    numeroDeSerie = "desconocido";
                }
            }
        }

        public int Calor
        {
            get => calor;
            set
            {
                if (value > 0)
                {
                    calor = value;
                }
                else
                {
                    calor = 0;
                }
            }
        }

        public int Almacenamiento
        {
            get => almacenamiento;
            set
            {
                if (value > 0)
                {
                    almacenamiento = value;
                }
                else
                {
                    almacenamiento = 0;
                }
            }
        }

        public int Precio
        {
            get => precio;
            set
            {
                if (value > 0)
                {
                    precio = value;
                }
                else
                {
                    precio = 0;
                }
            }
        }

        public int getAlmacenamiento()
        {
            return Almacenamiento;
        }

        public string getDescripcion()
        {
            return Descripcion;
        }

        public string getNumeroDeSerie()
        {
            return NumeroDeSerie;
        }

        public int getCalor()
        {
            return Calor;
        }

        public int getPrecio()
        {
            return Precio;
        }
    }
}

