namespace ApiWithSQLConnection.Models
{
    [Serializable]
    public class ApiResponseItem
    {
        public string Title { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime Timestamp { get; set; }
        public string LinkToExtractedText { get; set; }

    }
}