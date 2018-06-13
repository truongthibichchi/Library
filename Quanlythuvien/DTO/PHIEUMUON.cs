using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DTO
{
    public class PHIEUMUON
    {
        public string MAMUON { get; set; }
        public DateTime NGAYMUON { get; set; }
        public DateTime HANTRA { get; set; }
        public int MATAIKHOAN { get; set; }
        public PHIEUMUON( string mamuon, DateTime ngaymuon, DateTime hantra, int mataikhoan)
        {
            this.MAMUON = mamuon;
            this.NGAYMUON = ngaymuon;
            this.HANTRA = hantra;
            this.MATAIKHOAN = mataikhoan;

        }
    }
}
