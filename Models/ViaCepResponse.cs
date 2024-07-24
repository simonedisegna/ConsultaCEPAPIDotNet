using Newtonsoft.Json;

namespace ConsultaCEPAPI.Models
{
    public class ViaCepResponse
    {
        [JsonProperty("cep")]
        public string Cep { get; set; } = string.Empty;

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; } = string.Empty;

        [JsonProperty("complemento")]
        public string Complemento { get; set; } = string.Empty;

        [JsonProperty("bairro")]
        public string Bairro { get; set; } = string.Empty;

        [JsonProperty("localidade")]
        public string Localidade { get; set; } = string.Empty;

        [JsonProperty("uf")]
        public string Uf { get; set; } = string.Empty;

        [JsonProperty("ibge")]
        public string Ibge { get; set; } = string.Empty;

        [JsonProperty("gia")]
        public string Gia { get; set; } = string.Empty;

        [JsonProperty("ddd")]
        public string Ddd { get; set; } = string.Empty;

        [JsonProperty("siafi")]
        public string Siafi { get; set; } = string.Empty;

        public string Label => $"{Logradouro}, {Localidade}";
    }
}
