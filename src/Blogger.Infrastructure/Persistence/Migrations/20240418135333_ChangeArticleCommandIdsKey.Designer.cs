﻿// <auto-generated />
using System;
using Blogger.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blogger.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(BloggerDbContext))]
    [Migration("20240418135333_ChangeArticleCommandIdsKey")]
    partial class ChangeArticleCommandIdsKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("blog")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Blogger.Domain.ArticleAggregate.Article", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Body")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PublishedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("ReadOn")
                        .HasColumnType("time");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Articles", "blog");
                });

            modelBuilder.Entity("Blogger.Domain.CommentAggregate.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Comments", "blog");
                });

            modelBuilder.Entity("Blogger.Domain.SubscriberAggregate.Subscriber", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("JoinedOnUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Subscribers", "blog");
                });

            modelBuilder.Entity("Blogger.Domain.ArticleAggregate.Article", b =>
                {
                    b.OwnsOne("Blogger.Domain.ArticleAggregate.Author", "Author", b1 =>
                        {
                            b1.Property<string>("ArticleId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Avatar")
                                .IsRequired()
                                .HasMaxLength(1024)
                                .HasColumnType("nvarchar(1024)")
                                .HasColumnName("Author_Avatar");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Author_FullName");

                            b1.Property<string>("JobTitle")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("nvarchar(40)")
                                .HasColumnName("Author_JobTitle");

                            b1.HasKey("ArticleId");

                            b1.ToTable("Articles", "blog");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.OwnsMany("Blogger.Domain.ArticleAggregate.Tag", "Tags", b1 =>
                        {
                            b1.Property<string>("ArticleId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)");

                            b1.HasKey("ArticleId", "Id");

                            b1.ToTable("Tags", "blog");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.OwnsMany("Blogger.Domain.CommentAggregate.CommentId", "CommnetIds", b1 =>
                        {
                            b1.Property<Guid>("Value")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ArticleId")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("Value");

                            b1.HasIndex("ArticleId");

                            b1.ToTable("ArticleCommentIds", "blog");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.Navigation("Author")
                        .IsRequired();

                    b.Navigation("CommnetIds");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Blogger.Domain.CommentAggregate.Comment", b =>
                {
                    b.OwnsOne("Blogger.Domain.CommentAggregate.ApproveLink", "ApproveLink", b1 =>
                        {
                            b1.Property<Guid>("CommentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ApproveId")
                                .IsRequired()
                                .HasMaxLength(2077)
                                .HasColumnType("nvarchar(2077)")
                                .HasColumnName("ApproveLink_ApproveId");

                            b1.Property<DateTime>("ExpirationOnUtc")
                                .HasColumnType("datetime2")
                                .HasColumnName("ApproveLink_ApproveExpirationOnUtc");

                            b1.HasKey("CommentId");

                            b1.ToTable("Comments", "blog");

                            b1.WithOwner()
                                .HasForeignKey("CommentId");
                        });

                    b.OwnsOne("Blogger.Domain.ArticleAggregate.ArticleId", "ArticleId", b1 =>
                        {
                            b1.Property<Guid>("CommentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Slug")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ArticleId");

                            b1.HasKey("CommentId");

                            b1.ToTable("Comments", "blog");

                            b1.WithOwner()
                                .HasForeignKey("CommentId");
                        });

                    b.OwnsOne("Blogger.Domain.CommentAggregate.Client", "Client", b1 =>
                        {
                            b1.Property<Guid>("CommentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(1044)
                                .IsUnicode(true)
                                .HasColumnType("nvarchar(1044)")
                                .HasColumnName("Client_Email");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .IsUnicode(true)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Client_FullName");

                            b1.HasKey("CommentId");

                            b1.ToTable("Comments", "blog");

                            b1.WithOwner()
                                .HasForeignKey("CommentId");
                        });

                    b.OwnsMany("Blogger.Domain.CommentAggregate.Replay", "Replaies", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("CommentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Content")
                                .IsRequired()
                                .HasMaxLength(500)
                                .IsUnicode(false)
                                .HasColumnType("varchar(500)");

                            b1.Property<DateTime>("CreatedOnUtc")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsApproved")
                                .HasColumnType("bit");

                            b1.HasKey("Id");

                            b1.HasIndex("CommentId");

                            b1.ToTable("Replaies", "blog");

                            b1.WithOwner()
                                .HasForeignKey("CommentId");

                            b1.OwnsOne("Blogger.Domain.CommentAggregate.ApproveLink", "ApproveLink", b2 =>
                                {
                                    b2.Property<Guid>("ReplayId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("ApproveId")
                                        .IsRequired()
                                        .HasMaxLength(2077)
                                        .HasColumnType("nvarchar(2077)")
                                        .HasColumnName("ApproveLink_ApproveId");

                                    b2.Property<DateTime>("ExpirationOnUtc")
                                        .HasColumnType("datetime2")
                                        .HasColumnName("ApproveLink_ApproveExpirationOnUtc");

                                    b2.HasKey("ReplayId");

                                    b2.ToTable("Replaies", "blog");

                                    b2.WithOwner()
                                        .HasForeignKey("ReplayId");
                                });

                            b1.OwnsOne("Blogger.Domain.CommentAggregate.Client", "Client", b2 =>
                                {
                                    b2.Property<Guid>("ReplayId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Email")
                                        .IsRequired()
                                        .HasMaxLength(1044)
                                        .IsUnicode(true)
                                        .HasColumnType("nvarchar(1044)")
                                        .HasColumnName("Client_Email");

                                    b2.Property<string>("FullName")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .IsUnicode(true)
                                        .HasColumnType("nvarchar(100)")
                                        .HasColumnName("Client_FullName");

                                    b2.HasKey("ReplayId");

                                    b2.ToTable("Replaies", "blog");

                                    b2.WithOwner()
                                        .HasForeignKey("ReplayId");
                                });

                            b1.Navigation("ApproveLink")
                                .IsRequired();

                            b1.Navigation("Client")
                                .IsRequired();
                        });

                    b.Navigation("ApproveLink")
                        .IsRequired();

                    b.Navigation("ArticleId")
                        .IsRequired();

                    b.Navigation("Client")
                        .IsRequired();

                    b.Navigation("Replaies");
                });

            modelBuilder.Entity("Blogger.Domain.SubscriberAggregate.Subscriber", b =>
                {
                    b.OwnsMany("Blogger.Domain.ArticleAggregate.ArticleId", "ArticleIds", b1 =>
                        {
                            b1.Property<string>("Slug")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("SubscriberId")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("Slug");

                            b1.HasIndex("SubscriberId");

                            b1.ToTable("SubscriberArticleIds", "blog");

                            b1.WithOwner()
                                .HasForeignKey("SubscriberId");
                        });

                    b.Navigation("ArticleIds");
                });
#pragma warning restore 612, 618
        }
    }
}
