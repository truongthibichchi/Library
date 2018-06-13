using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DTO
{
    public class DANHSACHHANGCHO
    {
        public string MATAIKHOAN { get; set; }
        public int MAGAYSACH { get; set; }
        public DateTime NGAYDK { get; set; }

        public DANHSACHHANGCHO (string mataikhoan, int magaysach, DateTime ngaydk)
        {
            this.MATAIKHOAN = mataikhoan;
            this.MAGAYSACH = magaysach;
            this.NGAYDK = ngaydk;
        }
    }
}
