﻿namespace AdminApi.DTOs.Brand
{
    public class BrandDto
    {
        public int BrandId { get; set; }
        public string? BrandName { get ; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; } = null;

    }
}