using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class PublicSentiment_Decade
    {
        [Key]
        public int SentimentID { get; set; }
        public int Decade { get; set; }
        public decimal SentimentScore { get; set; }
        public string Comments { get; set; }
    }
}