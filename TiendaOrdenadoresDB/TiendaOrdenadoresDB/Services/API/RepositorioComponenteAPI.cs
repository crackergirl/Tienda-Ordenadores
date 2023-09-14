using System.Text;
using Newtonsoft.Json;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Services.API
{
	public class RepositorioComponenteAPI : IRepositorio<Componente>
	{
        private readonly HttpClient _httpClient;

        public RepositorioComponenteAPI(IHttpClientFactory httpClientFactory)
		{
            _httpClient = httpClientFactory.CreateClient("MyHttpClient");
        }

        public void Actualizar(Componente element)
        {
            var url = "http://localhost:5178/api/Componentes";
            var json = JsonConvert.SerializeObject(element);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PutAsync(url, content);
        }

        public void Añadir(Componente item)
        {
            var url = "http://localhost:5178/api/Componentes";
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PostAsync(url, content);
        }

        public void Borrar(int id)
        {
            var url = $"http://localhost:5178/api/Componentes/{id}";
            _httpClient.DeleteAsync(url);
        }

        public Componente? Obtener(int id)
        {
            var url = $"http://localhost:5178/api/Componentes/{id}";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Componente>(response);
        }

        public List<Componente> ObtenerTodos()
        {
            var url = "http://localhost:5178/api/Componentes";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Componente>>(response);
            if (lista == null) return new();

            return lista;
        }
    }
}

