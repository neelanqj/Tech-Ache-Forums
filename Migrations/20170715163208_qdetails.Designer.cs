using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TechAche.Persistance;

namespace TechAche.Migrations
{
    [DbContext(typeof(TechAcheDbContext))]
    [Migration("20170715163208_qdetails")]
    partial class qdetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechAche.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int?>("AnswerId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<int>("Downvotes");

                    b.Property<bool>("Editable");

                    b.Property<int?>("QuestionId");

                    b.Property<int>("Upvotes");

                    b.Property<int?>("UserId");

                    b.Property<int>("Views");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("TechAche.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnswerId");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("TechAche.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Closed");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Details");

                    b.Property<bool>("Disabled");

                    b.Property<int>("Downvotes");

                    b.Property<bool>("Editable");

                    b.Property<int?>("TagId");

                    b.Property<string>("Title");

                    b.Property<int>("Upvotes");

                    b.Property<int?>("UserId");

                    b.Property<int>("Views");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TechAche.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TechAche.Models.TextExtension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnswerId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<int?>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("TextExtensions");
                });

            modelBuilder.Entity("TechAche.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("Enabled");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("LastPostDate");

                    b.Property<Guid>("TechAcheId");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TechAche.Models.Answer", b =>
                {
                    b.HasOne("TechAche.Models.Answer")
                        .WithMany("Replies")
                        .HasForeignKey("AnswerId");

                    b.HasOne("TechAche.Models.Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");

                    b.HasOne("TechAche.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TechAche.Models.Photo", b =>
                {
                    b.HasOne("TechAche.Models.Answer")
                        .WithMany("Photos")
                        .HasForeignKey("AnswerId");

                    b.HasOne("TechAche.Models.Question")
                        .WithMany("Photos")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TechAche.Models.Question", b =>
                {
                    b.HasOne("TechAche.Models.Tag")
                        .WithMany("Questions")
                        .HasForeignKey("TagId");

                    b.HasOne("TechAche.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TechAche.Models.TextExtension", b =>
                {
                    b.HasOne("TechAche.Models.Answer")
                        .WithMany("AnswerExtensions")
                        .HasForeignKey("AnswerId");

                    b.HasOne("TechAche.Models.Question")
                        .WithMany("QuestionExtensions")
                        .HasForeignKey("QuestionId");
                });
        }
    }
}
