using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApiClientRest.Service
{
    
    public class Repo 
    {
        private  readonly HttpClient client = new HttpClient();


        public async Task<Endereco> ProcessRepositories(string cep)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                var streamTask = client.GetStreamAsync($"https://viacep.com.br/ws/{cep}/json");
                var repositories = await JsonSerializer.DeserializeAsync<Endereco>(await streamTask);
                
                return new Endereco
                {
                    Cep = repositories.Cep,
                    Logradouro = repositories.Logradouro,
                    Complemento = repositories.Complemento,
                    Bairro = repositories.Bairro,
                    Localidade = repositories.Localidade,
                    Uf = repositories.Uf,
                    Ibge = repositories.Ibge,
                    Gia = repositories.Gia,
                    DDD = repositories.DDD,
                    Siafi = repositories.Siafi
                };
        }
    }
}