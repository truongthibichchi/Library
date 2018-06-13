using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuvien.DAO;

namespace Quanlythuvien.BLL
{
    class QUYDINHBUS
    {
        private static QUYDINHBUS _instance;
        public static QUYDINHBUS Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new QUYDINHBUS();
                return _instance;
            }
        }

        public double _Laytienphatsach()
        {
            return QUYDINHDAO.Instance.Laytienphatsach();
        }
        
        public double _Laytienphatquahan()
        {
            return QUYDINHDAO.Instance.Laytienphatquahan();
        }
    }
}
