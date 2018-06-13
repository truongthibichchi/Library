using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DTO
{
    public class PHIEUTRA
    {
        public string MATRA { get; set; }
        public DateTime NGAYTRA { get; set; }
        public string MAMUON { get; set; }

        public PHIEUTRA(string matra, DateTime ngaytra, string mamuon)
        {
            this.MATRA = matra;
            this.MAMUON = mamuon;
            this.NGAYTRA = ngaytra;
        }

    }
}
