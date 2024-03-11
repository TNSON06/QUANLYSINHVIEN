using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Khoa
    {
        private int _MaKhoa;
        private string _TenKhoa;

        public int MaKhoa { get => _MaKhoa; set => _MaKhoa = value; }
        public string TenKhoa { get => _TenKhoa; set => _TenKhoa = value; }
        public Khoa(int MaKhoa, string TenKhoa)
        {
            this.MaKhoa = MaKhoa;
            this.TenKhoa = TenKhoa;
        }
    }
}
