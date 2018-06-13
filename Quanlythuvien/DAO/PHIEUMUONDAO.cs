using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Quanlythuvien.DAO
{
    class PHIEUMUONDAO
    {
        private static PHIEUMUONDAO _instance;
        public static PHIEUMUONDAO Instance
        { 
            get
            {
                if (_instance == null)
                    _instance = new PHIEUMUONDAO();
                return _instance;
            }

        }

        public int Taophieumuon( string mataikhoan)
        {
            string query = "USP_INSERTPHIEUMUON @mataikhoan";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mataikhoan });
        }

        public int Kiemtramaphieumuon(string mataikhoan)
        {
            string query = "SELECT MAMUON FROM PHIEUMUON WHERE CONVERT(DATE,NGAYMUON) = CONVERT(DATE,GETDATE()) AND MATAIKHOAN = @mataikhoan";
            var dt = DataProvider.Instance.ExecuteQuery(query, new object[] { mataikhoan });
            return dt.Rows.Count;

        }

        public int Huyphieumuonsach (string mamuon ,int masach )
        {
            string query = "USP_HUYMUON @mamuon , @masach";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mamuon, masach });
        }
        //Kiểm tra sách có nằm trong phiểu mượn của tài khoản chưa
        public bool Kiemtraphieumuon_sach(string mataikhoan, int masach)
        {
            string query = "USP_CHECKDIEUKIENMUONCHO @mataikhoan , @masach";
            var dt = DataProvider.Instance.ExecuteQuery(query, new object[] { mataikhoan, masach });
            if (dt.Rows.Count > 0) return false;
            else return true;
        }
        
        public DateTime Layhantracuasachhangcho(string masach)
        {
            string query = "USP_LAYHANTRAGANNHAT @masach";
            return (DateTime)DataProvider.Instance.ExecuteScalar(query, new object[] { masach });
        }
        }
}
