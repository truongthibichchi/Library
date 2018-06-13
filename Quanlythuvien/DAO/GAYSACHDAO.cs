using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuvien.DTO;
using System.Data.SqlClient;
using System.Data;
using Quanlythuvien.DAO;

namespace Quanlythuvien.DAO
{
    class GAYSACHDAO
    {
        private static GAYSACHDAO _instance;
        public static  GAYSACHDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GAYSACHDAO();
                }
                return _instance;
            }
        }

        public int Taogaysach()
        {
            string query = "SELECT MAX(MAGAYSACH) FROM GAYSACH";
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar(query) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public DataTable _getInfoOfListId(List<int> list)
        {
            var dataTable = new DataTable();

            string query =
                @"
                declare @LIST_ID table
                (
                    MAGAYSACH INT PRIMARY KEY
                );";
            foreach (var item in list)
                query +=
                    @"insert into @LIST_ID values (" + item + @");
                    ";
            query +=
                @"
                declare @THONGTINGAYSACH table
                (
                    MAGAYSACH INT,
                    NHANDE NVARCHAR(400),
                    TACGIA NVARCHAR(200),
                    CHUDE NVARCHAR(100),
                    NHAXUATBAN NVARCHAR(100),
                    TOMTAT NVARCHAR(100),
                    NAMXUATBAN INT,
                    SOTRANG INT,
                    GIATIEN MONEY,
                    TONGSO INT,
                    COSAN INT,
                    DANGMUON INT,
                    COSANDEMUON INT,
                    COSANDEDOC INT,
                    BIHONG INT,
                    DAMAT INT
                );
                ";
            query +=
                @"
                declare @id int, 
                        @tongSo int, 
                        @coSan int, 
                        @dangMuon int,
                        @biHong int,
                        @daMat int,
                        @coSanDeMuon int,
                        @coSanDeDoc int,
                        @nhanDe nvarchar(400),
                        @tacGia nvarchar(200), 
                        @chuDe nvarchar(100),
                        @nhaXuatBan nvarchar(100),
                        @tomTat nvarchar(100), 
                        @namXuatBan int, 
                        @soTrang int, 
                        @giaTien money
                ";

            query +=
                @"
                while exists (select * from @LIST_ID)
                begin
	                select top 1 @id = MAGAYSACH from @LIST_ID

	                select @biHong = count(*) from CUONSACH where CUONSACH.MAGAYSACH = @id and CUONSACH.TINHTRANG = 2
	
	                select @daMat = count(*) from CUONSACH where CUONSACH.MAGAYSACH = @id and CUONSACH.TINHTRANG = 3

	                select @tongSo = count(*) from CUONSACH where CUONSACH.MAGAYSACH = @id

	                select @coSan = count(*) from CUONSACH where CUONSACH.MAGAYSACH = @id and CUONSACH.TINHTRANG = 0

	                select @dangMuon = count(*) from CUONSACH where CUONSACH.MAGAYSACH = @id and CUONSACH.TINHTRANG = 1

	                select @coSanDeMuon = count(*) from CUONSACH where CUONSACH.MAGAYSACH = @id and CUONSACH.TINHTRANG = 0 and CUONSACH.VITRI = 0

	                set @coSanDeDoc = @coSan - @coSanDeMuon

	                select @nhanDe = NHANDE, @tacGia = TACGIA, @chuDe = CHUDE, @nhaXuatBan = NHAXUATBAN, @tomTat = TOMTAT, @namXuatBan = NAMXUATBAN, @soTrang = SOTRANG, @giaTien = GIATIEN from GAYSACH where GAYSACH.MAGAYSACH = @id

	                insert into @THONGTINGAYSACH(MAGAYSACH, TONGSO, COSAN, DANGMUON, BIHONG, DAMAT, COSANDEMUON, COSANDEDOC, NHANDE, TACGIA, CHUDE, NHAXUATBAN, TOMTAT, NAMXUATBAN, SOTRANG, GIATIEN) values(@id, @tongSo, @coSan, @dangMuon, @biHong, @daMat, @coSanDeMuon, @coSanDeDoc, @nhanDe, @tacGia, @chuDe, @nhaXuatBan, @tomTat, @namXuatBan, @soTrang, @giaTien)
	
	                delete from @LIST_ID where MAGAYSACH = @id
                end

                select * from @THONGTINGAYSACH
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

        public DataTable ArrayMuonOfMaCuonSach()
        {
            string query = "SELECT DISTINCT R.MASACH, GS.CHUDE, GS.GIATIEN, GS.MAGAYSACH, GS.NAMXUATBAN, GS.NHANDE, GS.NHAXUATBAN, GS.TACGIA, R.MAMUON, R.MATAIKHOAN, R.TINHTRANGGIAO, R.NGAYMUON, R.HANTRA, SV.HOTEN, SV.KHOA, SV.LOP FROM (SELECT PM.MAMUON, PM.MATAIKHOAN, CT.MASACH, CT.TINHTRANGGIAO, PM.NGAYMUON, PM.HANTRA FROM PHIEUMUON PM JOIN CHITIETPHIEUMUON CT ON PM.MAMUON = CT.MAMUON EXCEPT( SELECT PT.MAMUON , PT.MATAIKHOAN , CT.MASACH, CTM.TINHTRANGGIAO, PM.NGAYMUON, PM.HANTRA FROM PHIEUTRA PT JOIN CHITIETPHIEUTRA CT ON PT.MATRA = CT.MATRA JOIN CHITIETPHIEUMUON CTM ON PT.MAMUON = CTM.MAMUON JOIN PHIEUMUON PM ON PM.MAMUON = CTM.MAMUON, GAYSACH GS, CUONSACH CS ) ) AS R, CHITIETPHIEUMUON CT, GAYSACH GS, CUONSACH CS, SINHVIEN SV WHERE R.MASACH = CT.MASACH AND CS.MASACH = CT.MASACH AND GS.MAGAYSACH = CS.MAGAYSACH AND SV.MATAIKHOAN = R.MATAIKHOAN";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayMuonOfMaSinhVien()
        {
            string query = "SELECT DISTINCT R.MASACH, GS.CHUDE, GS.GIATIEN, GS.MAGAYSACH, GS.NAMXUATBAN, GS.NHANDE, GS.NHAXUATBAN, GS.TACGIA, R.MAMUON, R.MATAIKHOAN, R.TINHTRANGGIAO, R.NGAYMUON, R.HANTRA, SV.HOTEN, SV.KHOA, SV.LOP FROM (SELECT PM.MAMUON, PM.MATAIKHOAN, CT.MASACH, CT.TINHTRANGGIAO, PM.NGAYMUON, PM.HANTRA FROM PHIEUMUON PM JOIN CHITIETPHIEUMUON CT ON PM.MAMUON = CT.MAMUON EXCEPT( SELECT PT.MAMUON , PT.MATAIKHOAN , CT.MASACH, CTM.TINHTRANGGIAO, PM.NGAYMUON, PM.HANTRA FROM PHIEUTRA PT JOIN CHITIETPHIEUTRA CT ON PT.MATRA = CT.MATRA JOIN CHITIETPHIEUMUON CTM ON PT.MAMUON = CTM.MAMUON JOIN PHIEUMUON PM ON PM.MAMUON = CTM.MAMUON, GAYSACH GS, CUONSACH CS ) ) AS R, CHITIETPHIEUMUON CT, GAYSACH GS, CUONSACH CS, SINHVIEN SV WHERE R.MASACH = CT.MASACH AND CS.MASACH = CT.MASACH AND GS.MAGAYSACH = CS.MAGAYSACH AND SV.MATAIKHOAN = R.MATAIKHOAN";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayMuonOfMaGaySach()
        {
            string query = "SELECT DISTINCT R.MASACH, GS.CHUDE, GS.GIATIEN, GS.MAGAYSACH, GS.NAMXUATBAN, GS.NHANDE, GS.NHAXUATBAN, GS.TACGIA, R.MAMUON, R.MATAIKHOAN, R.TINHTRANGGIAO, R.NGAYMUON, R.HANTRA, SV.HOTEN, SV.KHOA, SV.LOP FROM (SELECT PM.MAMUON, PM.MATAIKHOAN, CT.MASACH, CT.TINHTRANGGIAO, PM.NGAYMUON, PM.HANTRA FROM PHIEUMUON PM JOIN CHITIETPHIEUMUON CT ON PM.MAMUON = CT.MAMUON EXCEPT( SELECT PT.MAMUON , PT.MATAIKHOAN , CT.MASACH, CTM.TINHTRANGGIAO, PM.NGAYMUON, PM.HANTRA FROM PHIEUTRA PT JOIN CHITIETPHIEUTRA CT ON PT.MATRA = CT.MATRA JOIN CHITIETPHIEUMUON CTM ON PT.MAMUON = CTM.MAMUON JOIN PHIEUMUON PM ON PM.MAMUON = CTM.MAMUON, GAYSACH GS, CUONSACH CS ) ) AS R, CHITIETPHIEUMUON CT, GAYSACH GS, CUONSACH CS, SINHVIEN SV WHERE R.MASACH = CT.MASACH AND CS.MASACH = CT.MASACH AND GS.MAGAYSACH = CS.MAGAYSACH AND SV.MATAIKHOAN = R.MATAIKHOAN";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayMuonOfHanTra()
        {
            string query = "SELECT DISTINCT R.MASACH, GS.CHUDE, GS.GIATIEN, GS.MAGAYSACH, GS.NAMXUATBAN, GS.NHANDE, GS.NHAXUATBAN, GS.TACGIA, R.MAMUON, R.MATAIKHOAN, R.TINHTRANGGIAO, R.NGAYMUON, R.HANTRA, SV.HOTEN, SV.KHOA, SV.LOP FROM (SELECT PM.MAMUON, PM.MATAIKHOAN, CT.MASACH, CT.TINHTRANGGIAO, PM.NGAYMUON, PM.HANTRA FROM PHIEUMUON PM JOIN CHITIETPHIEUMUON CT ON PM.MAMUON = CT.MAMUON EXCEPT( SELECT PT.MAMUON , PT.MATAIKHOAN , CT.MASACH, CTM.TINHTRANGGIAO, PM.NGAYMUON, PM.HANTRA FROM PHIEUTRA PT JOIN CHITIETPHIEUTRA CT ON PT.MATRA = CT.MATRA JOIN CHITIETPHIEUMUON CTM ON PT.MAMUON = CTM.MAMUON JOIN PHIEUMUON PM ON PM.MAMUON = CTM.MAMUON, GAYSACH GS, CUONSACH CS ) ) AS R, CHITIETPHIEUMUON CT, GAYSACH GS, CUONSACH CS, SINHVIEN SV WHERE R.MASACH = CT.MASACH AND CS.MASACH = CT.MASACH AND GS.MAGAYSACH = CS.MAGAYSACH AND SV.MATAIKHOAN = R.MATAIKHOAN";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayOfId()
        {
            string query = "SELECT MAGAYSACH FROM GAYSACH";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayOfBookName()
        {
            string query = "SELECT MAGAYSACH, NHANDE FROM GAYSACH";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayOfAuthorName()
        {
            string query = "SELECT MAGAYSACH, TACGIA FROM GAYSACH";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayOfTopicName()
        {
            string query = "SELECT MAGAYSACH, CHUDE FROM GAYSACH";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayOfPublisher()
        {
            string query = "SELECT MAGAYSACH, NHAXUATBAN FROM GAYSACH";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayOfSummary()
        {
            string query = "SELECT MAGAYSACH, TOMTAT FROM GAYSACH";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable ArrayOfPuhlishYear()
        {
            string query = "SELECT MAGAYSACH, NAMXUATBAN FROM GAYSACH";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int InsertSach(string magay, string nhande, string tacgia, string tomtat, string tenchude, string sotrang, string giatien, string nhaxuatban, string namxuatban)
        {
            int result = 0;
            string query =
                @"
                insert into GAYSACH(MAGAYSACH, NHANDE, TACGIA, CHUDE, NHAXUATBAN, TOMTAT, NAMXUATBAN, SOTRANG, GIATIEN)
                values("
                + magay + @",
                N'" + nhande + @"',
                N'" + tacgia + @"',
                N'" + tenchude + @"',
                N'" + nhaxuatban + @"',
                N'" + tomtat + @"',
                " + namxuatban + @", 
                " + sotrang + @", 
                " + giatien + @" 
                )";
            using (var conn = new SqlConnection(DataProvider.Instance.connstring))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = query;
                result = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return result;
        }

        public int UpdateSach(string magay, string nhande, string tacgia, string tomtat, string tenchude, string sotrang, string giatien, string nhaxuatban, string namxuatban)
        {
            int result = 0;
            string query =
                @"
                update GAYSACH
                set NHANDE = N'" + nhande + @"', 
                    TACGIA = N'" + tacgia + @"',
                    CHUDE = N'" + tenchude + @"',
                    NHAXUATBAN = N'" + nhaxuatban + @"',
                    TOMTAT = N'" + tomtat + @"',
                    NAMXUATBAN = " + namxuatban + @",
                    SOTRANG = " + sotrang + @",
                    GIATIEN = " + giatien + @"
                where MAGAYSACH = " + magay + @"
                ";
            using (var conn = new SqlConnection(DataProvider.Instance.connstring))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = query;
                result = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return result;
        }

        public bool Xoagaysach(string magay)
        {
            string query = "DELETE FROM GAYSACH WHERE MAGAYSACH = @magay";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { magay }) > 0;
        }
        public DataTable Laytatcasach()
        {
            string query = "SELECT * FROM CUONSACH JOIN GAYSACH WHERE CUONSACH.MAGAYSACH = GAYSACH.MAGAYSACH";
            return DataProvider.Instance.ExecuteQuery(query);
        }

    }
}
