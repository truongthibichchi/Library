using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DTO
{
    public class CHITIETPHIEUMUON
    {
        public string MAMUON { get; set; }
        public int MASACH { get; set; }
        public bool TINHTRANGGIAO { get; set; }

        public CHITIETPHIEUMUON (string mamuon, int masach)
        {
            this.MAMUON = mamuon;
            this.MASACH = masach;
        }
    }
}
