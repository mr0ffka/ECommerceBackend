﻿using ECommerce.Application.Features.Categories.Queries.GetById;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetList;

public class ProductDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    //public string Description { get; set; }
    public decimal Price { get; set; }
    //public int Stock { get; set; }
    public byte[]? ImageBase64Value { get; set; }
    public CategoryDto Category { get; set; }
}
