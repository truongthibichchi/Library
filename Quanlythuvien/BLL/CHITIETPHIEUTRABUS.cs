using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuvien.DAO;
using Quanlythuvien.DTO;

namespace Quanlythuvien.BLL
{
    class CHITIETPHIEUTRABUS
    {
        private static CHITIETPHIEUTRABUS _instance;
        public static CHITIETPHIEUTRABUS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CHITIETPHIEUTRABUS();
                return _instance;
            }
        }

        public int _Taoctphieutra(string mamuon, int masach, int hientrangsach, double tienphat)
        {
            return CHITIETPHIEUTRADAO.Instance.Taoctphieutra(mamuon, masach, hientrangsach, tienphat);
        }
    }
}
