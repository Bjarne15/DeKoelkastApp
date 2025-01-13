using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace DeKoelkastApp.Models
{
    [Table("Users")]
    public class User : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("fullName")]
        public string FullName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
