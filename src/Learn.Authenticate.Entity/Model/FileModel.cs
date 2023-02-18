using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Model
{
    public class FileModel
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }
        [JsonPropertyName("IdName")]
        public string Name { get; set; }
        [JsonPropertyName("Type")]
        public string Type { get; set; }
        [JsonPropertyName("Url")]
        public string Url { get; set; }
    }
}
