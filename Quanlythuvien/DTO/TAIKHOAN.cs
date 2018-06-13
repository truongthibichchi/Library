using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DTO
{
   public class TAIKHOAN
    {
       public int MATAIKHOAN { get; set; }
       public string MATKHAU { get; set; }
       public int MALOAI { get; set; }
       public TAIKHOAN(int mataikhoan, string matkhau, int maloai)
       {
           this.MATAIKHOAN = mataikhoan;
           this.MATKHAU = matkhau;
           this.MALOAI = maloai;
       }

    }
}
