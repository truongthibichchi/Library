using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuvien.DTO;

namespace Quanlythuvien.DAO
{
    class PHIEUTRADAO
    {
        private static PHIEUTRADAO _instance;
        public static PHIEUTRADAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PHIEUTRADAO();
                }
                return _instance;
            }
        }

        public int Kiemtramaphieutra(string mamuon)
        {
            string query = "SELECT MATRA FROM PHIEUTRA WHERE CONVERT(DATE,NGAYTRA) = CONVERT(DATE,GETDATE()) AND MAMUON = @mamuon";
            var dt = DataProvider.Instance.ExecuteQuery(query, new object[] { mamuon });
            return dt.Rows.Count;

        }

        public int Taophieutra(string mataikhoan, string mamuon, DateTime ngaytra)
        {
            string query = "USP_INSERTPHIEUTRA @mataikhoan , @mamuon , @ngaytra";
            return DataProvider.Instance.ExecuteNonQuery(query, new object [] {mataikhoan, mamuon, ngaytra});
        }

        

    }
}
