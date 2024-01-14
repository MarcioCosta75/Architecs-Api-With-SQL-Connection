using System;
using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class PublicSentiment
    {
        [Key]
        public int SentimentID { get; set; }
        public int Year { get; set; }
        public string Comments { get; set; }

        public decimal SentimentScore { get; set; }

        public string LinkExtractedText { get; set; }

        public string OriginalURL { get; set; }
    }
}