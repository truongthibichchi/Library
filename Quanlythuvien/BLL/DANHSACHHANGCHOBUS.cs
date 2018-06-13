using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Quanlythuvien.DAO;


namespace Quanlythuvien.BLL
{
    class DANHSACHHANGCHOBUS
    {
        private static DANHSACHHANGCHOBUS _instance;
        public static DANHSACHHANGCHOBUS Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DANHSACHHANGCHOBUS();
                }

                return _instance;
            }
        }
        public int _Themsachvaohangcho(string mataikhoan, int magaysach)
        {
            return DANHSACHHANGCHODAO.Instance.Themsachvaohangcho(mataikhoan, magaysach);
        }
        public DataTable _Laythongtinsachhangcho(string masach)
        {
            return DANHSACHHANGCHODAO.Instance.Laythongtinsachhangcho(masach);

        }
         public int _Updatehangcho(string mataikhoan, int masach)
        {
            return DANHSACHHANGCHODAO.Instance.Updatehangcho(mataikhoan, masach);
        }
        public int _Updatehangcho_huymuon (int masach, int magaysach)
         {
             return DANHSACHHANGCHODAO.Instance.Updatehangcho_huymuon(masach, magaysach);
         }

        public int _Updatehangcho_trasach(int masach , int magaysach)
        {
            return DANHSACHHANGCHODAO.Instance.Updatehangcho_trasach(masach, magaysach);
        }
    }
}
