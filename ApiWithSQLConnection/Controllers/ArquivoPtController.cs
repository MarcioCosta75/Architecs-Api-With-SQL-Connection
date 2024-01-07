using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ArchitecsApiWithSQLConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoPtController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _textSearchBaseUrl = "https://arquivo.pt/textsearch";
        private readonly string _imageSearchBaseUrl = "https://arquivo.pt/imagesearch";

        public ArquivoPtController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("TextSearch")]
        public async Task<IActionResult> TextSearch(string q, string from = null, string to = null, string type = null, int offset = 0, string siteSearch = null, string collection = null, int maxItems = 50, string fields = null, bool prettyPrint = true)
        {
            var queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams["q"] = q;
            if (!string.IsNullOrEmpty(from)) queryParams["from"] = from;
            if (!string.IsNullOrEmpty(to)) queryParams["to"] = to;
            if (!string.IsNullOrEmpty(type)) queryParams["type"] = type;
            queryParams["offset"] = offset.ToString();
            if (!string.IsNullOrEmpty(siteSearch)) queryParams["siteSearch"] = siteSearch;
            if (!string.IsNullOrEmpty(collection)) queryParams["collection"] = collection;
            queryParams["maxItems"] = maxItems.ToString();
            if (!string.IsNullOrEmpty(fields)) queryParams["fields"] = fields;
            queryParams["prettyPrint"] = prettyPrint.ToString();

            var url = $"{_textSearchBaseUrl}?{queryParams}";
            return await MakeRequest(url);
        }

        [HttpGet("ImageSearch")]
        public async Task<IActionResult> ImageSearch(string q, int maxItems = 50)
        {
            var queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams["q"] = q;
            queryParams["maxItems"] = maxItems.ToString();

            var url = $"{_imageSearchBaseUrl}?{queryParams}";
            return await MakeRequest(url);
        }

        private async Task<IActionResult> MakeRequest(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return Ok(result);
            }
            catch (HttpRequestException e)
            {
                return BadRequest($"Erro ao fazer a requisição: {e.Message}");
            }
        }
    }
}
