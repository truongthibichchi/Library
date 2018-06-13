using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlythuvien.Forms
{
    public partial class UC_SV_Qui_định : UserControl
    {
        private frmManhinhchinhSinhVien a;

        public UC_SV_Qui_định(frmManhinhchinhSinhVien a)
        {
            InitializeComponent();
            this.a = a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            a.pnlManHinhChinh.BringToFront();
        }
    }
}
