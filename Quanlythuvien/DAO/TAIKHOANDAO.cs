using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Quanlythuvien.DAO
{
    class TAIKHOANDAO
    {
        private static TAIKHOANDAO _instance;
        public static TAIKHOANDAO Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new TAIKHOANDAO();
                }
                return _instance;
            }
        }
         public bool Kiemtrataikhoan(string mataikhoan, string matkhau)
        {
            var dt = new DataTable();
            string query = "USP_DANGNHAP @taikhoan , @matkhau";
            dt = DataProvider.Instance.ExecuteQuery(query,new object [] {mataikhoan,matkhau} );
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public object Kiemtraloaitaikhoan(string mataikhoan)
         {
             var dt = new DataTable();
             string query = "SELECT MALOAI FROM TAIKHOAN WHERE MATAIKHOAN = @mataikhoan";
             dt = DataProvider.Instance.ExecuteQuery(query, new object[] { mataikhoan});
             var result = dt.Rows[0][0];
             return result;
        }
        public string GetmatkhaubyID(string mataikhoan)
        {
            string query = "SELECT MATKHAU FROM TAIKHOAN WHERE MATAIKHOAN = @mataikhoan";
            return (string)DataProvider.Instance.ExecuteScalar(query, new object[] {mataikhoan});
        }
        public int Doimatkhau(string mataikhoan, string matkhaucu, string matkhaumoi)
        {
            int result;
            string query = "USP_UPDATEMATKHAU @mataikhoan , @matkhaucu , @matkhaumoi";
            result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {mataikhoan,matkhaucu,matkhaumoi});
            return result;
        }
       
        //Kiểm tra tài khoản có đủ điều kiện để thêm sách vào hàng chờ/mượn không?
        public bool Kiemtradieukienmuon_cho(string mataikhoan)
        {
            string query1 = "SELECT* FROM DANHSACHHANGCHO WHERE MATAIKHOAN = @mataikhoan ";
            string query2 = "USP_SV_SACHDANGMUON @masinhvien";
            var dt1 = DataProvider.Instance.ExecuteQuery(query1, new object[] { mataikhoan });
            var dt2 = DataProvider.Instance.ExecuteQuery(query2, new object[] { mataikhoan });
            if (dt1.Rows.Count + dt2.Rows.Count == 4) return false;
            else return true;
        }
        // Kiểm tra có tồn tại sách cùng loại nằm trong sách đang mượn hay không?
        public bool Kiemtrasachtontaitrongphieumuon(string mataikhoan, string maGaySach)
        {
            string query2 = "USP_SV_SACHDANGMUON_MAGAYSACH @mataikhoan , @magaysach ";
            var result = DataProvider.Instance.ExecuteQuery(query2, new object[] { mataikhoan, maGaySach });
            if (result.Rows.Count == 0) return true;
            else return false;
        }
    }
}
