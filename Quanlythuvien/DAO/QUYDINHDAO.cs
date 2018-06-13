using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DAO
{
    public class QUYDINHDAO
    {

        private static QUYDINHDAO _instance;
        public static QUYDINHDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QUYDINHDAO();
                }
                return _instance;
            }
        }
        public double Laytienphatsach()
        {
            string query = "SELECT TIENPHATSACH FROM QUYDINH";
            return Convert.ToDouble(DataProvider.Instance.ExecuteScalar(query));
        }

        public double Laytienphatquahan()
        {
            string query = "SELECT TIENPHATQUAHAN FROM QUYDINH";
            return Convert.ToDouble(DataProvider.Instance.ExecuteScalar(query));
        }
    }
}
