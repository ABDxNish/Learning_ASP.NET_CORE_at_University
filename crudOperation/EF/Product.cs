using System;
using System.Collections.Generic;

namespace crudOperation.EF;

public partial class Product
{
    public int Pid { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductType { get; set; } = null!;

    public string Quantity { get; set; } = null!;

    public int Price { get; set; }
}
