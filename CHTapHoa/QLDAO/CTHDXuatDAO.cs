using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using System.Data.SqlClient;

namespace QLDAO
{
    public class CTHDXuatDAO
    {
        public List<CTHDXuatDTO> DanhSachCTHDXuat()
        {
            List<CTHDXuatDTO> lstcthdx = new List<CTHDXuatDTO>();
            string caulenh = "SELECT MaCTHoaDonXuat, sp.TenSP, GiaBan, cthdx.SoLuong, ThanhTien, cthdx.TrangThai FROM ChiTietHoaDonXuat cthdx INNER JOIN SanPham sp ON  cthdx.MaSP=sp.MaSP WHERE cthdx.TrangThai=1";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                CTHDXuatDTO chitiet = new CTHDXuatDTO();
                chitiet.MaCTHoaDonXuat = dr[0].ToString();
                chitiet.MaSP = dr[1].ToString();
                chitiet.GiaBan = int.Parse(dr[2].ToString());
                chitiet.SoLuong = int.Parse(dr[3].ToString());
                chitiet.ThanhTien = int.Parse(dr[4].ToString());
                chitiet.TrangThai = int.Parse(dr[5].ToString());
                lstcthdx.Add(chitiet);
            }
            dr.Close();
            conn.Close();
            return lstcthdx;
        }
        public List<CTHDXuatDTO> DSCTHDXuat(string MaHD)
        {
            List<CTHDXuatDTO> lstcthdx = new List<CTHDXuatDTO>();
            string caulenh = "SELECT MaCTHoaDonXuat, sp.TenSP, GiaBan, cthdx.SoLuong, ThanhTien, cthdx.TrangThai FROM ChiTietHoaDonXuat cthdx INNER JOIN SanPham sp ON  cthdx.MaSP=sp.MaSP WHERE MaCTHoaDonXuat='" + MaHD + "' AND cthdx.TrangThai=1";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while(dr.Read())
            {
                CTHDXuatDTO chitiet = new CTHDXuatDTO();
                chitiet.MaCTHoaDonXuat = dr[0].ToString();
                chitiet.MaSP = dr[1].ToString();
                chitiet.GiaBan = int.Parse(dr[2].ToString());
                chitiet.SoLuong = int.Parse(dr[3].ToString());
                chitiet.ThanhTien = int.Parse(dr[4].ToString());
                chitiet.TrangThai = int.Parse(dr[5].ToString());
                lstcthdx.Add(chitiet);
            }
            dr.Close();
            conn.Close();
            return lstcthdx;
        }

        public bool XoaCTHoaDonXuat(string CTHoaDonXuatDTO)
        {
            string CauLenh = "UPDATE ChiTietHoaDonXuat SET TrangThai = 0 WHERE MaCTHoaDonXuat = '" + CTHoaDonXuatDTO + "' ";
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

        public bool ThemCTHoaDonXuat(CTHDXuatDTO CTHoaDonXuatDTO)
        {
            string CauLenh = "INSERT INTO ChiTietHoaDonXuat (MaCTHoaDonXuat, MaSP, GiaBan, SoLuong, ThanhTien, TrangThai) VALUES ('{0}','{1}','{2}','{3}','{4}','1')";
            try
            {
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(String.Format(CauLenh, CTHoaDonXuatDTO.MaCTHoaDonXuat, CTHoaDonXuatDTO.MaSP, CTHoaDonXuatDTO.GiaBan, CTHoaDonXuatDTO.SoLuong, CTHoaDonXuatDTO.ThanhTien,CTHoaDonXuatDTO.TrangThai=1), conn);
                return kq != 0;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
