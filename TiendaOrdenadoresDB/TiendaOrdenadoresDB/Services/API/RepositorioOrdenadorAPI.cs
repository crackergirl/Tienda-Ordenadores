using Newtonsoft.Json;
using System.Text;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Services.API
{
	public class RepositorioOrdenadorAPI : IRepositorio<Ordenador>
    {
        private readonly HttpClient _httpClient;

        public RepositorioOrdenadorAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyHttpClient");
        }

        public void Actualizar(Ordenador element)
        {
            var url = "http://localhost:5178/api/Ordenadores";
            var json = JsonConvert.SerializeObject(element);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine(content);
            _httpClient.PutAsync(url, content);
        }

        public void Añadir(Ordenador item)
        {
            var url = "http://localhost:5178/api/Ordenadores";
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(url, content).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var urlUltimoId = "http://localhost:5178/api/Ordenadores/UltimoId";
                var callResponse = _httpClient.GetAsync(urlUltimoId).Result;
                var responseUltimoId = callResponse.Content.ReadAsStringAsync().Result;
                int Id = JsonConvert.DeserializeObject<int>(responseUltimoId);
                item.Id = Id;
            }

        }

        public void Borrar(int id)
        {
            var url = $"http://localhost:5178/api/Ordenadores/{id}";
            _httpClient.DeleteAsync(url);
        }

        public Ordenador? Obtener(int id)
        {
            var url = $"http://localhost:5178/api/Ordenadores/{id}";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Ordenador>(response);
        }

        public List<Ordenador> ObtenerTodos()
        {
            var url = "http://localhost:5178/api/Ordenadores";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<Ordenador>>(response);
            if (lista == null) return new();

            return lista;
        }
    }
}

