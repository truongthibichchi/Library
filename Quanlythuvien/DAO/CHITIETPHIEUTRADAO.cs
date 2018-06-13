using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuvien.DTO;

namespace Quanlythuvien.DAO
{
    class CHITIETPHIEUTRADAO
    {
        private static CHITIETPHIEUTRADAO _instance;
        public static CHITIETPHIEUTRADAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CHITIETPHIEUTRADAO();
                return _instance;
            }
        }

        public int Taoctphieutra(string mamuon, int masach, int hientrangsach, double tienphat)
        {
            string query = "USP_INSERTCTPHIEUTRA @mamuon , @masach , @hientrangsach  , @tienphat";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { mamuon, masach, hientrangsach, tienphat });
        }
        
    }
}
