using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TASKMANAGER21.Models
{
    public partial class TASKDBContext : DbContext
    {
        public TASKDBContext()
        {
        }

        public TASKDBContext(DbContextOptions<TASKDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Projectd> Projectds { get; set; }
        public virtual DbSet<Resinf> Resinfs { get; set; }
        public virtual DbSet<Tasks1> Tasks1s { get; set; }
        public DbSet<Tasks1> MyTasks1 { get; set; } // by me
        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=MARUF-PC\\SQL2K19EXP;Database=TASKDB;User ID=sa;Password=1234;Trusted_Connection=True;MultipleActiveResultSets=true ");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tasks1>().Property(u => u.Rowid).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Projectd>(entity =>
            {
                entity.HasKey(e => e.Prid);

                entity.ToTable("PROJECTD");

                entity.Property(e => e.Prid)
                    .HasMaxLength(10)
                    .HasColumnName("PRID")
                    .HasDefaultValueSql("('0000000000')")
                    .IsFixedLength(true);

                entity.Property(e => e.Prdesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("PRDESC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prname)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("PRNAME")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Resinf>(entity =>
            {
                entity.HasKey(e => e.Rescode);

                entity.ToTable("RESINF");

                entity.Property(e => e.Rescode)
                    .HasMaxLength(12)
                    .HasColumnName("RESCODE")
                    .HasDefaultValueSql("('00000000000')")
                    .IsFixedLength(true);

                entity.Property(e => e.Resdesig)
                    .HasMaxLength(100)
                    .HasColumnName("RESDESIG");

                entity.Property(e => e.Resemail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RESEMAIL")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Resname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESNAME")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Resphone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("RESPHONE")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Resstatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("RESSTATUS")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Restype)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("RESTYPE")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Tasks1>(entity =>
            {
                entity.HasKey(e => e.Tskid)
                    .HasName("PK_TASK");

                entity.ToTable("TASKS1");

                entity.Property(e => e.Tskid)
                    .HasMaxLength(12)
                    .HasColumnName("TSKID")
                    .HasDefaultValueSql("('000000000000')")
                    .IsFixedLength(true);

                entity.Property(e => e.Rowid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROWID");

                entity.Property(e => e.Rowtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ROWTIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tskassigned)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("TSKASSIGNED")
                    .HasDefaultValueSql("('000000000000')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tskdesc)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TSKDESC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tskendtime)
                    .HasColumnType("datetime")
                    .HasColumnName("TSKENDTIME")
                    .HasDefaultValueSql("('01-Jan-1900')");

                entity.Property(e => e.Tskname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TSKNAME")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tskowner)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("TSKOWNER")
                    .HasDefaultValueSql("('000000000000')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tskpriority)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TSKPRIORITY")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tskproject)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("TSKPROJECT")
                    .HasDefaultValueSql("('0000000000')")
                    .IsFixedLength(true);

                entity.Property(e => e.Tskstart)
                    .HasColumnType("datetime")
                    .HasColumnName("TSKSTART")
                    .HasDefaultValueSql("('01-Jan-1900')");

                entity.Property(e => e.Tskstatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TSKSTATUS")
                    .HasDefaultValueSql("('pending')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
