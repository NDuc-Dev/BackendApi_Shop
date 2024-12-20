﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Models
{
    public class ProductNameTag
    {
        #nullable disable
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int NameTagId { get; set; }
        [JsonIgnore]
        public NameTag NameTag { get; set; }
        public string CreateByUserId { get; set; }
        [JsonIgnore]
        public User CreateBy { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
