using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DTO
{
    public class CUONSACH
    {
        public int MASACH { get; set; }
        public DateTime NGAYNHAP { get; set; }
        public int TINHTRANG { get; set; }
        public int VITRI { get; set; }
        public int MAGAYSACH { get; set; }
        public CUONSACH (int masach, DateTime ngaynhap, int tinhtrang, int vitri, int magaysach)
        {
            this.MASACH = masach;
            this.NGAYNHAP = ngaynhap;            
            this.TINHTRANG = tinhtrang;
            this.VITRI = vitri;
            this.MAGAYSACH = magaysach;
        }

    }
}
