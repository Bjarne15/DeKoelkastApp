using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DeKoelkastApp.Models
{
    [Table("Products")]
    public class Product : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("naam")]
        public string Naam { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("min_stock")]
        public int MinStock { get; set; }
    }
}