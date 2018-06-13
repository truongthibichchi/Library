using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Quanlythuvien.DTO;

namespace Quanlythuvien.DAO
{
    class SINHVIENDAO
    {
        private static SINHVIENDAO _instance;
        public static  SINHVIENDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SINHVIENDAO();
                }
                return _instance;
            }
        }
        public DataTable LaythongtinSVbymaTK(string mataikhoan)
        {
            var dt = new DataTable();
            string query = "USP_THONGTINSINHVIEN @mataikhoan";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { mataikhoan });
            return dt;
        }
        public int UpdatethongtinSV(string mataikhoan, string diachi, string email, int sdt)
        {
            string query = "UPDATESINHVIEN @mataikhoan , @diachi , @email , @SDT";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mataikhoan, diachi, email, sdt });
        }

        public bool Kiemtramasosinhvien(string masinhvien)
        {
            string query = "SELECT * FROM SINHVIEN WHERE MASINHVIEN = @masinhvien";
            var dt = DataProvider.Instance.ExecuteQuery(query, new object[] { masinhvien });
            if (dt.Rows.Count > 0) return true;
            else return false;
        }

        public DataTable Laythongtinsinhvientheokhoa(string khoa)
        {
            string query = "SELECT * FROM SINHVIEN WHERE KHOA = @khoa ORDER BY HOTEN ASC";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { khoa });
        }

        public int UpdatethongtinSV_NV(string hoten, string lop, string gioitinh, DateTime ngaysinh, string khoa, string email, int sdt , int mssv , string diachi)
        {
            string query = "UPDATESINHVIEN_NV @hoten , @lop , @gioitinh , @ngaysinh , @khoa , @email ,  @sdt , @masinhvien , @diachi";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { hoten, lop, gioitinh, ngaysinh, khoa, email, sdt,mssv,diachi });
        }                                     
        
        public DataTable Hienthitatcasinhvien()
        {
            string query = "SELECT * FROM SINHVIEN";
            return DataProvider.Instance.ExecuteQuery(query);
        }         
    
        public int DeleteSinhvien(string masinhvien)
        {
            string query = "DELETE FROM TAIKHOAN WHERE MATAIKHOAN = @masinhvien";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { masinhvien });
        }

        public int Addsinhvien(string masinhvien, string hoten, string lop, string khoa, string giotinh, DateTime ngaysinh, string email, int sdt,string diachi)
        {
            string query = "USP_INSERTSINHVIEN @hoten , @lop , @gioitinh , @ngaysinh , @khoa , @email , @sdt , @masinhvien , @diachi";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { hoten, lop, giotinh, ngaysinh, khoa, email, sdt, masinhvien, diachi });
        }

        public DataTable TimkiemsinhvienbyMSSV(string MSSV)
        {
            string query = "SELECT * FROM SINHVIEN WHERE MASINHVIEN = @MSSV";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { MSSV });

        }
    }                                         
}                                              
                                             