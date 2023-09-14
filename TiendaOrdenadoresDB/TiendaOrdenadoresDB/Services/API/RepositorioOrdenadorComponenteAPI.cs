using System;
using Newtonsoft.Json;
using System.Text;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Services.API
{
	public class RepositorioOrdenadorComponenteAPI : IRepositorio<OrdenadorComponente>
	{
        private readonly HttpClient _httpClient;

        public RepositorioOrdenadorComponenteAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyHttpClient");
        }

        public void Actualizar(OrdenadorComponente element)
        {
            var url = "http://localhost:5178/api/OrdenadoresComponentes";
            var json = JsonConvert.SerializeObject(element);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine(content);
            _httpClient.PutAsync(url, content);
        }

        public void Añadir(OrdenadorComponente item)
        {
            var url = "http://localhost:5178/api/OrdenadoresComponentes";
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync(url, content);
        }

        public void Borrar(int id)
        {
            var url = $"http://localhost:5178/api/OrdenadoresComponentes/{id}";
            _httpClient.DeleteAsync(url);
        }

        public OrdenadorComponente? Obtener(int id)
        {
            var url = $"http://localhost:5178/api/OrdenadoresComponentes/{id}";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<OrdenadorComponente>(response);
        }

        public List<OrdenadorComponente> ObtenerTodos()
        {
            var url = "http://localhost:5178/api/OrdenadoresComponentes";
            var callResponse = _httpClient.GetAsync(url).Result;
            var response = callResponse.Content.ReadAsStringAsync().Result;
            var lista = JsonConvert.DeserializeObject<List<OrdenadorComponente>>(response);
            if (lista == null) return new();

            return lista;
        }
    }
}

