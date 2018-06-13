using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Quanlythuvien.DTO;

namespace Quanlythuvien.DAO
{
    class DANHSACHHANGCHODAO
    {
        private static DANHSACHHANGCHODAO _instance;
        public static DANHSACHHANGCHODAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DANHSACHHANGCHODAO();
                }
                return _instance;
            }
        }

        public int Themsachvaohangcho(string mataikhoan, int magaysach)
        {
            string query = "USP_INSERTHANGCHO @mataikhoan , @magaysach";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mataikhoan, magaysach });
        }
        public DataTable Laythongtinsachhangcho(string mataikhoan)
        {
            string query = "USP_THONGTINSACHHANGCHO @mataikhoan";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { mataikhoan });
        }

        public int Updatehangcho(string mataikhoan, int masach)
        {
            string query = "USP_Updatehangcho @mataikhoan , @masach";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mataikhoan, masach });
        }
        //Update lại hàng chờ khi một cuốn sách có trong hàng chờ được hủy mượn
        public int Updatehangcho_huymuon (int masach, int magaysach)
        {
            string query = "USP_UPDATEHANGCHO_HUYMUON @masach , @magaysach";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { masach, magaysach });
        }

        public int Updatehangcho_trasach(int masach , int magaysach)
        {
            string query = "USP_UPDATETRASACH_HANGCHO @masach , @magaysach";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { masach, magaysach });
        }
    }
}
