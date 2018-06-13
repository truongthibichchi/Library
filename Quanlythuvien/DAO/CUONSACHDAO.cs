using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Quanlythuvien.DTO;

namespace Quanlythuvien.DAO
{
    class CUONSACHDAO
    {
        private static CUONSACHDAO _instance;
        public static CUONSACHDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CUONSACHDAO();
                }
                return _instance;
            }
        }

        public DataTable getInfoOfListId(List<int> list)
        {
            var dataTable = new DataTable();

            string query =
                @"
                declare @LIST_ID table
                (
                    MASACH INT PRIMARY KEY
                );";
            foreach (var item in list)
                query +=
                    @"
                    insert into @LIST_ID values (" + item + @");
                    ";      
            query +=
                @"
                select CUONSACH.MASACH, CUONSACH.VITRI, CUONSACH.TINHTRANG FROM CUONSACH, @LIST_ID as lst WHERE CUONSACH.MASACH = lst.MASACH
                ";
            using (var conn = new SqlConnection(DataProvider.Instance.connstring))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"" + query;
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                conn.Close();
            }
            return dataTable;
        }

        public DataTable ArrayOfId(string maGaySach)
        {
            string query = "SELECT MASACH FROM CUONSACH";
            query += " WHERE MAGAYSACH = " + maGaySach;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayOfArea(string maGaySach)
        {
            string query = "SELECT MASACH, VITRI FROM CUONSACH";
            query += " WHERE MAGAYSACH = " + maGaySach;
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayOfStatus(string maGaySach)
        {
            string query = "SELECT MASACH, TINHTRANG FROM CUONSACH";
            query += " WHERE MAGAYSACH = " + maGaySach;
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public void NhapCuonSach(string maGaySach, int soLuong, int viTri)
        {
            int maSachTiepTheo = Getmasachmoinhat();
            string query = @"";

            for (int i = maSachTiepTheo; i < maSachTiepTheo + soLuong; i++)
                query +=
                    @"
                    insert into CUONSACH(MASACH, TINHTRANG, VITRI, MAGAYSACH) values (" + i + @", 0, " + viTri + @", " + maGaySach + @")
                    ";
          
            using (var conn = new SqlConnection(DataProvider.Instance.connstring))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"" + query;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public int LayMaSachCoTheMuon(string maGaySach)
        {
            string query =
                @"
                SELECT TOP 1 MASACH
                FROM CUONSACH
                WHERE TINHTRANG = 0 AND VITRI = 0 AND MAGAYSACH = " + maGaySach + 
                @"";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public int LayMaSachNamTrongKhoMuon(string maGaySach)
        {
            string query =
                @"
                SELECT TOP 1 MASACH
                FROM CUONSACH
                WHERE VITRI = 0 AND MAGAYSACH = " + maGaySach +
                @"";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }
        public DataTable GetSachbymachude(string machude)
        {
            DataTable dt = new DataTable();
            string query = "USP_THONGTINSACH @machude";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { machude });
            return dt;
        }

        public DataTable GetSachbyTacgia(string tacgia)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM CUONSACH CS JOIN GAYSACH GS ON CS.MAGAYSACH = GS.MAGAYSACH JOIN CHUDE CD ON CD.MACHUDE = CS.MACHUDE" +
                           " WHERE  GS.TACGIA LIKE '%' + @tacgia + '%'";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { tacgia });
            return dt;
        }

        public DataTable GetSachbymasach(string masach)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM CUONSACH CS JOIN GAYSACH GS ON CS.MAGAYSACH = GS.MAGAYSACH JOIN CHUDE CD ON CD.MACHUDE = CS.MACHUDE WHERE CS.MASACH = @masach";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { masach });
            return dt;
        }

        public DataTable Timkiemtheotensach(string tensach)
        {
            string query = "USP_TIMKIEMSACH @tensach";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { tensach });
        }

        public int Updatetinhtrangsachmuon(int masach)
        {
            string query = "UPDATE CUONSACH SET TINHTRANG = 1 WHERE MASACH = @masach";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { masach });
        }

        public DataTable TimkiemsachSVdangmuon(string mataikhoan)
        {
            string query = "USP_SV_SACHDANGMUON @mataikhoan";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { mataikhoan });
        }

        public int DeleteSach(int masach)
        {
            string query = "DELETE FROM CUONSACH WHERE MASACH = @masach";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { masach });
        }

        public DataTable Kiemtrathongtinsach(string tensach)
        {
            string query = "USP_TIMKIEMSACH @nhande";
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { tensach });
            return dt;
        }

        public int Insertsach(string magay, string nhande, string tacgia, string tomtat, string machude, string tenchude, int sotrang, int giatien, string nhaxuatban, int namxuatban, int duocmuon)
        {
            string query = "USP_INSERTSACH @magay , @nhande , @tacgia , @tomtat , @machude , @tenchude , @sotrang , @giatien , @nhaxuatban , @namxuatban , @duocmuon";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { magay, nhande, tacgia, tomtat, machude, tenchude, sotrang, giatien, nhaxuatban, namxuatban, duocmuon });
        }

        public int Updatesach (int masach , int tinhtrang , int vitri )
        {
            string query = "UPDATE CUONSACH SET TINHTRANG = @tinhtrang , VITRI = @vitri WHERE MASACH = @masach ";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] {tinhtrang, vitri, masach});
        }
        public int Getmasachmoinhat()
        {
            string query = "SELECT MAX(MASACH) FROM CUONSACH";
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar(query) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public DataTable Getallsach()
        {
            string query = "SELECT * FROM CUONSACH CS JOIN GAYSACH GS ON CS.MAGAYSACH = GS.MAGAYSACH JOIN CHUDE CD ON CD.MACHUDE = CS.MACHUDE ORDER BY MASACH ASC";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int Updatetinhtrangsachtra(int masach)
        {
            string query = "UPDATE CUONSACH SET TINHTRANG = 0 WHERE MASACH = @masach";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { masach });
        }

        public int Laymagaysachbangmasach(int masach)
        {
            string query = "SELECT MAGAYSACH FROM CUONSACH WHERE MASACH = @masach";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { masach });
        }
    }
}    