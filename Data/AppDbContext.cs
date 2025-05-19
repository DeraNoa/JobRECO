using JobRECO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
{
    
}

namespace JobRECO.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }//データベースとのやりとり用の設定
        public DbSet<User> Users { get; set; }//データベースとのやりとり用の設定


        //使用するデータベースを指定する
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=attendance.db");
        }


    }
}
