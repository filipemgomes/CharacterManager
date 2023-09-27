using CharacterManager.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CharacterManager.Api.RequestApi
{
    public class CadastrarPersonagemRequest
    {
        public string Nome { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TipoProfissao Profissao { get; set; }
    }
}
