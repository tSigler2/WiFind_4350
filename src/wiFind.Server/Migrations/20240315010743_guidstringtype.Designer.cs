﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wiFind.Server;

#nullable disable

namespace wiFind.Server.Migrations
{
    [DbContext(typeof(WiFindContext))]
    [Migration("20240315010743_guidstringtype")]
    partial class guidstringtype
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("wiFind.Server.AccountInfo", b =>
                {
                    b.Property<string>("username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("admin_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("username");

                    b.HasIndex("admin_id");

                    b.HasIndex("user_id");

                    b.ToTable("AccountInfos");
                });

            modelBuilder.Entity("wiFind.Server.Admin", b =>
                {
                    b.Property<string>("admin_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("permission_level")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("admin_id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("wiFind.Server.Feedback", b =>
                {
                    b.Property<string>("feedback_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly>("date_stamp")
                        .HasColumnType("date");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<short>("rating")
                        .HasColumnType("smallint");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("feedback_id");

                    b.HasIndex("user_id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("wiFind.Server.PaymentInfo", b =>
                {
                    b.Property<string>("payInfo_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("card_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("exp_date")
                        .HasColumnType("date");

                    b.Property<string>("name_on_card")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("payment_type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("payInfo_id");

                    b.HasIndex("user_id");

                    b.ToTable("PaymentInfos");
                });

            modelBuilder.Entity("wiFind.Server.Rent", b =>
                {
                    b.Property<string>("rent_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("end_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("guest_password")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<decimal>("locked_rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("start_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("wifi_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("rent_id");

                    b.HasIndex("user_id");

                    b.HasIndex("wifi_id");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("wiFind.Server.Request", b =>
                {
                    b.Property<string>("request_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("requested_rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("time_stamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("time_start")
                        .HasColumnType("datetime2");

                    b.Property<string>("user_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("wifi_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("request_id");

                    b.HasIndex("user_id");

                    b.HasIndex("wifi_id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("wiFind.Server.Response", b =>
                {
                    b.Property<string>("respnse_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("guest_password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("req_ans")
                        .HasColumnType("bit");

                    b.Property<string>("request_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("respnse_id");

                    b.HasIndex("request_id");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("wiFind.Server.SupportTicket", b =>
                {
                    b.Property<string>("ticket_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("assigned_to")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("status")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("time_stamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ticket_id");

                    b.HasIndex("assigned_to");

                    b.HasIndex("username");

                    b.ToTable("SupportTickets");
                });

            modelBuilder.Entity("wiFind.Server.User", b =>
                {
                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("amt_made")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("dob")
                        .HasColumnType("date");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("last_login")
                        .HasColumnType("datetime2");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("passwordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("passwordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("user_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("wiFind.Server.Wifi", b =>
                {
                    b.Property<string>("wifi_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("max_users")
                        .HasColumnType("int");

                    b.Property<string>("owned_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("radius")
                        .HasColumnType("real");

                    b.Property<string>("security")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("wifi_latitude")
                        .HasColumnType("real");

                    b.Property<float>("wifi_longitude")
                        .HasColumnType("real");

                    b.Property<string>("wifi_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("wifi_source")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("wifi_id");

                    b.HasIndex("owned_by");

                    b.ToTable("Wifis");
                });

            modelBuilder.Entity("wiFind.Server.AccountInfo", b =>
                {
                    b.HasOne("wiFind.Server.Admin", "Admin")
                        .WithMany("AccountInfos")
                        .HasForeignKey("admin_id");

                    b.HasOne("wiFind.Server.User", "User")
                        .WithMany("AccountInfos")
                        .HasForeignKey("user_id");

                    b.Navigation("Admin");

                    b.Navigation("User");
                });

            modelBuilder.Entity("wiFind.Server.Feedback", b =>
                {
                    b.HasOne("wiFind.Server.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("wiFind.Server.PaymentInfo", b =>
                {
                    b.HasOne("wiFind.Server.User", "User")
                        .WithMany("PaymentInfos")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("wiFind.Server.Rent", b =>
                {
                    b.HasOne("wiFind.Server.User", "User")
                        .WithMany("Rents")
                        .HasForeignKey("user_id");

                    b.HasOne("wiFind.Server.Wifi", "Wifi")
                        .WithMany("Rents")
                        .HasForeignKey("wifi_id");

                    b.Navigation("User");

                    b.Navigation("Wifi");
                });

            modelBuilder.Entity("wiFind.Server.Request", b =>
                {
                    b.HasOne("wiFind.Server.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wiFind.Server.Wifi", "Wifi")
                        .WithMany("Requests")
                        .HasForeignKey("wifi_id");

                    b.Navigation("User");

                    b.Navigation("Wifi");
                });

            modelBuilder.Entity("wiFind.Server.Response", b =>
                {
                    b.HasOne("wiFind.Server.Request", "Request")
                        .WithMany("Responses")
                        .HasForeignKey("request_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("wiFind.Server.SupportTicket", b =>
                {
                    b.HasOne("wiFind.Server.Admin", "Admin")
                        .WithMany("SupportTickets")
                        .HasForeignKey("assigned_to");

                    b.HasOne("wiFind.Server.AccountInfo", "AccountInfo")
                        .WithMany("SupportTickets")
                        .HasForeignKey("username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountInfo");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("wiFind.Server.Wifi", b =>
                {
                    b.HasOne("wiFind.Server.User", "User")
                        .WithMany("Wifis")
                        .HasForeignKey("owned_by")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("wiFind.Server.AccountInfo", b =>
                {
                    b.Navigation("SupportTickets");
                });

            modelBuilder.Entity("wiFind.Server.Admin", b =>
                {
                    b.Navigation("AccountInfos");

                    b.Navigation("SupportTickets");
                });

            modelBuilder.Entity("wiFind.Server.Request", b =>
                {
                    b.Navigation("Responses");
                });

            modelBuilder.Entity("wiFind.Server.User", b =>
                {
                    b.Navigation("AccountInfos");

                    b.Navigation("Feedbacks");

                    b.Navigation("PaymentInfos");

                    b.Navigation("Rents");

                    b.Navigation("Requests");

                    b.Navigation("Wifis");
                });

            modelBuilder.Entity("wiFind.Server.Wifi", b =>
                {
                    b.Navigation("Rents");

                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
