﻿using System.ComponentModel.DataAnnotations;

namespace ApiWithSQLConnection.Models.Database
{
    public class Government_Policy
    {
        [Key]
        public int PolicyID { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        [MaxLength(255)]
        public string Impact { get; set; }
    }
}