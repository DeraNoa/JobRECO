using JobRECO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobRECO.Models;

    


namespace JobRECO.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users => Set<User>();//データベースとのやりとり用の設定
        public DbSet<Attendance> Attendances => Set<Attendance>();//データベースとのやりとり用の設定
        public DbSet<WorkLog> WorkLogs => Set<WorkLog>();//データベースとのやりとり用の設定

        //使用するデータベースを指定する
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=attendance.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- User ↔ Attendance (1:N) ---
            modelBuilder.Entity<Attendance>()
                        .HasOne(a => a.User)
                        .WithMany(u => u.Attendances)
                        .HasForeignKey(a => a.UserId)
                        .OnDelete(DeleteBehavior.Cascade);

            // --- Attendance ↔ WorkLog (1:N) ---
            modelBuilder.Entity<WorkLog>()
                        .HasOne(w => w.Attendance)
                        .WithMany(a => a.WorkLogs)
                        .HasForeignKey(w => w.AttendanceId)
                        .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
