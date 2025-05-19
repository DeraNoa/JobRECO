using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobRECO.Models
{
    public class WorkLog
    {

        public int Id { get; set; }//IDプロパティ

        // ---- 外部キー ----
        public int AttendanceId { get; set; }//勤怠IDプロパティ
        public Attendance Attendance { get; set; } = null!;//勤怠プロパティ

        // ---- 工数 ----
        [Required, MaxLength(100)]
        public string ProjectName { get; set; } = string.Empty;//プロジェクト名プロパティ

        [MaxLength(200)]
        public string? Description { get; set; }//説明プロパティ

        // decimal(5,2)：最大 999.99 時間想定
        [Column(TypeName = "decimal(5,2)")]
        public decimal Hours { get; set; }//工数プロパティ   
    }
}
