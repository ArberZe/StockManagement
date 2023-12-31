﻿using StockManagement.Domain.Common;

namespace StockManagement.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }

    }
}
