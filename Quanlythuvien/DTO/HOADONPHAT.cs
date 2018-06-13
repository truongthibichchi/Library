using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DTO
{
    public class HOADONPHAT
    {
        public string MAHOADON { get; set; }
        public string MATRA { get; set; }
        public float TONGTIENPHAT { get; set; }
     
        
        public HOADONPHAT(string mahoadon, string matra, float tienphat)
        {
            this.MAHOADON = mahoadon;
            this.MATRA = matra;
            this.TONGTIENPHAT = tienphat;
        }
    }
}
