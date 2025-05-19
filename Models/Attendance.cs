using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobRECO.Models
{
    public class Attendance
    {

        public int Id { get; set; }//IDプロパティ
        // ---- 外部キー ----
        public int UserId { get; set; }//ユーザーIDプロパティ
        public User User { get; set; } = null!;

        // ---- 勤怠 ----
        [Column(TypeName = "date")]           // 日付だけを保持
        public DateTime WorkDate { get; set; }//日付プロパティ
        public DateTime? ClockIn { get; set; }//出勤時間プロパティ
        public DateTime? ClockOut { get; set; }//退勤時間プロパティ


        // ---- ナビゲーション ----
        public ICollection<WorkLog> WorkLogs { get; set; } = new List<WorkLog>();
    }
}
