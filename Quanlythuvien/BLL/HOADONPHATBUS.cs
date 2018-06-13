using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuvien.DAO;
using System.Data;

namespace Quanlythuvien.BLL
{
    class HOADONPHATBUS
    {
        private static HOADONPHATBUS _instance;
        public static HOADONPHATBUS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HOADONPHATBUS();
                return _instance;
            }
        }

        public int _Laphoadonphat(string mamuon, double tienphat)
        {
            return HOADONPHATDAO.Instance.Laphoadonphat(mamuon,tienphat);
        }

        public DataTable _GetthongtinhoadonphatbyMSSV(string MSSV)
        {
            return HOADONPHATDAO.Instance.GetthongtinhoadonphatbyMSSV(MSSV);
        }

         public DataTable _GetthongtinhoadonphatbyMSSV_tinhtrang(string MSSV, int tinhtrang)
        {
            return HOADONPHATDAO.Instance.GetthongtinhoadonphatbyMSSV_tinhtrang(MSSV, tinhtrang);
        }

        public int _Updatetinhtrangnophoadon (int tinhtrang, string mahoadon)
         {
             return HOADONPHATDAO.Instance.Updatetinhtrangnophoadon(tinhtrang,mahoadon);
         }
        public int _Tongsolanvipham(string mataikhoan)
        {
            return HOADONPHATDAO.Instance.Tongsolanvipham(mataikhoan);
        }
    }
}
