using JobRECO.Data;
using JobRECO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JobRECO.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {

        public DateTime Today => DateTime.Today;

        private Attendance? _attendance;
        public Attendance? Attendance
        {
            get => _attendance;
            set { _attendance = value; OnPropertyChanged(); }

        }
        public ObservableCollection<WorkLog> WorkLogs { get; set; } = new();

        public ICommand ClockInCommand { get; }
        public ICommand ClockOutCommand { get; }
        public ICommand AddWorkLogCommand { get; }

        public MainViewModel()
        {
            ClockInCommand = new RelayCommand(ClockIn);
            ClockOutCommand = new RelayCommand(ClockOut);
            AddWorkLogCommand = new RelayCommand(AddWorkLog);
            LoadAttendance();
        }

        private void LoadAttendance()
        {
            using var db = new AppDbContext();
            //var user = db.Users.First(); // 仮に最初のユーザー
            var user = db.Users.FirstOrDefault();
            if (user == null)
            {
                // 初回起動など → ダミーユーザーを作る
                user = new User
                {
                    Username = "admin",
                    PasswordHash = "dummy", // 本番ではハッシュを使う
                    DisplayName = "管理者"
                };
                db.Users.Add(user);
                db.SaveChanges();
            }

            Attendance = db.Attendances
                           .Include(a => a.WorkLogs)
                           .FirstOrDefault(a => a.UserId == user.Id && a.WorkDate == Today);
            if (Attendance != null)
                WorkLogs = new ObservableCollection<WorkLog>(Attendance.WorkLogs);
        }

        private void ClockIn()
        {
            using var db = new AppDbContext();
            var user = db.Users.First();
            Attendance = new Attendance
            {
                UserId = user.Id,
                WorkDate = Today,
                ClockIn = DateTime.Now
            };
            db.Attendances.Add(Attendance);
            db.SaveChanges();
            OnPropertyChanged(nameof(Attendance));
        }

        private void ClockOut()
        {
            if (Attendance == null) return;
            using var db = new AppDbContext();
            var att = db.Attendances.Find(Attendance.Id);
            if (att != null)
            {
                att.ClockOut = DateTime.Now;
                db.SaveChanges();
                Attendance.ClockOut = att.ClockOut;
                OnPropertyChanged(nameof(Attendance));
            }
        }

        private void AddWorkLog()
        {
            if (Attendance == null) return;
            var log = new WorkLog
            {
                AttendanceId = Attendance.Id,
                ProjectName = "開発A", // 仮
                Hours = 1.5m,
                Description = "設計作業"
            };
            using var db = new AppDbContext();
            db.WorkLogs.Add(log);
            db.SaveChanges();
            WorkLogs.Add(log);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));




    }
}
