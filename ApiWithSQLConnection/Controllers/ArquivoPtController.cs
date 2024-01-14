using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using ApiWithSQLConnection.Models;
using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ArchitecsApiWithSQLConnection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoPtController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly DatabaseContext _dbContext;

        private readonly string _textSearchBaseUrl = "https://arquivo.pt/textsearch";
        private readonly string _imageSearchBaseUrl = "https://arquivo.pt/imagesearch";

        public ArquivoPtController(IHttpClientFactory httpClientFactory, DatabaseContext dbContext)
        {
            _httpClient = httpClientFactory.CreateClient();
            _dbContext = dbContext;
        }


        [HttpGet("TextSearch")]
        public async Task<IActionResult> TextSearch(string? q, string? from = null, string? to = null, string? type = null, int offset = 0, string? siteSearch = null, string? collection = null, int maxItems = 50, string? fields = null, bool prettyPrint = true)
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

        [HttpGet("SearchGovernmentPolicies")]
        public async Task<IActionResult> SearchGovernmentPolicies()
        {
            string q = "política habitacional";
            string from = "19600101000000";
            string to = "20201231235959";
            string siteSearch = "www.dn.pt";

            return await TextSearch(q, from, to, null, 0, siteSearch, null, 50, "tstamp,title,originalURL,linkToExtractedText");
        }

        [HttpGet("SearchPrices")]
        public async Task<IActionResult> SearchPrices()
        {
            string q = "preços";
            string from = "19600101000000";
            string to = "20201231235959";
            string siteSearch = "www.idealista.pt";

            return await TextSearch(q, from, to, null, 0, siteSearch, null, 50, "tstamp,title,originalURL,linkToExtractedText");
        }

        [HttpGet("SearchProperties")]
        public async Task<IActionResult> SearchProperties()
        {
            string q = "propriedades";
            string from = "19600101000000";
            string to = "20201231235959";
            string siteSearch = "www.idealista.pt";

            return await TextSearch(q, from, to, null, 0, siteSearch, null, 50, "tstamp,title,originalURL,linkToExtractedText");
        }

        [HttpGet("SearchPublicSentiments")]
        public async Task<IActionResult> SearchPublicSentiments()
        {
            string q = "sentimento de habitação";
            string from = "19600101000000";
            string to = "20201231235959";
            string siteSearch = "www.rtp.pt";

            return await TextSearch(q, from, to, null, 0, siteSearch, null, 50, "tstamp,title,originalURL,linkToExtractedText");
        }

        private async Task<IActionResult> MakeRequest(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(result);

                if (apiResponse.Response_Items != null)
                {
                    await SaveData(apiResponse.Response_Items);
                }

                return Ok("Data processed and saved successfully!");
            }
            catch (HttpRequestException e)
            {
                return BadRequest($"Error making the request: {e.Message}");
            }
            catch (JsonSerializationException jsonEx)
            {
                return BadRequest($"JSON deserialization error: {jsonEx.Message}");
            }
        }

        private async Task SaveData(List<ApiResponseItem> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"Title: {item.Title}, URL: {item.OriginalUrl}, Timestamp: {item.Timestamp}");

                var governmentPolicy = new Government_Policy
                {
                    Year = item.Timestamp.Year,
                    Description = item.Title,
                    LinkExtractedText = item.LinkToExtractedText,
                    Impact = "Not found",
                    OriginalURL = item.OriginalUrl
                };

                var price = new Price
                {
                    Decade = item.Timestamp.Year,
                    PriceValue = item.Title,
                    LinkExtractedText = item.LinkToExtractedText,
                    OriginalURL = item.OriginalUrl
                };

                var property = new Property
                {
                    Year = item.Timestamp.Year,
                    PropertyType = item.Title,
                    LinkExtractedText = item.LinkToExtractedText,
                    OriginalURL = item.OriginalUrl,
                    Price = 1
                };

                var publicSentiment = new PublicSentiment
                {
                    Year = item.Timestamp.Year,
                    Comments = item.Title,
                    LinkExtractedText = item.LinkToExtractedText,
                    OriginalURL = item.OriginalUrl,
                    SentimentScore = 10
                    // Outros campos conforme necessário
                };

                Console.WriteLine($"Mapped Entity: Year: {governmentPolicy.Year}, Description: {governmentPolicy.Description}");

                _dbContext.Government_Policies.Add(governmentPolicy);
                _dbContext.Prices.Add(price);
                _dbContext.Properties.Add(property);
                _dbContext.PublicSentiments.Add(publicSentiment);
            }

            await _dbContext.SaveChangesAsync();
        }

    }
}