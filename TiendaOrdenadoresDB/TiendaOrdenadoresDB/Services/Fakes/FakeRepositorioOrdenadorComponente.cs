using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Services
{
	public class FakeRepositorioOrdenadorComponente : IRepositorio<OrdenadorComponente>
    {
        readonly List<OrdenadorComponente> misOrdenadoresComponentes = new();
        public FakeRepositorioOrdenadorComponente()
        {
            misOrdenadoresComponentes.Add(
               new OrdenadorComponente()
                 {
                     Id = 1,
                     OrdenadorId =  1,
                     ComponenteId = 1,
                     Ordenador = new Ordenador()
                     {
                         Id = 1,
                         Descripcion = "patata",
                         NumeroDeSerie = "AAAA1"
                     },
                     Componente = new Componente()
                     {
                         Id = 2,
                         Almacenamiento = 512,
                         Calor = 10,
                         Categoria = 1,
                         Description = "patata2",
                         NumeroDeSerie = "AAAA",
                         Precio = 52,
                         UnidadMedida = "Megas"
                     }
               });
        }

        public void Actualizar(OrdenadorComponente element)
        {
            var ordenadorDeMisOrdenadores = Obtener(element.Id);
            if (ordenadorDeMisOrdenadores != null)
            {
                ordenadorDeMisOrdenadores.ComponenteId = element.ComponenteId;
            }
        }

        public void Añadir(OrdenadorComponente item)
        {
            var ultimoNumero = misOrdenadoresComponentes.Count;
            item.Id = ultimoNumero;
            misOrdenadoresComponentes.Add(item);
        }

        public void Borrar(int id)
        {
            misOrdenadoresComponentes.RemoveAll(x => x.Id == id);
        }

        public OrdenadorComponente? Obtener(int id)
        {
            return misOrdenadoresComponentes.Find(x => x.Id == id);
        }

        public List<OrdenadorComponente> ObtenerTodos()
        {
            return misOrdenadoresComponentes;
        }
    }
}

