﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using wiFind.Server.Helpers;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region UserSeed
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    user_id = "15ced7de-6cde-4d80-abc7-fb5d86179912",
                    first_name = "user1",
                    last_name = "tester",
                    dob = DateOnly.FromDateTime(new DateTime()),
                    phone_number = "111-1111-1111",
                },
                new User
                {
                    user_id = "06ed4db9-5799-4f39-85ba-3ac9c7f28729",
                    first_name = "user2",
                    last_name = "tester",
                    dob = DateOnly.FromDateTime(new DateTime()),
                    phone_number = "222-222-2222",
                },
                new User
                {
                    user_id = "c1c35566-4fd3-4839-aa94-d8c85ccd4943",
                    first_name = "user3",
                    last_name = "tester",
                    dob = DateOnly.FromDateTime(new DateTime()),
                    phone_number = "333-333-3333",
                },
                new User
                {
                    user_id = "f69b8103-bf31-4cf0-a624-4f848de8a2eb",
                    first_name = "user4",
                    last_name = "tester",
                    dob = DateOnly.FromDateTime(new DateTime()),
                    phone_number = "444-444-4444",
                },
                new User
                {
                    user_id = "ea2cef69-f132-402a-a162-e7d774388a64",
                    first_name = "user5",
                    last_name = "tester",
                    dob = DateOnly.FromDateTime(new DateTime()),
                    phone_number = "555-555-5555",
                },
                new User
                {
                    user_id = "f57d0e07-917a-47ea-86fc-eeee80ae5f13",
                    first_name = "user6",
                    last_name = "tester",
                    dob = DateOnly.FromDateTime(new DateTime()),
                    phone_number = "666-666-6666",
                },
                new User
                {
                    user_id = "1c96d917-98fc-402e-855e-5ddf1e5276b6",
                    first_name = "user7",
                    last_name = "tester",
                    dob = DateOnly.FromDateTime(new DateTime()),
                    phone_number = "777-777-7777",
                },
                new User
                {
                    user_id = "2a4aebdc-1a4f-47ee-b415-e4a6797f4231",
                    first_name = "user8",
                    last_name = "tester",
                    dob = DateOnly.FromDateTime(new DateTime()),
                    phone_number = "888-888-8888",
                },
                new User
                {
                    user_id = "cc7c133a-b731-4299-b310-770ba9f3fe9f",
                    first_name = "user9",
                    last_name = "tester",
                    dob = DateOnly.FromDateTime(new DateTime()),
                    phone_number = "999-999-9999",
                },
                new User
                {
                    user_id = "f4140a29-60b3-4e84-a8d6-0274432509a5",
                    first_name = "user10",
                    last_name = "tester",
                    dob = DateOnly.FromDateTime(new DateTime()),
                    phone_number = "000-000-0000",
                });
            #endregion

            #region UserAccountInfoSeed

            modelBuilder.Entity<UserAccountInfo>().HasData(
                new UserAccountInfo
                {
                    user_id = "15ced7de-6cde-4d80-abc7-fb5d86179912",
                    username = "user1",
                    email = "user1@example.com",
                    passwordHash = Utils.VarBinStrToBinaryArray("0xA28593CF70DEBC68DAEDF4F2233087ABBB450F5026E1A80799197E009F628CC5688C5016ACC3DC2492DDE500305A97C27A95D5A571809AE91D9FAC4DE8A3B9B2"),
                    passwordSalt = Utils.VarBinStrToBinaryArray("0xFD0D06798BB7CA2D87F66EAE7AC7BBADB025CC841DE6DD27746CD260EEA52C58D30D249540F6E866BE9BEEA6A3D01727976DC25F39E17C80D3D03F07B9DB0EC6E3EFD4B6919EDE5128A5C36B322E15667D05ED9E6ACC6CA3C728BD4EE7AF78786DD19A6E2332C8141D662C90C582F584238C0EC2F200DAE65BC98A850D177416"),
                },
                new UserAccountInfo
                {
                    user_id = "06ed4db9-5799-4f39-85ba-3ac9c7f28729",
                    username = "user2",
                    email = "user2@example.com",
                    passwordHash = Utils.VarBinStrToBinaryArray("0xFD0F5FBE3AB3AEE17D7D6CA2A2B4FF95E03265ECE07BD5E4A00A7E0E15858A788446185273D3C1C8DAE1929400FA735B447BEC7813978C5FC371491CD19C7B6F"),
                    passwordSalt = Utils.VarBinStrToBinaryArray("0xC886A733870B41000FED660C8CCBE225715E5AC1DC33B373C825BDEBC8C131D8DDFA4106F76BD6BF1A11EF2FB18C7DFFE7D89C20FB52B1A7F6EAE8ED9DD7C35916D2CDDC92A3513951FD60791A0C596DF25D06CDCA3D05EFF50166E9656A2D3D4DF89444FF011887AEDBC9D205703BE9E350E3AB7803D2FE5E373E43B8451567"),
                },
                new UserAccountInfo
                {
                    user_id = "c1c35566-4fd3-4839-aa94-d8c85ccd4943",
                    username = "user3",
                    email = "user3@example.com",
                    passwordHash = Utils.VarBinStrToBinaryArray("0xF0E7D0266C1898717D7772DB8366C771D3A582FEC8698EE1A2FCC38E03277F8C357F24BF0928606BD4BCA596B2E8C02AA1BF653A65F8FB3B92AC201CBC3ED6F9"),
                    passwordSalt = Utils.VarBinStrToBinaryArray("0xAA0791E63B76C5FBF41FF70D3FE74BD6F3258580C049BFC6575C5A24E65B95BA7D5479566C14037A723C3F050AE79DC5CAF4DD60C777D722DC11618106DB88231C8808FCF435BD27D97242670750D74E0C3C9EE61D1CB14AF108EEBE21010BCE6EE31F7A2C3BFF8F929752A07261898FB8D061801E5DD1F19C972C8FCE717728"),
                },
                new UserAccountInfo
                {
                    user_id = "f69b8103-bf31-4cf0-a624-4f848de8a2eb",
                    username = "user4",
                    email = "user4@example.com",
                    passwordHash = Utils.VarBinStrToBinaryArray("0xED8063B1DA458CC5BD9C7B84D18793B505FFE91CA8F147BEE6337BD1F2E4C9C44EDE55C77EC5DFE730D97F2F0D8D2AE15914F692C42FC8E060A4A5AA79135C64"),
                    passwordSalt = Utils.VarBinStrToBinaryArray("0x1583C3EC068A27E7925043E122FB41773C0C83F675876154DAC1F55C3BA1408D02C0933446B583BD12CC5FA46BE13B5469D421A66609AAF2DF97428B89CE578F01E6B3A74215E2663E2679C55DD345CD1D40A1E89D942407A7C936070935665AA3DC09502C560A5FC4D9A6F7936A7504CEF92755BBC0A1C73BE0D31598CC5FAF"),
                },
                new UserAccountInfo
                {
                    user_id = "ea2cef69-f132-402a-a162-e7d774388a64",
                    username = "user5",
                    email = "user5@example.com",
                    passwordHash = Utils.VarBinStrToBinaryArray("0xFA29DE8A6AE1ACAFA9D1A56A072B1FC3640DCE0770015BDBC2D42D29DBF4DAF1547840C10C28F0BB52AAE2083D9257D79C643FEB0FE703ED08E28124D1D5C0B7"),
                    passwordSalt = Utils.VarBinStrToBinaryArray("0xCC6B9204FD64DD60A75C8B2B5883A6156D4E1DF6BA77F09EA8E883F949C34569A639073DA78238453DF6A9848B751DF781AE10B9CCDD935AE5DC5A86455FDE4052FBBE3704319E70CB1B60168A903A3D0DA7908436658CFBBE774BD42E731B5855A2CD099209F55848DEAD420073728B9D0342D2B0D2A9C44DED291406844378"),
                },
                new UserAccountInfo
                {
                    user_id = "f57d0e07-917a-47ea-86fc-eeee80ae5f13",
                    username = "user6",
                    email = "user6@example.com",
                    passwordHash = Utils.VarBinStrToBinaryArray("0x74CB773B457B48FD49A49648D0B0D200FE9A58284FE39723FC18FC5A42B332365455D714AA9A9B5F6F5A008CE048746E026C0C46B138F690700AE4B43D87EB2F"),
                    passwordSalt = Utils.VarBinStrToBinaryArray("0x84C6E5E028D4F61CF60F32081F3EF87BFD59D404871555D001FC260E8927DEFC3588AE7B1A1B7DBB0EABE96AAAC4B85995B2371A5558367D1A0F8A3967931D14E4DE9B11ABA353B50E17864CFD02D0D08D282FBEA3410769C0D5891A2C7FC4023FAF3449E0660359576DF84DA66999C363D693F9EE533BDD1F8E9FFA94A26BB0"),
                },
                new UserAccountInfo
                {
                    user_id = "1c96d917-98fc-402e-855e-5ddf1e5276b6",
                    username = "user7",
                    email = "user7@example.com",
                    passwordHash = Utils.VarBinStrToBinaryArray("0x0CE3BAD4B14154EF6461ED05EF76A173840706F707FFF4EC7190F516D0CC9C4407B6306D800267B2F230E8DCD7FC724F0D762AFDD669C637C9F0384D36134918"),
                    passwordSalt = Utils.VarBinStrToBinaryArray("0x5C90DB90CBA87ED1F55778BC54C070757A1ADC6617A7B6AE064EFBBEF1B69B6A622E7CF5389EB2EC87733136E2CE3608A44356A061818BEE4A17790E44193CDBD3516E6319CD215791B51FDFEC222D86BFDFA16547B87F44B8102A31E23AB8D3AF3CE63FB88707870C09DC0B898A0D651826BE83057D279CFE3089556118C2FC"),
                },
                new UserAccountInfo
                {
                    user_id = "2a4aebdc-1a4f-47ee-b415-e4a6797f4231",
                    username = "user8",
                    email = "user8@example.com",
                    passwordHash = Utils.VarBinStrToBinaryArray("0xC967C23AA26AD349171F122FA62FAFD4008BE9DC0E1FDD037F3D14E20C4B217DC9A3F9BC32831C03702CA2DAA154A165AECDE879094D1E3FAC3A1DB30CE992A1"),
                    passwordSalt = Utils.VarBinStrToBinaryArray("0x512DBE1FBA7E428E0FAB2ED656E45127FE6B272EA471139336ED8C5974239C1865EA3CB5DB5695E1247C39A43B42830F24A4A11D176A6072F1F9085937398CAF48962D923F0489A65A8056FBAF6BA49B3EE3254287CAB1B408C5ACBF184E7B2E59C415EED9D2FBC4212CDD69D7AE80CAAE078422CAF316D098D4CF9CCFA22B49"),
                },
                new UserAccountInfo
                {
                    user_id = "cc7c133a-b731-4299-b310-770ba9f3fe9f",
                    username = "user9",
                    email = "user9@example.com",
                    passwordHash = Utils.VarBinStrToBinaryArray("0xA161D570E7CB08B34D1DFAD29DB280C5B0483C4AA5BD088CDA195D25EB60A58EFFE6466242769AD16761AD2A9583B5CBDCFDC4A58594278968785D824EDD0E8F"),
                    passwordSalt = Utils.VarBinStrToBinaryArray("0x820177EF1C93BBA8841EFB012B74BDC82D55367561F4E7F39630E93A96231540E9ED6A6EB7DAF8622F1A0A52D792EFFD650C6D7F9290E3111E9A41142C9B073B5FCE33D004D305DAE6EF2551077CAF7E7614387EAA6B4C5234893623DEA3425B686132B3318601C68155A17B20CBA1734528B33DCB132038D9F34A10DF6651EE"),
                },
                new UserAccountInfo
                {
                    user_id = "f4140a29-60b3-4e84-a8d6-0274432509a5",
                    username = "user10",
                    email = "user10@example.com",
                    passwordHash = Utils.VarBinStrToBinaryArray("0x2DF2E071A47D40CD108AE1FB02B89E22D13D3AED7578213C5F249B87B4CADEEFEAE0BE89EF2D26A71F9E88112EB000B90FE17908F4DE55E0C946FC0E61CB67D5"),
                    passwordSalt = Utils.VarBinStrToBinaryArray("0x0240469D55679C0DFAAB07D081608EBB57B7143A671BE761AAD762E016A8A2105BA5CB91FF0BF578D4875EC7755E06A121B9ADEA712B20FC8B81D1A206C342B55E3ABB111652003C8836D36CF9C9574500BDA2704005B7C4D792B83177B6B817B542B6B42D73C046CDA07AB24A67E4C4BE0DF034EB0CEEA0539B5762FB3BF625"),
                });
            #endregion

            #region WifiSeed
            modelBuilder.Entity<Wifi>().HasData(
                new Wifi
                {
                    wifi_id = "91720bff-b076-4b89-9a6e-36eebd68403f",
                    wifi_name = "ItsWifi",
                    security = "SurpriseMe",
                    download_speed = 500,
                    upload_speed = 500,
                    wifi_latitude = 0,
                    wifi_longitude = 0,
                    wifi_source = "HotSpot",
                    radius = 10,
                    curr_rate = 0.50M,
                    time_listed = DateTime.Now,
                    owned_by = "user9",
                    max_users = 1
                },
                new Wifi
                {
                    wifi_id = "1d475c5a-f088-48fc-bb73-e83c5cbd364a",
                    wifi_name = "Wifi_1",
                    security = "Unsecure",
                    download_speed = 300,
                    upload_speed = 300,
                    wifi_latitude = 0,
                    wifi_longitude = 0,
                    wifi_source = "Fiber",
                    radius = 10,
                    curr_rate = 2.0M,
                    time_listed = DateTime.Now,
                    owned_by = "user1",
                    max_users = 50
                },
                new Wifi
                {
                    wifi_id = "34f3fb03-d917-48d2-8cd9-1e30c085cfb2",
                    wifi_name = "Wifi_2",
                    security = "More Secure",
                    download_speed = 300,
                    upload_speed = 200,
                    wifi_latitude = 0,
                    wifi_longitude = 0,
                    wifi_source = "Fiber",
                    radius = 10,
                    curr_rate = 5.0M,
                    time_listed = DateTime.Now,
                    owned_by = "user1",
                    max_users = 10
                },
                new Wifi
                {
                    wifi_id = "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                    wifi_name = "Wifi_3",
                    security = "WPA2",
                    download_speed = 450,
                    upload_speed = 444,
                    wifi_latitude = 10,
                    wifi_longitude = 10,
                    wifi_source = "ATT Fiber",
                    radius = 10,
                    curr_rate = 1.0M,
                    time_listed = DateTime.Now,
                    owned_by = "user3",
                    max_users = 50
                },
                new Wifi
                {
                    wifi_id = "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                    wifi_name = "Wifi_4",
                    security = "WPA3",
                    download_speed = 100,
                    upload_speed = 50,
                    wifi_latitude = 100,
                    wifi_longitude = -100,
                    wifi_source = "Starlink",
                    radius = 10,
                    curr_rate = 20.99M,
                    time_listed = DateTime.Now,
                    owned_by = "user3",
                    max_users = 1
                },
                new Wifi
                {
                    wifi_id = "8f704d7a-7de0-4b03-8230-36cdcc6f21d0",
                    wifi_name = "Wifi_5",
                    security = "Unsecured",
                    download_speed = 400,
                    upload_speed = 300,
                    wifi_latitude = 10,
                    wifi_longitude = -5,
                    wifi_source = "Starlink",
                    radius = 10,
                    curr_rate = 10.0M,
                    time_listed = DateTime.Now,
                    owned_by = "user10",
                    max_users = 100
                });
            #endregion
        }
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

        [Required, Range(1, 1000)]
        public int download_speed { get; set; } = 1;

        [Required, Range(1, 1000)]
        public int upload_speed { get; set; } = 1;

        [Required]
        public float wifi_latitude { get; set; }

        [Required]
        public float wifi_longitude { get; set; }

        [Required]
        public float radius { get; set; }

        [Required, MaxLength(50)]
        public string wifi_source { get; set; } = "Unknown";

        [Required, DataType(DataType.Currency)]
        public decimal curr_rate { get; set; } = 0.0M;

        [Required]
        public DateTime time_listed { get; set; }

        [Required]
        public string owned_by {  get; set; }

        [JsonIgnore]
        [ForeignKey("owned_by")]
        public UserAccountInfo UserAccountInfo { get; set; }

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

        [JsonIgnore]
        public ICollection<Wifi>? Wifis { get; set; }
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

        [JsonIgnore]
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
