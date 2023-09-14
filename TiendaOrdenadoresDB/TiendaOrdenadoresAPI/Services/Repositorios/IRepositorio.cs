namespace TiendaOrdenadoresAPI.Services
{
    public interface IRepositorio<T>
    {
        List<T> ObtenerTodos();
        T? Obtener(int id);
        void Añadir(T item);
        void Borrar(int id);
        void Actualizar(T element);
        int ObtenerUltimoId();
    }
}
