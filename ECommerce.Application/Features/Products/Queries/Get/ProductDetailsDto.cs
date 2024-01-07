﻿using ECommerce.Application.Features.Categories.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.Get;

public class ProductDetailsDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public byte[]? ImageBase64Value { get; set; }
    public CategoryDto Category { get; set; }
}
