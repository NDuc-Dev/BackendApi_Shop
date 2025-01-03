﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared.Models
{
    public class User : IdentityUser
    {
#nullable disable

        [Required(ErrorMessage = "Full name is require")]
        public string FullName { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        [Column(TypeName = "decimal(9,0)")]
        public decimal TotalSpending { get; set; } = 0;
        public int SpendingPoint { get; set; } = 0;
        public bool AccountStatus { get; set; } = true;
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "datetime")]
        public DateTime LastLogin { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public ICollection<Brand> CreatedBrands { get; set; } = null;
        [JsonIgnore]
        public ICollection<Product> CreatedProducts { get; set; } = null;
        [JsonIgnore]
        public ICollection<Color> CreatedColors { get; set; } = null;
        [JsonIgnore]
        public ICollection<Size> CreatedSizes { get; set; } = null;
        [JsonIgnore]
        public ICollection<NameTag> CreatedTags { get; set; } = null;
        [JsonIgnore]
        public ICollection<Order> CreatedOrders { get; set; } = null;
    }
}
