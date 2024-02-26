using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace wiFind.Server
{
    public class WiFindContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public string DbPath { get; }

        public WiFindContext(DbContextOptions<WiFindContext> options) : base(options) { }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string fName { get; set; } = "";
        public string lName { get; set; } = "";
        public string dob { get; set; } = "";
        public string email { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = "";
        public string amtMade { get; set; } = "";
        public string lastLogin { get; set; } = string.Empty;
        public string nickname { get; set; } = "";
    }
}
