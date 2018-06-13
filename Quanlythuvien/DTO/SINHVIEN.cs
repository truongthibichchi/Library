using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DTO
{
    public class SINHVIEN
    {
        public int MASINHVIEN { get; set; }
        public string HOTEN { get; set; }
        public string DIACHI { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string GIOITINH { get; set; }
        public string KHOA { get; set; }
        public string LOP { get; set; }
        public int SDT { get; set; }
        public string EMAIL { get; set;}
        public int MATAIKHOAN { get; set; }
        public SINHVIEN (int masinhvien, string hoten,string diachi, DateTime ngaysinh, string gioitinh, string khoa,string lop, int sdt,string email, int mataikhoan)
        {
            this.MASINHVIEN = masinhvien;
            this.HOTEN = hoten;
            this.DIACHI = diachi;
            this.NGAYSINH = ngaysinh;
            this.GIOITINH = gioitinh;
            this.KHOA = khoa;
            this.LOP = lop;
            this.SDT = sdt;
            this.EMAIL = email;
            this.MATAIKHOAN = mataikhoan;
        }
    }
}
