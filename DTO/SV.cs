using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SV
    {
        private int _MaSV;
        private string _tenSV;
        private DateTime? _NS;
        private string _QQ;
        private string _HKTT;
        private bool? _GT;
        private float _GPA;
        private int _MaKhoa;

        public int MaSV { get => _MaSV; set => _MaSV = value; }
        public string tenSV { get => _tenSV; set => _tenSV = value; }
        public DateTime? NS { get => _NS; set => _NS = value; }
        public string QQ { get => _QQ; set => _QQ = value; }
        public string HKTT { get => _HKTT; set => _HKTT = value; }
        public bool? GT { get => _GT; set => _GT = value; }
        public float GPA { get => _GPA; set => _GPA = value; }
        public int MaKhoa { get => _MaKhoa; set => _MaKhoa = value; }
        public SV(int MaSV, string tenSV, DateTime? NS, string QQ, string HKTT, bool? GT, float GPA, int MaKhoa)
        {
            this.MaSV = MaSV;
            this.tenSV  = tenSV;
            this.NS = NS;
            this.QQ = QQ;
            this.HKTT = HKTT;
            this.GT = GT;
            this.GPA = GPA;
            this.MaKhoa = MaKhoa;
        }
    }
}
