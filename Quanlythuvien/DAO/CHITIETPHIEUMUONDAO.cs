using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DAO
{
    class CHITIETPHIEUMUONDAO
    {
        private static CHITIETPHIEUMUONDAO _instance;
        public static CHITIETPHIEUMUONDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CHITIETPHIEUMUONDAO();
                return _instance;
            }
        }

        public int TaochitietPM(int masach, string mataikhoan)
        {
            string query = "USP_INSERTCTPHIEUMUON @masach , @mataikhoan";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { masach, mataikhoan });
        }

        public int Luutinhtranggiaosach(string mamuon, int masach)
        {
            string query = "UPDATE CHITIETPHIEUMUON SET TINHTRANGGIAO = 1 WHERE MAMUON = @mamuon AND MASACH = @masach";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mamuon, masach });
        }
        
        public bool Kiemtratinhtranggiaosach(string mamuon, int masach)
        {
            string query = "SELECT TINHTRANGGIAO FROM CHITIETPHIEUMUON WHERE MAMUON = @mamuon AND MASACH = @masach";
            return (bool)DataProvider.Instance.ExecuteScalar(query, new object[] { mamuon , masach });
            
        }
    }
}
