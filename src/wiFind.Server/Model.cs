
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

public enum TicketStatus
{
    Open, Inprogess, Closed
}

namespace wiFind.Server
{
    public class WiFindContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Wifi> Wifis { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }
        public DbSet<AccountInfo> AccountInfos { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public string DbPath { get; }
        public WiFindContext(DbContextOptions<WiFindContext> options) : base(options) { }
    }

    // Primary Key is user_id. No Foreign Keys.
    // Contains general information about User
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }

        [Required, MaxLength(100)]
        public string first_name { get; set; } = "";

        [Required, MaxLength(100)]
        public string last_name { get; set; } = "";

        // date of birth
        [Required, DataType(DataType.Date)]
        public DateOnly dob { get; set; }

        [Required, DataType(DataType.PhoneNumber), MaxLength(20)]
        public string phone_number { get; set; } = "";

        [DataType(DataType.Currency)]
        public decimal amt_made { get; set; } = 0.00M;

        [DataType(DataType.DateTime), AllowNull]
        public DateTime last_login { get; set; }
        
        [Required]
        public byte[] passwordHash { get; set; }

        [Required]
        public byte[] passwordSalt { get; set; }

        public ICollection<Wifi>? Wifis { get; set; }
        public ICollection<Rent>? Rents { get; set; }
        public ICollection<PaymentInfo>? PaymentInfos { get; set; }
        public ICollection<AccountInfo>? AccountInfos { get; set; }
        public ICollection<SupportTicket>? SupportTickets { get; set; }
        public ICollection<Request>? Requests { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
    }

    // Primary Key is admin_id. No Foreign Keys.
    // Contains general information about Admin
    public class Admin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int admin_id { get; set; }

        [Required, MaxLength(100)]
        public string first_name { get; set; } = "admin";

        [Required, MaxLength(100)]
        public string last_name { get; set; } = "inster";

        [Required]
        public byte[] passwordHash { get; set; }

        [Required]
        public byte[] passwordSalt { get; set; }

        // TODO: Add a system for permission level.
        // Current levels are:
        // 1) T: View and Assign unassigned tickets to self. Every admin has this by default. (Ticket Only)
        // 2) TS: View, assign and remove ANY tickets (regardless of who owns it) to anyone. (Ticker supervisor)
        // 3) TU: Handles 'T' tasks and user records (ie: delete inactive users)
        // 4) TSU: Handles 'TS' and user records.
        [Required, MaxLength(5)]
        public string permission_level { get; set; } = "T";

        public ICollection<AccountInfo>? AccountInfos { get; set; }
        public ICollection<SupportTicket>? SupportTickets { get; set; }
    }

    // Primary Key is wifi_id. Foreign Keys: owned_by references user_id in User
    // Contains general information about Existing Wifis
    public class Wifi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wifi_id { get; set;}

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
        public int owned_by {  get; set; }

        [ForeignKey("owned_by")]
        public User User { get; set; }

        // Max number of users allowed to rent this wifi.
        // Use Rents table to count how many records are associated with the wifi_id
        // then prevent users from attempting to rent this wifi if count reached max_users
        [Required, Range(1,250)]
        public int max_users { get; set; }

        // if feedback is for each wifi, not WiFind
        //public ICollection<Feedback>? Feedbacks { get; set; }
        public ICollection<Rent>? Rents { get; set; }
        public ICollection<Request>? Requests { get; set; }
    }

    // PK: (user_id, wifi_id) tuple. FK: user_id from user_id in User, wifi_id from wifi_id in Wifi
    // ***Only insert into table after a successful Request and Response from Rentee and Renter.
    // Information from Request and Response are required to fill this table.
    // User can rent many different wifis; One wifi can be rented by multiple users.
    public class Rent
    {
        [Required]
        public int user_id {  get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }

        [Required]
        public int wifi_id { get; set; }
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

        // TODO: Hash Salt this?
        // Renter is accountable for making guest account on renter's wifi.
        [DataType(DataType.Password), MaxLength(70)]
        public string? guest_password {  get; set; }
    }

    // PaymentInfo is associated with user_id.
    // Assuming user could create multiple accounts and save the same payment info on each account
    // Primary Key for this table is (user_id, card_number) tuple
    public class PaymentInfo
    {
        [Required]
        public int user_id { get; set; }
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

    // AccountInfo should have existing user_id XOR admin_id
    // PK: username FK: user_id XOR admin_id
    // User should be able to log in with either user's unique username or unique email
    public class AccountInfo
    {
        [Required, Key, MaxLength(50)]
        public string username { get; set; }

        [Required, DataType(DataType.EmailAddress), MaxLength(200)]
        public string email { get; set; }

        [Required, DataType(DataType.Password)]
        public string password { get; set;}

        [AllowNull]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }

        [AllowNull]
        public int admin_id { get; set; }
        [ForeignKey("admin_id")]
        public Admin Admin { get; set; }
    }

    // PK: ticket_id, FK: user_id (required), assigned_to (optional) references admin_id in Admin
    // TODO: tickets with resolved status needs to be deleted (TTL?)
    public class SupportTicket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ticket_id { get; set; }

        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }

        [Required]
        public DateTime time_stamp { get; set; }

        [Required, MaxLength(50)]
        public string subject { get; set; }

        [Required, MaxLength(500)]
        public string description { get; set; }

        [Required, MaxLength(50)]
        public TicketStatus status { get; set; }

        [AllowNull]
        public int assigned_to { get; set; }
        [ForeignKey("assigned_to")]
        public Admin Admin { get; set; }
    }

    // Requests and Response Tables will be updating frequently.
    // After a succesful request and response (could be yes or no from renter) OR Request times out,
    // Records should be deleted from the table.
    // Ex: If renter does not respond to request in time, should be deleted and not allow insertion
    // into response for that request

    // TODO: Decide how requests are tracked such as outgoing requests. Add time out to request record.
    // user_id is the rentee, use wifi_id to get renter's id (Wifi.owned_by)
    // NEED TO CHECK that user_id (rentee) is not equal to Wifi.owned_by
    public class Request
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int request_id {  get; set; }

        [Required]
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }

        [Required]
        public int wifi_id { get; set; }
        [ForeignKey("wifi_id")]
        public Wifi Wifi { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime time_stamp { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime time_start { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal requested_rate { get; set; }

        public ICollection<Response>? Responses { get; set; }
    }

    // Response and associated request should not be deleted until rentee acknowledges response and
    // new row is inserted into Rents.
    // If renter rejected, then delete these pairs after user acknowledges
    // If response is not acknowledged in time (such as user goes MIA indefinitely) delete pair of records
    public class Response
    {
        [Required]
        public int request_id { get; set; }
        [ForeignKey("request_id")]
        public Request Request { get; set; }

        // Yes or No to request
        [Required]
        public bool req_ans { get; set; }

        // Should have value if req_ans is yes, else this will be null
        // TODO: hash salt this too?
        [AllowNull, DataType(DataType.Password)]
        public string guest_password { get; set; }
    }
    
    // PK: (user_id, feedback_no) FK: user_id (assumes feedback is for WiFind website)
    // TODO: IF feedback is meant for each wifi, then PK is (user_id, wifi_id, feedback_no)
    // Weak Entity. feedback_no is not unique and is only unique with user_id.
    // Ex: user can make many feedback such as 5 reviews (1, 2, 3, 4, 5 will be the feedback_no)
    // another user can also make as many feedback and the feedback_no will also be 1, 2, 3, 4, 5
    public class Feedback
    {
        [Required]
        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }

        //[Required]
        //public int wifi_id { get; set; }

        //[ForeignKey("wifi_id")]
        //public Wifi Wifi { get; set; }
        
        [Required]
        public short feedback_no { get; set; }

        [Required, MaxLength(30)]
        public string subject { get; set; }

        [MaxLength(500)]
        public string description { get; set; } = "";

        // TODO: Decide if this is a scale of 1-5 OR 1-10
        [Required, Range(1,10)]
        public byte rating { get; set; }

        [Required, DataType(DataType.Date)]
        public DateOnly date_stamp { get; set; }

    }
}
