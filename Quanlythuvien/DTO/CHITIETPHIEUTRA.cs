using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DTO
{
    public class CHITIETPHIEUTRA
    {
        public string MATRA { get; set; }
        public int MASACH { get; set; }
        public int TINHTRANGSACHTRA { get; set; }
        public DateTime NGAYTRA { get; set; }
        public float TIENPHAT { get; set; }

        public CHITIETPHIEUTRA ( string matra, int masach , int tinhtrangsachtra, DateTime ngaytra, float tienphat)
        {
            this.MATRA = matra;
            this.MASACH = masach;
            this.TINHTRANGSACHTRA = tinhtrangsachtra;
            this.NGAYTRA = ngaytra;
            this.TIENPHAT = tienphat;
        }
    }
}
