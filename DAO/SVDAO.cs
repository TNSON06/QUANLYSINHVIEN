using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SVDAO
    {
        private static SVDAO instance;

        public static SVDAO Instance {
            get
            {
                if(instance == null)
                    instance = new SVDAO();
                return instance;
            } 
            private set => instance = value; }
        private SVDAO() { }
       
        //ham tra ve list doi tuong lop sh de do len cbb
        public List<Khoa> GetAllKhoa() {
            List<Khoa> listKhoa = new List<Khoa>();
            string query = "select * from Khoa";
           foreach(DataRow row in DataProvider.Instance.GetRecords(query).Rows)
            {
                listKhoa.Add(GetKhoa(row));
            }
           return listKhoa;
        }
        public Khoa GetKhoa(DataRow i)
        {
            return new Khoa
            (
                 (int)i["MaKhoa"],
                 i["TenKhoa"].ToString()
            );
        }
        public List<SV> GetAllSV()
        {
            List<SV> listSV = new List<SV>();
            string query = "select * from SV";
            foreach(DataRow row in DataProvider.Instance.GetRecords(query).Rows)
            {
               listSV.Add(GetSV(row));
            }
            return listSV;
        }
        public List<string> GetNameColumn()
        {
            List<string> listCL = new List<string>();
            string query = "select top 0 * from SV";
            foreach (DataColumn col in DataProvider.Instance.GetRecords(query).Columns)
            {
                string columnName = col.ColumnName;
                listCL.Add(columnName);
            }
            return listCL;
        }
        public List<SV> GetSVSearch(string tenSV)
        {
            List<SV> listSV = new List<SV>();
            string query = "select * from SV where TenSV ='"+tenSV+"'";
            foreach (DataRow row in DataProvider.Instance.GetRecords(query).Rows)
            {
                listSV.Add(GetSV(row));
            }
            return listSV;
        }
       
        public SV GetSV(DataRow i)
        {
            int maSV = i["MaSV"] != DBNull.Value ? (int)i["MaSV"] : 0;
            string tenSV = i["TenSV"] != DBNull.Value ? i["TenSV"].ToString() : string.Empty;
            DateTime? ngaySinh = i["NS"] != DBNull.Value ? (DateTime?)i["NS"] : null;
            string queQuan = i["QQ"] != DBNull.Value ? i["QQ"].ToString() : string.Empty;
            string hoKhauThuongTru = i["HKTT"] != DBNull.Value ? i["HKTT"].ToString() : string.Empty;
            bool? gioiTinh = i["GT"] != DBNull.Value ? (bool?)i["GT"] : null;
            float gpa = 0.0f;

            if (i["GPA"] != DBNull.Value)
            {
                // Kiểm tra kiểu dữ liệu của cột "GPA"
                if (i["GPA"] is float || i["GPA"] is double || i["GPA"] is int)
                {
                    gpa = Convert.ToSingle(i["GPA"]);
                }
              
            }
            int maKhoa = i["MaKhoa"] != DBNull.Value ? (int)i["MaKhoa"] : 0;
           


            return new SV(maSV, tenSV, ngaySinh, queQuan, hoKhauThuongTru, gioiTinh, gpa, maKhoa);

        }
        //add SV
        public void UpdateSV(SV s)
        {
            string query = "UPDATE SV SET TenSV='" + s.tenSV + "', NS='" + s.NS + "', QQ='" + s.QQ + "', HKTT='" + s.HKTT + "', GT='" + s.GT + "', GPA=" + s.GPA + ", MaKhoa=" + s.MaKhoa + " WHERE MaSV=" + s.MaSV;
            DataProvider.Instance.ExecuteDB(query);
            Console.WriteLine("Ham nay da duoc goi");
            Console.WriteLine(DataProvider.Instance.ExecuteDB(query).ToString());
        }
        public void DeleteSV(string mssv)
        {
            string query = "DELETE FROM SV WHERE MaSV = " + mssv;
            DataProvider.Instance.ExecuteDB(query);
            
           
        }
        public void AddSV(SV s)
        {
            string query = "INSERT INTO SV(MaSV,TenSV,NS,QQ,HKTT,GT,GPA,MaKhoa) VALUES("+s.MaSV+",'"+s.tenSV+"','"+s.NS+"','"+s.QQ+"','"+s.HKTT+"','"+s.GT+"',"+s.GPA+","+s.MaKhoa+")";
            DataProvider.Instance.ExecuteDB(query);
          
        }
    }
}
