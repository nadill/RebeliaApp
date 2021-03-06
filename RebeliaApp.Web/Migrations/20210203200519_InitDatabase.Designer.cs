﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Migrations
{
    [DbContext(typeof(RebeliaDBContext))]
    [Migration("20210203200519_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("RebeliaApp.Web.Model.Army", b =>
                {
                    b.Property<int>("ArmyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ArmyImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ArmyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SystemID")
                        .HasColumnType("int");

                    b.HasKey("ArmyID");

                    b.HasIndex("SystemID");

                    b.ToTable("Armies");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.Caster", b =>
                {
                    b.Property<int>("CasterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ArmyID")
                        .HasColumnType("int");

                    b.Property<string>("CasterImg")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CasterName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CasterID");

                    b.HasIndex("ArmyID");

                    b.ToTable("Caster");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.FriendlyGameResult", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("CastrKill")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeathClock")
                        .HasColumnType("bit");

                    b.Property<int>("PointFormat")
                        .HasColumnType("int");

                    b.Property<int>("Rounds")
                        .HasColumnType("int");

                    b.Property<int>("ScenarioID")
                        .HasColumnType("int");

                    b.Property<int>("SystemID")
                        .HasColumnType("int");

                    b.Property<int>("WinnerID")
                        .HasColumnType("int");

                    b.HasKey("GameID");

                    b.ToTable("FriendlyGameResults");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.GameSystem", b =>
                {
                    b.Property<int>("SystemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("SystemImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SystemName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SystemID");

                    b.ToTable("GameSystems");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.MapFormat", b =>
                {
                    b.Property<int>("MapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MediumFormat")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ScenarioID")
                        .HasColumnType("int");

                    b.Property<string>("SmallFormat")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StandardFormat")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SystemID")
                        .HasColumnType("int");

                    b.HasKey("MapID");

                    b.HasIndex("ScenarioID");

                    b.ToTable("MapFormat");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nick")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PlayerID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.PlayerScore", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ArmyID")
                        .HasColumnType("int");

                    b.Property<int>("ArmyPoints")
                        .HasColumnType("int");

                    b.Property<int>("CasterID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<int>("ObjectivePoints")
                        .HasColumnType("int");

                    b.Property<int>("ThemeID")
                        .HasColumnType("int");

                    b.HasKey("PlayerID");

                    b.HasIndex("GameID");

                    b.ToTable("PlayerScore");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.Scenario", b =>
                {
                    b.Property<int>("ScenarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ScenarioName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SystemID")
                        .HasColumnType("int");

                    b.HasKey("ScenarioID");

                    b.HasIndex("SystemID");

                    b.ToTable("Scenario");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.Theme", b =>
                {
                    b.Property<int>("ThemeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ArmyID")
                        .HasColumnType("int");

                    b.Property<int>("SystemID")
                        .HasColumnType("int");

                    b.Property<string>("ThemeImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ThemeName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ThemeID");

                    b.HasIndex("ArmyID");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.TournamentSoloGameResult", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ArmyID")
                        .HasColumnType("int");

                    b.Property<int>("ArmyPoints")
                        .HasColumnType("int");

                    b.Property<int>("BattleID")
                        .HasColumnType("int");

                    b.Property<int>("BattleResult")
                        .HasColumnType("int");

                    b.Property<bool>("Bye")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DefetedBy")
                        .HasColumnType("int");

                    b.Property<int>("ObjectivePoints")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerID")
                        .HasColumnType("int");

                    b.Property<int>("PointSize")
                        .HasColumnType("int");

                    b.Property<int>("Rounds")
                        .HasColumnType("int");

                    b.Property<string>("ScenarioName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SystemID")
                        .HasColumnType("int");

                    b.Property<int?>("ThemeID")
                        .HasColumnType("int");

                    b.Property<int>("TournamentPoints")
                        .HasColumnType("int");

                    b.HasKey("GameID");

                    b.HasIndex("ArmyID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("SystemID");

                    b.HasIndex("ThemeID");

                    b.ToTable("TournamentSoloGameResults");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.Army", b =>
                {
                    b.HasOne("RebeliaApp.Web.Model.GameSystem", null)
                        .WithMany("SystemArmies")
                        .HasForeignKey("SystemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.Caster", b =>
                {
                    b.HasOne("RebeliaApp.Web.Model.Army", null)
                        .WithMany("CasterList")
                        .HasForeignKey("ArmyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.MapFormat", b =>
                {
                    b.HasOne("RebeliaApp.Web.Model.Scenario", null)
                        .WithMany("ScenarioFormats")
                        .HasForeignKey("ScenarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.PlayerScore", b =>
                {
                    b.HasOne("RebeliaApp.Web.Model.FriendlyGameResult", null)
                        .WithMany("Players")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.Scenario", b =>
                {
                    b.HasOne("RebeliaApp.Web.Model.GameSystem", null)
                        .WithMany("SystemScenarios")
                        .HasForeignKey("SystemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.Theme", b =>
                {
                    b.HasOne("RebeliaApp.Web.Model.Army", null)
                        .WithMany("ArmyThemes")
                        .HasForeignKey("ArmyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.TournamentSoloGameResult", b =>
                {
                    b.HasOne("RebeliaApp.Web.Model.Army", "Army")
                        .WithMany()
                        .HasForeignKey("ArmyID");

                    b.HasOne("RebeliaApp.Web.Model.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID");

                    b.HasOne("RebeliaApp.Web.Model.GameSystem", "System")
                        .WithMany()
                        .HasForeignKey("SystemID");

                    b.HasOne("RebeliaApp.Web.Model.Theme", "Theme")
                        .WithMany()
                        .HasForeignKey("ThemeID");

                    b.Navigation("Army");

                    b.Navigation("Player");

                    b.Navigation("System");

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.Army", b =>
                {
                    b.Navigation("ArmyThemes");

                    b.Navigation("CasterList");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.FriendlyGameResult", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.GameSystem", b =>
                {
                    b.Navigation("SystemArmies");

                    b.Navigation("SystemScenarios");
                });

            modelBuilder.Entity("RebeliaApp.Web.Model.Scenario", b =>
                {
                    b.Navigation("ScenarioFormats");
                });
#pragma warning restore 612, 618
        }
    }
}
