using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobRECO.Models
{
    public class User
    {
        public int Id { get; set; }//IDプロパティ
        public string Username { get; set; } = "";//ユーザー名プロパティ
        public string PasswordHash { get; set; } = "";//パスワードハッシュプロパティ

    }
}
