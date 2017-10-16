using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RisingPhoenix.Models
{
    public partial class RisingPhoenixDBContext : DbContext
    {
        public RisingPhoenixDBContext(DbContextOptions<RisingPhoenixDBContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Face2Faces> Face2Faces { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<Htmoneys> Htmoneys { get; set; }
        public virtual DbSet<Meetings> Meetings { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<NonMembers> NonMembers { get; set; }
        public virtual DbSet<Referrals> Referrals { get; set; }
        public virtual DbSet<Security> Security { get; set; }

        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RisingPhoenixDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => e.MeetingId);

                entity.Property(e => e.MeetingId).ValueGeneratedNever();

                entity.HasOne(d => d.Meeting)
                    .WithOne(p => p.Attendance)
                    .HasForeignKey<Attendance>(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_attendance_meetings");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_attendance_members");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Face2Faces>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.Property(e => e.FormId).ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Form)
                    .WithOne(p => p.Face2Faces)
                    .HasForeignKey<Face2Faces>(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_face2faces_forms");

                entity.HasOne(d => d.MetId1Navigation)
                    .WithMany(p => p.Face2FacesMetId1Navigation)
                    .HasForeignKey(d => d.MetId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_face2faces_members_1");

                entity.HasOne(d => d.MetId2Navigation)
                    .WithMany(p => p.Face2FacesMetId2Navigation)
                    .HasForeignKey(d => d.MetId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_face2faces_members_2");

                entity.HasOne(d => d.MetId3Navigation)
                    .WithMany(p => p.Face2FacesMetId3Navigation)
                    .HasForeignKey(d => d.MetId3)
                    .HasConstraintName("FK_face2faces_members_3");

                entity.HasOne(d => d.MetId4Navigation)
                    .WithMany(p => p.Face2FacesMetId4Navigation)
                    .HasForeignKey(d => d.MetId4)
                    .HasConstraintName("FK_face2faces_members_4");
            });

            modelBuilder.Entity<Forms>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.Property(e => e.FormDate).HasColumnType("date");
            });

            modelBuilder.Entity<Htmoneys>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("HTMoneys");

                entity.Property(e => e.FormId).ValueGeneratedNever();

                entity.Property(e => e.Income).HasColumnType("money");

                entity.HasOne(d => d.Form)
                    .WithOne(p => p.Htmoneys)
                    .HasForeignKey<Htmoneys>(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_htmoneys_forms");

                entity.HasOne(d => d.RefForm)
                    .WithMany(p => p.Htmoneys)
                    .HasForeignKey(d => d.RefFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_htmoneys_referrals");
            });

            modelBuilder.Entity<Meetings>(entity =>
            {
                entity.HasKey(e => e.MeetingId);

                entity.Property(e => e.MeetingDate).HasColumnType("date");

                entity.Property(e => e.Speaker)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.First)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Last)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MemberSince).HasColumnType("date");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Profession)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NonMembers>(entity =>
            {
                entity.HasKey(e => e.NonMemId);

                entity.Property(e => e.NonMemEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NonMemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NonMemPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Referrals>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.Property(e => e.FormId).ValueGeneratedNever();

                entity.Property(e => e.SenderMsg).IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Referrals)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_referrals_clients");

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.ReferralsRecipient)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_referrals_members_recipient");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.ReferralsSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_referrals_members_sender");
            });

            modelBuilder.Entity<Security>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.Property(e => e.MemberId).ValueGeneratedNever();

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.Security)
                    .HasForeignKey<Security>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_security_members");
            });
        }
    }
}
