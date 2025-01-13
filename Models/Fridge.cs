using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DeKoelkastApp.Models
{
    [Table("Fridges")]
    public class Fridge : BaseModel
    {
        [PrimaryKey("id", false)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("stock")]
        public int Stock { get; set; }
    }
}