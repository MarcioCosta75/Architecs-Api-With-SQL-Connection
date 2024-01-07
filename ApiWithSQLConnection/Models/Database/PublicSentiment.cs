using System;
using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class PublicSentiment
    {
        [Key]
        public int SentimentID { get; set; }
        public int Year { get; set; }
        public decimal SentimentScore { get; set; }
        public string Comments { get; set; }
    }
}