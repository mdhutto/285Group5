using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLibrary.Models
{
    public partial class phoenix2Context : DbContext
    {
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Face2faces> Face2faces { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<Heresthemoneys> Heresthemoneys { get; set; }
        public virtual DbSet<Meetings> Meetings { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<NonmemberData> NonmemberData { get; set; }
        public virtual DbSet<Referrals> Referrals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-PJJRJ002\SQLEXPRESS;Database=phoenix2;User ID=LAPTOP-PJJRJ002\allie;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => e.MeetingId);

                entity.ToTable("attendance");

                entity.Property(e => e.MeetingId)
                    .HasColumnName("meeting_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AttendBool).HasColumnName("attend_bool");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

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

            modelBuilder.Entity<Face2faces>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("face2faces");

                entity.Property(e => e.FormId)
                    .HasColumnName("form_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetId1).HasColumnName("met_id_1");

                entity.Property(e => e.MetId2).HasColumnName("met_id_2");

                entity.Property(e => e.MetId3).HasColumnName("met_id_3");

                entity.Property(e => e.MetId4).HasColumnName("met_id_4");

                entity.HasOne(d => d.Form)
                    .WithOne(p => p.Face2faces)
                    .HasForeignKey<Face2faces>(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_face2faces_forms");

                entity.HasOne(d => d.MetId1Navigation)
                    .WithMany(p => p.Face2facesMetId1Navigation)
                    .HasForeignKey(d => d.MetId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_face2faces_members");

                entity.HasOne(d => d.MetId2Navigation)
                    .WithMany(p => p.Face2facesMetId2Navigation)
                    .HasForeignKey(d => d.MetId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_face2faces_members1");

                entity.HasOne(d => d.MetId3Navigation)
                    .WithMany(p => p.Face2facesMetId3Navigation)
                    .HasForeignKey(d => d.MetId3)
                    .HasConstraintName("FK_face2faces_members2");

                entity.HasOne(d => d.MetId4Navigation)
                    .WithMany(p => p.Face2facesMetId4Navigation)
                    .HasForeignKey(d => d.MetId4)
                    .HasConstraintName("FK_face2faces_members3");
            });

            modelBuilder.Entity<Forms>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("forms");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.FormDate)
                    .HasColumnName("form_date")
                    .HasColumnType("date");

                entity.Property(e => e.FormType)
                    .IsRequired()
                    .HasColumnName("form_type")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Heresthemoneys>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("heresthemoneys");

                entity.Property(e => e.FormId)
                    .HasColumnName("form_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Client)
                    .IsRequired()
                    .HasColumnName("client")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Income)
                    .HasColumnName("income")
                    .HasColumnType("money");

                entity.Property(e => e.ReferralFormId).HasColumnName("referral_form_id");

                entity.HasOne(d => d.Form)
                    .WithOne(p => p.Heresthemoneys)
                    .HasForeignKey<Heresthemoneys>(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_heresthemoneys_forms");

                entity.HasOne(d => d.ReferralForm)
                    .WithMany(p => p.Heresthemoneys)
                    .HasForeignKey(d => d.ReferralFormId)
                    .HasConstraintName("FK_heresthemoneys_referrals");
            });

            modelBuilder.Entity<Meetings>(entity =>
            {
                entity.HasKey(e => e.MeetingId);

                entity.ToTable("meetings");

                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

                entity.Property(e => e.MeetingDate)
                    .HasColumnName("meeting_date")
                    .HasColumnType("date");

                entity.Property(e => e.Speaker)
                    .HasColumnName("speaker")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("members");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.AbsenceCount).HasColumnName("absence_count");

                entity.Property(e => e.ActiveBool).HasColumnName("active_bool");

                entity.Property(e => e.AdminBool).HasColumnName("admin_bool");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.First)
                    .IsRequired()
                    .HasColumnName("first")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Last)
                    .IsRequired()
                    .HasColumnName("last")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MemberSince)
                    .HasColumnName("member_since")
                    .HasColumnType("date");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Profession)
                    .HasColumnName("profession")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPw)
                    .IsRequired()
                    .HasColumnName("user_pw")
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NonmemberData>(entity =>
            {
                entity.ToTable("nonmember_data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.NonMemberInfo)
                    .IsRequired()
                    .HasColumnName("non_member_info")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.NonmemberData)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nonmember_data_referrals");
            });

            modelBuilder.Entity<Referrals>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("referrals");

                entity.Property(e => e.FormId)
                    .HasColumnName("form_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BusinessCard).HasColumnName("business_card");

                entity.Property(e => e.CallClient).HasColumnName("call_client");

                entity.Property(e => e.Client)
                    .IsRequired()
                    .HasColumnName("client")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientContact)
                    .HasColumnName("client_contact")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientId).HasColumnName("recipient_id");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.Property(e => e.SenderIsMemberBool).HasColumnName("sender_is_member_bool");

                entity.HasOne(d => d.Form)
                    .WithOne(p => p.Referrals)
                    .HasForeignKey<Referrals>(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_referrals_forms");

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.ReferralsRecipient)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_referrals_members1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.ReferralsSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_referrals_members");
            });
        }
    }
}
