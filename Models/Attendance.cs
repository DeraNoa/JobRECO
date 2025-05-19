using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRECO.Models
{
    public class Attendance
    {

        public int Id { get; set; }//IDプロパティ
        public int UserId { get; set; }//ユーザーIDプロパティ
        public DateTime Date { get; set; }//日付プロパティ
        public DateTime? ClockIn { get; set; }//出勤時間プロパティ
        public DateTime? ClockOut { get; set; }//退勤時間プロパティ
    }
}
