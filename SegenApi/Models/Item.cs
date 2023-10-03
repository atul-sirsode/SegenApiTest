using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SegenApi.Models
{
    public record Item
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime ModifiedAt { get; init; }
    }
}