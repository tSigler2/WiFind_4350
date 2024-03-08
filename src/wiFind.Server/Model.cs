using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using wiFind.Server.Migrations;

public enum TicketStatus
    {
        Open, Inprogess, Closed
    }

namespace wiFind.Server
{
    public class WiFindContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WiFiListing> WifiListing { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public string DbPath { get; }

        public WiFindContext(DbContextOptions<WiFindContext> options) : base(options) { }
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string fName { get; set; } = "";
        public string lName { get; set; } = "";
        public DateOnly dob { get; set; }
        public EmailAddressAttribute email { get; set; }
        public string phoneNumber { get; set; } = "";
        public double amtMade { get; set; }
        public DateTime lastLogin { get; set; }
        public string nickname { get; set; } = "";
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }

    public class RegisterViewModel
    {
        public string password { get; set; } = "";
        public EmailAddressAttribute email { get; set; }
        public  string fName { get; set; } = "";
        public string lName { get; set; } = "";
        public string phoneNumber { get; set; } = "";
        public double amtMade { get; set; } = 0.0;
        public DateOnly dob { get; set; }
        public string nickname { get; set; } = "";
    }

    public class WiFiListing
    {   
        [Key]
        public int Id { get; set; }
        public string name { get; set; } = "";
        public int ownedBy { get; set; }
        public double radius { get; set; }
        public DateTime timeListed { get; set; }
        public double curr_rate { get; set; }
        public int maxUser { get; set; }
        public string security { get; set; } = "";
    }

    public class LoginViewModel
    {
        public EmailAddressAttribute email { get; set; }
        public string password { get; set; } = "";
    }

    public class Feedback
    {
        public int Id { get; set; }
        [Key]
        public string UserId { get; set; } = "";
        public string Content { get; set; } = "";
        public int Rating { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; } = "";
        public string Description { get; set; } = "";
        public TicketStatus Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UniqueIdentifier { get; set; } = "";
    }
}
