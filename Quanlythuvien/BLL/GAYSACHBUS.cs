using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuvien.DAO;
using System.Data;

namespace Quanlythuvien.BLL
{
    class GAYSACHBUS
    {
        private static GAYSACHBUS _instance;
        public static GAYSACHBUS Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GAYSACHBUS();
                }
                return _instance;
            }
        }

        public int _Taogaysach()
        {
            return GAYSACHDAO.Instance.Taogaysach();
        }

        public DataTable _ArrayOfBookName()
        {
            return GAYSACHDAO.Instance.ArrayOfBookName();
        }

        public int _Insertsach(string magay, string nhande, string tacgia, string tomtat, string tenchude, string sotrang, string giatien, string nhaxuatban, string namxuatban)
        {
            return GAYSACHDAO.Instance.InsertSach(magay, nhande, tacgia, tomtat, tenchude, sotrang, giatien, nhaxuatban, namxuatban);
        }

        public int _Updatesach(string magay, string nhande, string tacgia, string tomtat, string tenchude, string sotrang, string giatien, string nhaxuatban, string namxuatban)
        {
            return GAYSACHDAO.Instance.UpdateSach(magay, nhande, tacgia, tomtat, tenchude, sotrang, giatien, nhaxuatban, namxuatban);
        }

        public DataTable _ArrayOfAuthorName()
        {
            return GAYSACHDAO.Instance.ArrayOfAuthorName();
        }

        public DataTable _ArrayMuonOfMaSinhVien()
        {
            return GAYSACHDAO.Instance.ArrayMuonOfMaSinhVien();
        }

        public DataTable _ArrayMuonOfMaCuonSach()
        {
            return GAYSACHDAO.Instance.ArrayMuonOfMaCuonSach();
        }

        public DataTable _ArrayMuonOfMaGaySach()
        {
            return GAYSACHDAO.Instance.ArrayMuonOfMaGaySach();
        }

        public DataTable _ArrayMuonOfHanTra()
        {
            return GAYSACHDAO.Instance.ArrayMuonOfHanTra();
        }

        public DataTable _ArrayOfTopicName()
        {
            return GAYSACHDAO.Instance.ArrayOfTopicName();
        }

        public DataTable _ArrayOfId()
        {
            return GAYSACHDAO.Instance.ArrayOfId();
        }

        public DataTable _ArrayOfPublisher()
        {
            return GAYSACHDAO.Instance.ArrayOfPublisher();
        }

        public DataTable _ArrayOfSummary()
        {
            return GAYSACHDAO.Instance.ArrayOfSummary();
        }

        public DataTable _ArrayOfPublisherYear()
        {
            return GAYSACHDAO.Instance.ArrayOfPuhlishYear();
        }

        public DataTable _getInfoOfListId(List<int> list)
        {
            return GAYSACHDAO.Instance._getInfoOfListId(list);
        }

        public bool _Xoagaysach(string magay)
        {
            return GAYSACHDAO.Instance.Xoagaysach(magay);
        }
        public DataTable _Laytatcasach()
        {
            return GAYSACHDAO.Instance.Laytatcasach();
        }
    }
}
