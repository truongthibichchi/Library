using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuvien.DTO;
using System.Data;

namespace Quanlythuvien.DAO
{
    class HOADONPHATDAO
    {
        private static HOADONPHATDAO _instance;
        public static HOADONPHATDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HOADONPHATDAO();
                }
                return _instance;
            }
        }

       public int Laphoadonphat(string mamuon, double tienphat)
        {
            string query = "USP_INSERTHOADONPHAT @mamuon , @tienphat";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mamuon, tienphat });
        }

        public DataTable GetthongtinhoadonphatbyMSSV(string MSSV)
       {
           string query = "SELECT * FROM HOADONPHAT HD JOIN PHIEUMUON PM ON HD.MAMUON = PM.MAMUON JOIN SINHVIEN SV ON SV.MATAIKHOAN = PM.MATAIKHOAN"
                           + " WHERE MASINHVIEN = @masosinhvien";
           return DataProvider.Instance.ExecuteQuery(query, new object[] { MSSV });
       }

        public DataTable GetthongtinhoadonphatbyMSSV_tinhtrang(string MSSV, int tinhtrang)
        {
            string query = "SELECT * FROM HOADONPHAT HD JOIN PHIEUMUON PM ON HD.MAMUON = PM.MAMUON JOIN SINHVIEN SV ON SV.MATAIKHOAN = PM.MATAIKHOAN"
                           + " WHERE MASINHVIEN = @masosinhvien AND TINHTRANGNOP = @tinhtrang";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { MSSV, tinhtrang });
        }

        public int Updatetinhtrangnophoadon ( int tinhtrang, string mahoadon)
     
        {
            string query = "UPDATE HOADONPHAT SET TINHTRANGNOP = @tinhtrang WHERE MAHOADON = @mahoadon";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { tinhtrang,mahoadon });
        }

        public int Tongsolanvipham(string mataikhoan)
        {
            string query = "SELECT COUNT(*) FROM HOADONPHAT HD JOIN PHIEUMUON PM ON HD.MAMUON = PM.MAMUON WHERE PM.MATAIKHOAN = @mataikhoan";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { mataikhoan });
        }
    }
}
