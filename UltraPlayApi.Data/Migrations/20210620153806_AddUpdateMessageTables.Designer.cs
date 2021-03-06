// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UltraPlayApi.Data;

namespace UltraPlayApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210620153806_AddUpdateMessageTables")]
    partial class AddUpdateMessageTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UltraPlayApi.Data.Models.Bet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsLive")
                        .HasColumnType("bit");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniqueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.BetUpdateMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BetId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniqueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.ToTable("BetUpdateMessages");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportId")
                        .HasColumnType("int");

                    b.Property<int>("UniqueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SportId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("MatchType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UniqueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.MatchUpdateMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("UniqueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("MatchUpdateMessages");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Odd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BetId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialBetValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniqueId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BetId");

                    b.ToTable("Odds");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.OddUpdateMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OddId")
                        .HasColumnType("int");

                    b.Property<int>("UniqueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OddId");

                    b.ToTable("OddUpdateMessages");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Sport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UniqueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Bet", b =>
                {
                    b.HasOne("UltraPlayApi.Data.Models.Match", "Match")
                        .WithMany("Bets")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.BetUpdateMessage", b =>
                {
                    b.HasOne("UltraPlayApi.Data.Models.Bet", "Bet")
                        .WithMany()
                        .HasForeignKey("BetId");

                    b.Navigation("Bet");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Event", b =>
                {
                    b.HasOne("UltraPlayApi.Data.Models.Sport", "Sport")
                        .WithMany("Events")
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Match", b =>
                {
                    b.HasOne("UltraPlayApi.Data.Models.Event", "Event")
                        .WithMany("Matches")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.MatchUpdateMessage", b =>
                {
                    b.HasOne("UltraPlayApi.Data.Models.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Odd", b =>
                {
                    b.HasOne("UltraPlayApi.Data.Models.Bet", "Bet")
                        .WithMany("Odds")
                        .HasForeignKey("BetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bet");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.OddUpdateMessage", b =>
                {
                    b.HasOne("UltraPlayApi.Data.Models.Odd", "Odd")
                        .WithMany()
                        .HasForeignKey("OddId");

                    b.Navigation("Odd");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Bet", b =>
                {
                    b.Navigation("Odds");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Event", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Match", b =>
                {
                    b.Navigation("Bets");
                });

            modelBuilder.Entity("UltraPlayApi.Data.Models.Sport", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
