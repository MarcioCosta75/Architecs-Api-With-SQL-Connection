namespace ApiWithSQLConnection.Models
{
    [Serializable]
    public class ApiResponse
    {
        public required string ServiceName { get; set; }
        public required List<ApiResponseItem> Response_Items { get; set; }
    }
}