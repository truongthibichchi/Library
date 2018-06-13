using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Quanlythuvien.DAO;
using Quanlythuvien.DTO;

namespace Quanlythuvien.BLL
{
  class CHITIETPHIEUMUONBUS
    {
        private static CHITIETPHIEUMUONBUS _instance;
        public static CHITIETPHIEUMUONBUS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CHITIETPHIEUMUONBUS();
                return _instance;
            }
        }

        public int _Taoctphieumuon(int masach, string mataikhoan)
        {
            return CHITIETPHIEUMUONDAO.Instance.TaochitietPM(masach, mataikhoan);
        }
        
        public int _Luutinhtranggiaosach(string mamuon, int masach)
        {
            return CHITIETPHIEUMUONDAO.Instance.Luutinhtranggiaosach(mamuon, masach);
        }
        public bool _Kiemtratinhtranggiaosach(string mamuon, int masach)
        {
            return CHITIETPHIEUMUONDAO.Instance.Kiemtratinhtranggiaosach(mamuon, masach);
        }

    }
}
