﻿using System;
using System.Collections.Generic;

namespace ProductManagement.Models;

public partial class product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public string? Category { get; set; }

    public string? Supplier { get; set; }
}
