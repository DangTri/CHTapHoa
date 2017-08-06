using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using System.Data.SqlClient;

namespace QLDAO
{
    public class CTHDNhapDAO
    {
        public List<CTHDNhapDTO> DSCTHDNhap(string MaHDN)
        {
            List<CTHDNhapDTO> lscthdn = new List<CTHDNhapDTO>();
            string caulenh = "SELECT MaCTHoaDonNhap, sp.TenSP, GiaNhap, cthdn.SoLuong, ThanhTien, cthdn.TrangThai FROM ChiTietHoaDonNhap cthdn INNER JOIN SanPham sp ON cthdn.MaSP = sp.MaSP WHERE MaCTHoaDonNhap='" + MaHDN + "' AND cthdn.TrangThai=1";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                CTHDNhapDTO chitiet = new CTHDNhapDTO();
                chitiet.MaCTHoaDonNhap = dr[0].ToString();
                chitiet.MaSP = dr[1].ToString();
                chitiet.GiaNhap = int.Parse(dr[2].ToString());
                chitiet.SoLuong = int.Parse(dr[3].ToString());
                chitiet.ThanhTien = int.Parse(dr[4].ToString());
                chitiet.TrangThai = int.Parse(dr[5].ToString());
                lscthdn.Add(chitiet);
            }
            dr.Close();
            conn.Close();
            return lscthdn;
        }

        public bool XoaCTHoaDonNhap(string CTHoaDonNhapDTO)
        {
            string CauLenh = "UPDATE ChiTietHoaDonNhap SET TrangThai = 0 WHERE MaCTHoaDonNhap = '" + CTHoaDonNhapDTO + "' ";
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

        public bool ThemCTHoaDonNhap(CTHDNhapDTO CTHoaDonNhapDTO)
        {
            string CauLenh = "INSERT INTO ChiTietHoaDonNhap (MaCTHoaDonNhap, MaSP, GiaNhap, SoLuong, ThanhTien, TrangThai) VALUES ('{0}','{1}','{2}','{3}','{4}','1')";
           
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(String.Format(CauLenh, CTHoaDonNhapDTO.MaCTHoaDonNhap, CTHoaDonNhapDTO.MaSP, CTHoaDonNhapDTO.GiaNhap, CTHoaDonNhapDTO.SoLuong, CTHoaDonNhapDTO.ThanhTien, CTHoaDonNhapDTO.TrangThai=1), conn);
                return kq!=0;
            
        }
    }
}
