using System;
namespace TiendaOrdenadores.Componentes.Procesadores
{
	public class Procesador : IProcesable
	{
        private int calor;
        private int cores;
        private String descripcion = "";
        private String numeroDeSerie = "";
        private int precio;

        public Procesador(int calor, int cores, string descripcion, string numeroDeSerie, int precio)
        {
            Calor = calor;
            Cores = cores;
            Descripcion = descripcion;
            NumeroDeSerie = numeroDeSerie;
            Precio = precio;
        }

        public string Descripcion
        {
            get => descripcion;
            set
            {
                if (value.Length > 0)
                {
                    descripcion = value;
                }
                else
                {
                    descripcion = "desconocido";
                }
            }
        }
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

        public int Cores
        {
            get => cores;
            set
            {
                if (value > 0)
                {
                    cores = value;
                }
                else
                {
                    cores = 0;
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

        public int getCalor()
        {
            return Calor;
        }

        public int getCores()
        {
            return Cores;
        }

        public string getDescripcion()
        {
            return Descripcion;
        }

        public string getNumeroDeSerie()
        {
            return NumeroDeSerie;
        }

        public int getPrecio()
        {
            return Precio;
        }
    }
}

