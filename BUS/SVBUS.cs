using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class SVBUS
    {
        private static SVBUS instance;

        public static SVBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new SVBUS();
                return instance;
            }

        }
        private SVBUS() { }
        
        //cho khoa
        public List<CBBItem> GetListCBB()
        {
            List<CBBItem> listCBB = new List<CBBItem>();
            foreach (Khoa khoa in SVDAO.Instance.GetAllKhoa())
            {
                listCBB.Add(new CBBItem
                {
                    Text = khoa.TenKhoa,
                    value = khoa.MaKhoa
                }) ;
            }
            return listCBB;
        }
        public List<CBBItem> GetListCBBQQ()
        {
            List<CBBItem> listCBBQQ = new List<CBBItem>();
            foreach(SV sv in SVDAO.Instance.GetAllSV())
            {
                listCBBQQ.Add(new CBBItem
                {
                    Text = sv.QQ,
                    value = sv.MaSV
                });
            }
            return listCBBQQ;
        }
        public List<string> GetListCBBSort()
        {
            List<string> listSort = new List<string>();
            foreach(string cln in SVDAO.Instance.GetNameColumn())
            {
                listSort.Add(cln);
            }
            return listSort;
            
        }
        public List<SV> GetListSV(string tenSV)
        {
            List<SV> listSV = new List<SV>();
            if( tenSV == null)
            {
                listSV = SVDAO.Instance.GetAllSV();
            }
            if( tenSV != null)
            {
                listSV = SVDAO.Instance.GetSVSearch(tenSV);
            }
            return listSV;
        }
        public void ExcuteDB(SV s)
        {
            if (SVBUS.Instance.GetSVByMSSV(s.MaSV.ToString()) != null && s.MaSV == SVBUS.Instance.GetSVByMSSV(s.MaSV.ToString()).MaSV)
            {
                SVDAO.Instance.UpdateSV(s);
            }
            else 
            {
                SVDAO.Instance.AddSV(s);
               
            }
        }
        public void DelSV(List<string> LMSSV)
        {
            foreach (string mssv in LMSSV)
            {
                SVDAO.Instance.DeleteSV(mssv);
                Console.WriteLine(mssv);
            }
        }
        public SV GetSVByMSSV(string m)
        {
            SV s = null;
            foreach(SV sv in SVDAO.Instance.GetAllSV())
            {
                if (sv.MaSV.ToString()==m)
                {
                    s = sv; ;
                    break;
                }

            }
            return s;
        }
    }

}
