using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuvien.DAO;
using Quanlythuvien.DTO;
using System.Data;

namespace Quanlythuvien.BLL
{
    class PHIEUMUONBUS
    {
        private static PHIEUMUONBUS _instance;
        public static PHIEUMUONBUS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PHIEUMUONBUS();
                return _instance;
            }
        }

        public int _Taophieumuon(string mataikhoan)
        {
            if (PHIEUMUONDAO.Instance.Kiemtramaphieumuon(mataikhoan) == 0)
            {
                return PHIEUMUONDAO.Instance.Taophieumuon(mataikhoan);
            }
            else return 0;
        }
        public int _Huyphieumuonsach (string mamuon ,int masach )
        {
            return PHIEUMUONDAO.Instance.Huyphieumuonsach(mamuon, masach);
        }
        public bool _Kiemtraphieumuon_sach(string mataikhoan, int masach)
        {
            return PHIEUMUONDAO.Instance.Kiemtraphieumuon_sach(mataikhoan, masach);
        }
        public DateTime _Layhantracuasachhangcho(string masach)
        {
            return PHIEUMUONDAO.Instance.Layhantracuasachhangcho(masach);
        }
        
    }
}
