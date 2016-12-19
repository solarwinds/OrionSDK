using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSRestClient
{
    public interface ISwisClient
    {
        Task<JToken> QueryAsync(string query, object parameters = null);
        Task<JToken> InvokeAsync(string entity, string verb, params object[] args);
        Task<string> CreateAsync(string entity, object properties);
        Task<JObject> ReadAsync(string uri);
        Task UpdateAsync(string uri, object properties);
        Task UpdateAsync(IEnumerable<string> uris, object properties);
        Task DeleteAsync(string uri);
        Task DeleteAsync(IEnumerable<string> uris);
    }
}