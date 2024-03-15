
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

public enum TicketStatus
{
    Open, InProgess, Closed
}

//public enum PermissionLevels
//{
//
//}

namespace wiFind.Server
{
    public class WiFindContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Wifi> Wifis { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }
        public DbSet<UserAccountInfo> UserAccountInfos { get; set; }
        public DbSet<AdminAccountInfo> AdminAccountInfos { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public string DbPath { get; }
        public WiFindContext(DbContextOptions<WiFindContext> options) : base(options) { }
    }

    public class User
    {
        [JsonIgnore]
        [Key]
        public string user_id { get; set; }

        [Required, MaxLength(100)]
        public string first_name { get; set; } = "";

        [Required, MaxLength(100)]
        public string last_name { get; set; } = "";

        [Required, DataType(DataType.Date)]
        public DateOnly dob { get; set; }

        [Required, DataType(DataType.PhoneNumber), MaxLength(20)]
        public string phone_number { get; set; } = "";

        [DataType(DataType.Currency)]
        public decimal amt_made { get; set; } = 0.00M;

        [DataType(DataType.DateTime), AllowNull]
        public DateTime last_login { get; set; }

        [JsonIgnore]
        public ICollection<Wifi>? Wifis { get; set; }
        [JsonIgnore]
        public ICollection<Rent>? Rents { get; set; }
        [JsonIgnore]
        public ICollection<PaymentInfo>? PaymentInfos { get; set; }
        [JsonIgnore]
        public ICollection<UserAccountInfo> UserAccountInfos { get; set; }
        [JsonIgnore]
        public ICollection<Request>? Requests { get; set; }
        [JsonIgnore]
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
    
    public class Admin
    {
        [JsonIgnore]
        [Key]
        public string admin_id { get; set; }

        [Required, MaxLength(100)]
        public string first_name { get; set; } = "admin";

        [Required, MaxLength(100)]
        public string last_name { get; set; } = "inster";

        // TODO: Add a system for permission level.
        // Current levels are:
        // 1) T: View and Assign unassigned tickets to self. Every admin has this by default. (Ticket Only)
        // 2) TS: View, assign and remove ANY tickets (regardless of who owns it) to anyone. (Ticker supervisor)
        // 3) TU: Handles 'T' tasks and user records (ie: delete inactive users)
        // 4) TSU: Handles 'TS' and user records.
        [Required, MaxLength(5)]
        public string permission_level { get; set; } = "T";

        [JsonIgnore]
        public ICollection<SupportTicket>? SupportTickets { get; set; }
        [JsonIgnore]
        public ICollection<AdminAccountInfo> AdminAccountInfos { get; set; }
    }

    public class Wifi
    {
        [JsonIgnore]
        [Key]
        public string wifi_id { get; set;}

        [Required, MaxLength(50)]
        public string wifi_name { get; set; } = "My Wifi";

        [Required, MaxLength(100)]
        public string security { get; set; } = "Unknown";

        [Required]
        public float wifi_latitude { get; set; }

        [Required]
        public float wifi_longitude { get; set; }

        [Required]
        public float radius { get; set; }

        [Required, MaxLength(50)]
        public string wifi_source { get; set; } = "Unknown";

        [Required]
        public string owned_by {  get; set; }

        [JsonIgnore]
        [ForeignKey("owned_by")]
        public User User { get; set; }

        // Max number of users allowed to rent this wifi.
        // Use Rents table to count how many records are associated with the wifi_id
        // then prevent users from attempting to rent this wifi if count reached max_users
        [Required, Range(1,250)]
        public int max_users { get; set; }

        [JsonIgnore]
        public ICollection<Rent>? Rents { get; set; }

        [JsonIgnore]
        public ICollection<Request>? Requests { get; set; }
    }

    // ***Only insert into table after a successful Request and Response from Rentee and Renter.
    public class Rent
    {
        [JsonIgnore]
        [Key]
        public string rent_id { get; set; }

        public string? user_id {  get; set; }

        [JsonIgnore]
        [ForeignKey("user_id")]
        public User User { get; set; }

        public string? wifi_id { get; set; }

        [JsonIgnore]
        [ForeignKey("wifi_id")]
        public Wifi Wifi { get; set; }

        [Required]
        public DateTime start_time { get; set; }

        // End Time is decided in real time. User needs to click a button to end wifi renting.
        // When user requests wifi, it should not be like booking systems where there is a start and end time.
        // End time is used for profit calculations.
        [AllowNull]
        public DateTime end_time { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal locked_rate {  get; set; }

        // Renter is accountable for making guest account on renter's wifi.
        [DataType(DataType.Password), MaxLength(70)]
        public string? guest_password {  get; set; }
    }

    public class PaymentInfo
    {
        [JsonIgnore]
        [Key]
        public string payInfo_id { get; set; }

        [Required]
        public string user_id { get; set; }

        [JsonIgnore]
        [ForeignKey("user_id")]
        public User User { get; set; }

        [Required, MaxLength(100)]
        public string payment_type { get; set; }

        [Required, MaxLength(200)]
        public string name_on_card { get; set; }

        [Required, DataType(DataType.CreditCard)]
        public string card_number { get; set; }

        [Required]
        public DateOnly exp_date { get; set; }
    }

    // User should be able to log in with either user's unique username or unique email
    public class UserAccountInfo
    {
        [Required, Key, MaxLength(50)]
        public string username { get; set; }

        [Required, DataType(DataType.EmailAddress), MaxLength(200)]
        public string email { get; set; }

        [Required]
        public byte[] passwordHash { get; set; }

        [Required]
        public byte[] passwordSalt { get; set; }

        [Required]
        public string user_id { get; set; }

        [JsonIgnore]
        [ForeignKey("user_id")]
        public User User { get; set; }

        [JsonIgnore]
        public ICollection<SupportTicket>? SupportTickets { get; set; }
    }

    public class AdminAccountInfo
    {
        [Required, Key, MaxLength(50)]
        public string username { get; set; }

        [Required, DataType(DataType.EmailAddress), MaxLength(200)]
        public string email { get; set; }

        [Required, JsonIgnore]
        public byte[] passwordHash { get; set; }

        [Required, JsonIgnore]
        public byte[] passwordSalt { get; set; }

        [Required]
        public string admin_id { get; set; }

        [JsonIgnore]
        [ForeignKey("admin_id")]
        public Admin Admin { get; set; }
    }

    public class SupportTicket
    {
        [JsonIgnore]
        [Key]
        public string ticket_id { get; set; }

        [Required]
        public string username { get; set; }

        [JsonIgnore]
        [ForeignKey("username")]
        public UserAccountInfo UserAccountInfo { get; set; }

        [Required]
        public DateTime time_stamp { get; set; }

        [Required, MaxLength(50)]
        public string subject { get; set; }

        [Required, MaxLength(500)]
        public string description { get; set; }

        [Required, MaxLength(50)]
        public TicketStatus status { get; set; }

        [AllowNull]
        public string? assigned_to { get; set; }

        [JsonIgnore]
        [ForeignKey("assigned_to")]
        public Admin Admin { get; set; }
    }

    // Requests and Response Tables will be updating frequently.
    // After a succesful request and response (could be yes or no from renter) OR Request times out,
    // Records should be deleted from the table.
    // Ex: If renter does not respond to request in time, should be deleted and not allow insertion
    // into response for that request

    // TODO: Decide how requests are tracked such as outgoing requests.
    // NEED TO CHECK that user_id (rentee) is not equal to Wifi.owned_by
    public class Request
    {
        [JsonIgnore]
        [Key]
        public string request_id {  get; set; }

        [Required]
        public string user_id { get; set; }

        [JsonIgnore]
        [ForeignKey("user_id")]
        public User User { get; set; }

        public string? wifi_id { get; set; }

        [JsonIgnore]
        [ForeignKey("wifi_id")]
        public Wifi Wifi { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime time_stamp { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime time_start { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal requested_rate { get; set; }

        [JsonIgnore]
        public ICollection<Response>? Responses { get; set; }
    }

    // Response and associated request should not be deleted until rentee acknowledges response and
    // new row is inserted into Rents.
    // If renter rejected, then delete these pairs after user acknowledges
    // If response is not acknowledged in time (such as user goes MIA indefinitely) delete pair of records
    public class Response
    {
        [JsonIgnore]
        [Key]
        public string respnse_id { get; set; }

        [Required]
        public string? request_id { get; set; }

        [JsonIgnore]
        [ForeignKey("request_id")]
        public Request Request { get; set; }

        // Yes or No to request
        [Required]
        public bool req_ans { get; set; }

        // Should have value if req_ans is yes, else this will be null
        [AllowNull, DataType(DataType.Password)]
        public string guest_password { get; set; }
    }
    
    public class Feedback
    {
        [JsonIgnore]
        [Key]
        public string? feedback_id { get; set; }

        public string? user_id { get; set; }

        [JsonIgnore]
        [ForeignKey("user_id")]
        public User User { get; set; }

        [Required, MaxLength(30)]
        public string subject { get; set; }

        [MaxLength(500)]
        public string description { get; set; } = "";

        [Required, Range(1,10)]
        public short rating { get; set; }

        [Required, DataType(DataType.Date)]
        public DateOnly date_stamp { get; set; }

    }
}
