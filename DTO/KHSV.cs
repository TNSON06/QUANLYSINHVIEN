using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KHSV
    {
        private int _MaSV;
        private int _MaHocPhan;

        public int MaSV { get => _MaSV; set => _MaSV = value; }
        public int MaHocPhan { get => _MaHocPhan; set => _MaHocPhan = value; }
        public KHSV(int MaSV, int MaHocPhan)
        {
            this.MaSV = MaSV;
            this.MaHocPhan = MaHocPhan;
        }
    }
}
