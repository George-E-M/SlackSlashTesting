﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScoreboardsAPI.Models;

namespace ScoreboardsAPI.Migrations
{
    [DbContext(typeof(ScoreboardsContext))]
    [Migration("20181219201719_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("ScoreboardsAPI.Models.ScoreboardsItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Rank");

                    b.HasKey("Id");

                    b.ToTable("ScoreboardsItems");
                });
#pragma warning restore 612, 618
        }
    }
}
