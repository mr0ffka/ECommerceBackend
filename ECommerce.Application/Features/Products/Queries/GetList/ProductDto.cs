﻿using ECommerce.Application.Features.Categories.Queries.GetById;
using ECommerce.Application.Models.Simple.File;

namespace ECommerce.Application.Features.Products.Queries.GetList;

public class ProductDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public CategoryDto Category { get; set; }
    public FileUrlDto? Thumbnail { get; set; }
}
