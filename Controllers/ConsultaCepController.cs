using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConsultaCEPAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsultaCEPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaCepController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ConsultaCepController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("search/local/{ceps?}")]
        public async Task<IActionResult> Get(string ceps = "")
        {
            if (string.IsNullOrEmpty(ceps))
            {
                return BadRequest(new { message = "Não identificado CEP. Por favor, forneça um número de CEP válido." });
            }

            var cepArray = ceps.Split(',');
            var validCepList = new List<string>();
            var invalidCepList = new List<string>();

            foreach (var cep in cepArray)
            {
                var cleanedCep = cep.Replace("-", "").Trim();
                if (cleanedCep.Length == 8 && long.TryParse(cleanedCep, out _))
                {
                    validCepList.Add(cleanedCep);
                }
                else
                {
                    invalidCepList.Add(cep);
                }
            }

            if (invalidCepList.Count > 0 && validCepList.Count == 0)
            {
                return BadRequest(new { message = $"CEPs inválidos: {string.Join(", ", invalidCepList)}" });
            }

            var tasks = new List<Task<ViaCepResponse>>();
            foreach (var validCep in validCepList)
            {
                tasks.Add(GetCepDataAsync(validCep));
            }

            var results = await Task.WhenAll(tasks);

            return Ok(new { validResults = results, invalidCeps = invalidCepList });
        }

        private async Task<ViaCepResponse> GetCepDataAsync(string cep)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
            return JsonConvert.DeserializeObject<ViaCepResponse>(response)!;
        }
    }
}
