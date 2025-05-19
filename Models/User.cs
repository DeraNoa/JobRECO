using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobRECO.Models
{
    public class User
    {
        [Key]//主キー属性
        public int Id { get; set; }//IDプロパティ

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;//ユーザー名プロパティ

        [Required]
        public string PasswordHash { get; set; } = string.Empty;//パスワードハッシュプロパティ

        [MaxLength(100)]
        public string? DisplayName { get; set; }//ディスプレイネームプロパティ


        // ナビゲーションプロパティ
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
