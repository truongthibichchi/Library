using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Quanlythuvien.DAO;


namespace Quanlythuvien.BLL
{
    class PHIEUTRABUS
    {
        private static PHIEUTRABUS _instance;
        public static PHIEUTRABUS Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PHIEUTRABUS();
                }
                return _instance;
            }
        }

        public int _Taophieutra(string mataikhoan, string mamuon, DateTime ngaytra)
        {
            if (PHIEUTRADAO.Instance.Kiemtramaphieutra(mamuon) == 0)
            {
                return PHIEUTRADAO.Instance.Taophieutra(mataikhoan,mamuon,ngaytra) ;
            }
            else return 0;
        }

       
    }
}
