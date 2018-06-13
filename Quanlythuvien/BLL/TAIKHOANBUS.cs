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
    class TAIKHOANBUS
    {
        private static TAIKHOANBUS _instance;
        public static TAIKHOANBUS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TAIKHOANBUS();
                return _instance;
            }
        }
        public bool _Kiemtrataikhoan(string mataikhoan, string matkhau)
        {
            return TAIKHOANDAO.Instance.Kiemtrataikhoan(mataikhoan, matkhau);
        }
        public object _Kiemtraloaitaikhoan(string mataikhoan)
        {
            return TAIKHOANDAO.Instance.Kiemtraloaitaikhoan(mataikhoan);
        }
        public int _Doimatkhau(string mataikhoan, string mathaucu,string matkhaumoi)
        {
            return TAIKHOANDAO.Instance.Doimatkhau(mataikhoan, mathaucu, matkhaumoi);
        }

        public bool Kiemtradieukienmuon_cho(string mataikhoan)
        {
            return TAIKHOANDAO.Instance.Kiemtradieukienmuon_cho(mataikhoan);
        }
        
        // Kiểm tra có tồn tại sách cùng loại nằm trong sách đang mượn hay không?
        public bool Kiemtrasachtontaitrongphieumuon(string mataikhoan, string maGaySach)
        {
            return TAIKHOANDAO.Instance.Kiemtrasachtontaitrongphieumuon(mataikhoan, maGaySach);
        }

    }
}
