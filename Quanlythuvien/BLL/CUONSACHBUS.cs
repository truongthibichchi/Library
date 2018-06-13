using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Quanlythuvien.DAO;


namespace Quanlythuvien.BLL
{
    class CUONSACHBUS
    {
        private static CUONSACHBUS _instance;
        public static CUONSACHBUS Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CUONSACHBUS();
                }
                return _instance;
            }
        }

        public DataTable _getInfoOfListId(List<int> list)
        {
            return CUONSACHDAO.Instance.getInfoOfListId(list);
        }

        public DataTable _ArrayOfId(string maGaySach)
        {
            return CUONSACHDAO.Instance.ArrayOfId(maGaySach);
        }

        public DataTable _ArrayOfArea(string maGaySach)
        {
            return CUONSACHDAO.Instance.ArrayOfArea(maGaySach);
        }

        public DataTable _ArrayOfStatus(string maGaySach)
        {
            return CUONSACHDAO.Instance.ArrayOfStatus(maGaySach);
        }

        public int _LayMaSachCoTheMuon(string maGaySach)
        {
            return CUONSACHDAO.Instance.LayMaSachCoTheMuon(maGaySach);

        }
        public int _LayMaSachNamTrongKhoMuon(string maGaySach)
        {
            return CUONSACHDAO.Instance.LayMaSachNamTrongKhoMuon(maGaySach);

        }

        public void _NhapCuonSach(string maGaySach, int soLuong, int viTri)
        {
            CUONSACHDAO.Instance.NhapCuonSach(maGaySach, soLuong, viTri);
        }

        public DataTable GetSachbyChude(string machude)
        {
            return CUONSACHDAO.Instance.GetSachbymachude(machude);
        }
  
        public DataTable _Getsachbytacgia(string tacgia)
        {
            return CUONSACHDAO.Instance.GetSachbyTacgia(tacgia);
        }
        public DataTable _Getsachbymasch(string masach)
        {
            return CUONSACHDAO.Instance.GetSachbymasach(masach);
        }      

        public DataTable _Timkiemtheotensach(string tensach)
        {
            return CUONSACHDAO.Instance.Timkiemtheotensach(tensach);

        }
        public int _Updatetinhtrangsachmuon(int masach)
        {
            return CUONSACHDAO.Instance.Updatetinhtrangsachmuon(masach);
        }

        public DataTable _TimkiemsachSVdangmuon(string mataikhoan)
        {
            return CUONSACHDAO.Instance.TimkiemsachSVdangmuon(mataikhoan);
        }
        
        public int _DeleteSach(int masach)
        {
            return CUONSACHDAO.Instance.DeleteSach(masach);
        }

        public DataTable _Kiemtrathongtinsach (string tensach)
        {
            return CUONSACHDAO.Instance.Kiemtrathongtinsach(tensach);
        }
        public int _Insertsach(string magay, string nhande, string tacgia, string tomtat, string machude, string tenchude, int sotrang, int giatien, string nhaxuatban, int namxuatban, int duocmuon)
        {
            return CUONSACHDAO.Instance.Insertsach(magay, nhande, tacgia, tomtat, machude, tenchude, sotrang, giatien, nhaxuatban, namxuatban, duocmuon);
        }
        public int _Updatesach(int masach, int tinhtrang, int vitri)
        {
            return CUONSACHDAO.Instance.Updatesach(masach, tinhtrang, vitri);
        }
        public int _Getmasachmoinhat()
        {
            return CUONSACHDAO.Instance.Getmasachmoinhat();
        }

        public DataTable _Getallsach()
        {
            return CUONSACHDAO.Instance.Getallsach();
        }

        public int _Laymagaysachbangmasach(int masach)
        {
            return CUONSACHDAO.Instance.Laymagaysachbangmasach(masach);
        }
    }
}
