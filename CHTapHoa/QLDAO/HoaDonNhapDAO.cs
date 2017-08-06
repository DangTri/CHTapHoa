using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using System.Data.SqlClient;

namespace QLDAO
{
    public class HoaDonNhapDAO
    {
        public List<HoaDonNhapDTO> DSHoaDonNhap()
        {
            List<HoaDonNhapDTO> lsthoadonhap = new List<HoaDonNhapDTO>();
            string caulenh = "SELECT MaHDN, nv.TenNV, NgayNhap, TongTien, hdn.TrangThai FROM HoaDonNhap hdn INNER JOIN NhanVien nv ON hdn.MaNV = nv.MaNV Where hdn.TrangThai = 1";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while(dr.Read())
            {
                HoaDonNhapDTO hdndto = new HoaDonNhapDTO();
                hdndto.MaHDN = dr[0].ToString();
                hdndto.MaNV = dr[1].ToString();
                hdndto.NgayNhap = Convert.ToDateTime(dr[2].ToString());
                hdndto.TongTien = int.Parse(dr[3].ToString());
                hdndto.TrangThai = int.Parse(dr[4].ToString());
                lsthoadonhap.Add(hdndto);
            }
            dr.Close();
            conn.Close();
            return lsthoadonhap;
        }

        public List<HoaDonNhapDTO> TimHoaDonNhap(DateTime tungay, DateTime denngay)
        {
            List<HoaDonNhapDTO> lsthoadonhap = new List<HoaDonNhapDTO>();
            string caulenh = "SELECT * FROM HoaDonNhap Where TrangThai = 1 and NgayNhap >= convert (nvarchar,'" + tungay + "',103) and NgayNhap <= convert (nvarchar,'" + denngay + "',103)";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                HoaDonNhapDTO hdndto = new HoaDonNhapDTO();
                hdndto.MaHDN = dr[0].ToString();
                hdndto.MaNV = dr[1].ToString();
                hdndto.NgayNhap = Convert.ToDateTime(dr[2].ToString());
                hdndto.TongTien = int.Parse(dr[3].ToString());
                hdndto.TrangThai = int.Parse(dr[4].ToString());
                lsthoadonhap.Add(hdndto);
            }
            dr.Close();
            conn.Close();
            return lsthoadonhap;
        }

        public HoaDonNhapDTO LayHoaDonNhapTheoMa(string maHD)
        {
            HoaDonNhapDTO hoadonnhap = new HoaDonNhapDTO();
            string caulenh = "SELECT MaHDN, nv.TenNV, NgayNhap, TongTien, hdn.TrangThai FROM HoaDonNhap hdn INNER JOIN NhanVien nv ON hdn.MaNV = nv.MaNV Where hdn.TrangThai = 1 AND hdn.MaHDN='" +maHD+ "'";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                hoadonnhap.MaHDN = dr[0].ToString();
                hoadonnhap.MaNV = dr[1].ToString();
                hoadonnhap.NgayNhap = Convert.ToDateTime(dr[2].ToString());
                hoadonnhap.TongTien = int.Parse(dr[3].ToString());
                hoadonnhap.TrangThai = int.Parse(dr[4].ToString());
            }
            dr.Close();
            conn.Close();
            return hoadonnhap;
        }
        public string TangHD()
        {
            string caulenh = "SELECT MAX(MaHDN) FROM HoaDonNhap";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            if(dr.Read())
            {
                if(!dr.IsDBNull(0))
                {
                    int hd = Convert.ToInt32(dr.GetString(0).Remove(0, 3));
                    hd++;
                    dr.Close();
                    conn.Close();
                    return "HDN" + hd.ToString("d4");
                }
            }
            return "HDN0001";
        }

        public bool XoaHoaDonNhap(string HoaDonNhapDTO)
        {
            string CauLenh = "UPDATE HoaDonNhap SET TrangThai = 0 WHERE MaHDN = '"+HoaDonNhapDTO+"'";
            try
            {
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(CauLenh, conn);
                return kq != 0;
            }
            catch
            {
                return false;
            }
        }

        public int ThemHoaDonNhap(HoaDonNhapDTO HoaDonNhapDTO)
        {
            string CauLenh = "INSERT INTO HoaDonNhap (MaHDN, MaNV, NgayNhap,TongTien,TrangThai) values ('{0}','{1}','{2}','{3}','1')";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(String.Format(CauLenh, HoaDonNhapDTO.MaHDN, HoaDonNhapDTO.MaNV, HoaDonNhapDTO.NgayNhap, HoaDonNhapDTO.TongTien, HoaDonNhapDTO.TrangThai=1), conn);
            return kq;

        }
    }
}
