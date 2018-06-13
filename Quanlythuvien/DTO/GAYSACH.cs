using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlythuvien.DTO
{
    public class GAYSACH
    {
        public string MAGAYSACH { get; set; }
        public string NHANDE { get; set; }
        public string TACGIA { get; set; }
        public string CHUDE { get; set; }
        public string NHAXUATBAN { get; set; }
        public string TOMTAT { get; set; }
        public int NAMXUATBAN { get; set; }
        public int SOTRANG { get; set; }
        public double GIATIEN { get; set; }

        public GAYSACH (string magaysach, string nhande, string tacgia,string chude, string nhaxuatban, string tomtat, int namxuatban, int sotrang, double giatien)
        {
            this.MAGAYSACH = magaysach;
            this.NHANDE = nhande;
            this.TACGIA = tacgia;
            this.TOMTAT = tomtat;
            this.NHAXUATBAN = nhaxuatban;
            this.SOTRANG = sotrang;
            this.NAMXUATBAN = namxuatban;
            this.GIATIEN = giatien;
            this.CHUDE = chude;
            
        }

    }
}
