using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Quanlythuvien.DTO;
using Quanlythuvien.DAO;

namespace Quanlythuvien.BLL
{
    class SINHVIENBUS
    {
        private static SINHVIENBUS _instance;
        public static SINHVIENBUS Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SINHVIENBUS();
                }
                return _instance;
            }
        }
        public DataTable _LaythongtinSVbymaTK(string mataikhoan)
        {
            return SINHVIENDAO.Instance.LaythongtinSVbymaTK(mataikhoan);
        }

         public int _UpdatethongtinSV(string mataikhoan, string diachi, string email, int sdt)
        {
            return SINHVIENDAO.Instance.UpdatethongtinSV(mataikhoan, diachi, email, sdt);
        }

        public bool _Kiemtramasosinhvien(string masinhvien)
        {
            return SINHVIENDAO.Instance.Kiemtramasosinhvien(masinhvien);
        }

         public DataTable _Laythongtinsinhvientheokhoa(string khoa)
        {
            return SINHVIENDAO.Instance.Laythongtinsinhvientheokhoa(khoa);
        }
        public int _UpdatethongtinSV_NV(string hoten, string lop, string gioitinh, DateTime ngaysinh, string khoa, string email, int sdt, int mssv, string diachi)
         {
             return SINHVIENDAO.Instance.UpdatethongtinSV_NV(hoten, lop, gioitinh, ngaysinh, khoa, email, sdt ,mssv,diachi);
         }
        public DataTable _Hienthitatcasinhvien()
        {
            return SINHVIENDAO.Instance.Hienthitatcasinhvien();
        }
        
        public int _DeleteSinhvien(string masinhvien)
        {
            return SINHVIENDAO.Instance.DeleteSinhvien(masinhvien);
        }

        public int _Addsinhvien(string masinhvien, string hoten, string lop, string khoa, string giotinh, DateTime ngaysinh, string email, int sdt,string diachi)
        {
            return SINHVIENDAO.Instance.Addsinhvien(masinhvien, hoten, lop, khoa, giotinh, ngaysinh, email, sdt, diachi);
        }
        public DataTable _TimkiemsinhvienbyMSSV(string MSSV)
        {
            return SINHVIENDAO.Instance.TimkiemsinhvienbyMSSV(MSSV);
        }
    }
}
