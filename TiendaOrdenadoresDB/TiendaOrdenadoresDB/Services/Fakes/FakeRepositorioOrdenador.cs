using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Services
{
	public class FakeRepositorioOrdenador : IRepositorio<Ordenador>
    {
        readonly List<Ordenador> misOrdenadores = new();
        public FakeRepositorioOrdenador()
		{
            misOrdenadores.Add(new Ordenador()
            {
                Id = 1,
                Descripcion = "patata",
                NumeroDeSerie = "AAAA1"
            });
            misOrdenadores.Add(new Ordenador()
            {
                Id = 2,
                Descripcion = "patata2",
                NumeroDeSerie = "AAAA2"
            });
            misOrdenadores.Add(new Ordenador()
            {
                Id = 3,
                Descripcion = "patata3",
                NumeroDeSerie = "AAAA3"
            });

        }

        public void Actualizar(Ordenador ordenador)
        {
            var ordenadorDeMisOrdenadores = Obtener(ordenador.Id);
            if (ordenadorDeMisOrdenadores != null)
            {
                ordenadorDeMisOrdenadores.Descripcion = ordenador.Descripcion;
                ordenadorDeMisOrdenadores.NumeroDeSerie = ordenador.NumeroDeSerie;
            }
        }

        public void Añadir(Ordenador ordenador)
        {
            var ultimoNumero = misOrdenadores.Count;
            ordenador.Id = ultimoNumero;
            misOrdenadores.Add(ordenador);
        }

        public void Borrar(int id)
        {
            misOrdenadores.RemoveAll(x => x.Id == id);
        }

        public Ordenador? Obtener(int id)
        {
            return misOrdenadores.Find(x => x.Id == id);
        }

        public List<Ordenador> ObtenerTodos()
        {
            return misOrdenadores;
        }
    }
}

