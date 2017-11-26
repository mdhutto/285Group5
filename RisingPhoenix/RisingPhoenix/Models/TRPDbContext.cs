using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RisingPhoenix.Models
{
    public partial class TRPDbContext : DbContext
    {
    public TRPDbContext(DbContextOptions<TRPDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<Meetings> Meetings { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Security> Security { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TRPDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasKey(e => e.AttendanceId); //.ValueGeneratedOnAddOrUpdate(); ;

                entity.Property(e => e.MeetingId);

                entity.Property(e => e.MemberId);

                entity.Property(e => e.AbsenceBool);

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_Meetings");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Attendance)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_Members");
            });

            modelBuilder.Entity<Forms>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.Property(e => e.FormId);//.ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.FormType);

                entity.Property(e => e.FormDate).HasColumnType("date");

                entity.Property(e => e.SenderId);

                entity.Property(e => e.RecipientId);
                
                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientInfo).IsUnicode(false);

                entity.Property(e => e.Income).HasColumnType("money");

                entity.Property(e => e.NonMemberInfo).IsUnicode(false);

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.FormsRecipient)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Forms_Members_Rec1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.FormsSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Forms_Members_Sender");
            });

            modelBuilder.Entity<Meetings>(entity =>
            {
                entity.HasKey(e => e.MeetingId);

                entity.Property(e => e.MeetingId);//.ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.MeetingDate).HasColumnType("date");

                entity.Property(e => e.Speaker)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.Property(e => e.MemberId);//.ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Profession)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberSince).HasColumnType("date");

                //entity.Property(e => e.Password).HasColumnType("password");

                //SR: STUFF FOR THE REPORT PAGE
                entity.Property(e => e.frec);
                entity.Property(e => e.fsent);
                entity.Property(e => e.fincome).HasColumnType("money");
                entity.Property(e => e.ff2f);
            });

            modelBuilder.Entity<Security>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.Property(e => e.MemberId);//.ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ActiveBool);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Security)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Security_Members");

            });
        }
    }
}
