using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.Fakes
{
	public class FakeRepositorioComponente : IRepositorio<Componente>
	{
        readonly List<Componente> misComponentes = new();
        public FakeRepositorioComponente()
		{
            misComponentes.Add(new Componente()
            {
                Id = 1,
                Almacenamiento = 6,
                Calor = 10,
                Categoria = 0,
                Description = "patata",
                NumeroDeSerie = "AAAA",
                Precio = 50,
                UnidadMedida = "Cores"
            });

            misComponentes.Add(new Componente()
            {
                Id = 2,
                Almacenamiento = 512,
                Calor = 10,
                Categoria = 1,
                Description = "patata2",
                NumeroDeSerie = "AAAA",
                Precio = 52,
                UnidadMedida = "Megas"
            });

            misComponentes.Add(new Componente()
            {
                Id = 3,
                Almacenamiento = 1024,
                Calor = 10,
                Categoria = 2,
                Description = "patata3",
                NumeroDeSerie = "AAAA",
                Precio = 53,
                UnidadMedida = "Megas"
            });
        }

        public void Actualizar(Componente componente)
        {
            var componenteDeMisComponentes = Obtener(componente.Id);
            if (componenteDeMisComponentes != null) {

                componenteDeMisComponentes.Almacenamiento = componente.Almacenamiento;
                componenteDeMisComponentes.Calor = componente.Calor;
                componenteDeMisComponentes.Categoria = componente.Categoria;
                componenteDeMisComponentes.Description = componente.Description;
                componenteDeMisComponentes.NumeroDeSerie = componente.NumeroDeSerie;
                componenteDeMisComponentes.Precio = componente.Precio;
                componenteDeMisComponentes.UnidadMedida = componente.UnidadMedida;
            }
        }


        public void Añadir(Componente componente)
        {
            var ultimoNumero = misComponentes.Count;
            componente.Id = ultimoNumero;
            misComponentes.Add(componente);
        }

        public List<Componente> ObtenerTodos()
        {
            return misComponentes;
        }


        public void Borrar(int id)
        {
            misComponentes.RemoveAll(x => x.Id == id);
        }


        public Componente? Obtener(int id)
        {
            return misComponentes.Find(x => x.Id == id);
        }

        public int ObtenerUltimoId()
        {
            return misComponentes.Count;
        }
    }
}

