    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using System.Data.SqlClient;

namespace QLDAO
{
    public class HoaDonXuatDAO
    {
        HoaDonXuatDTO hdxdto = new HoaDonXuatDTO();

        public List<HoaDonXuatDTO> DSHoaDonXuat()
        {
            List<HoaDonXuatDTO> lsthoadonxuat = new List<HoaDonXuatDTO>();
            string caulenh = "SELECT MaHDX, nv.TenNV, kh.TenKH, NgayXuat, TongTien, hdx.TrangThai FROM HoaDonXuat hdx INNER JOIN NhanVien nv ON hdx.MaNV=nv.MaNV INNER JOIN KhachHang kh ON hdx.MaKH=kh.MaKH WHERE hdx.TrangThai=1";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while(dr.Read())
            {
                HoaDonXuatDTO hoadon = new HoaDonXuatDTO();
                hoadon.MaHDX = dr[0].ToString();
                hoadon.MaNV = dr[1].ToString();
                hoadon.MaKH = dr[2].ToString();
                hoadon.NgayXuat = Convert.ToDateTime(dr[3].ToString());
                hoadon.TongTien = int.Parse(dr[4].ToString());
                hoadon.TrangThai = int.Parse(dr[5].ToString());
                lsthoadonxuat.Add(hoadon);
            }
            dr.Close();
            conn.Close();
            return lsthoadonxuat;
        }

        public HoaDonXuatDTO LayHoaDonTheoMa(string maHD)
        {
            HoaDonXuatDTO hoadon = new HoaDonXuatDTO();
            string caulenh = "SELECT MaHDX, nv.TenNV, kh.TenKH, NgayXuat, TongTien, hdx.TrangThai FROM HoaDonXuat hdx INNER JOIN NhanVien nv ON hdx.MaNV=nv.MaNV INNER JOIN KhachHang kh ON hdx.MaKH=kh.MaKH WHERE hdx.TrangThai=1 AND hdx.MaHDX='"+maHD+"'";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                
                hoadon.MaHDX = dr[0].ToString();
                hoadon.MaNV = dr[1].ToString();
                hoadon.MaKH = dr[2].ToString();
                hoadon.NgayXuat = Convert.ToDateTime(dr[3].ToString());
                hoadon.TongTien = int.Parse(dr[4].ToString());
                hoadon.TrangThai = int.Parse(dr[5].ToString());
            }
            dr.Close();
            conn.Close();
            return hoadon;
        }

        public List<HoaDonXuatDTO> TimDanhSachHoaDon(DateTime tungay,DateTime denngay)
        {
            List<HoaDonXuatDTO> lsthoadonxuat = new List<HoaDonXuatDTO>();
            string caulenh = "SELECT MaHDX, nv.TenNV, kh.TenKH, NgayXuat, TongTien, hdx.TrangThai FROM HoaDonXuat hdx INNER JOIN NhanVien nv ON hdx.MaNV=nv.MaNV INNER JOIN KhachHang kh ON hdx.MaKH=kh.MaKH WHERE hdx.TrangThai=1 and NgayXuat >= convert (nvarchar,'" + tungay + "',103) and NgayXuat <= convert (nvarchar,'" + denngay + "',103)";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                HoaDonXuatDTO hoadon = new HoaDonXuatDTO();
                hoadon.MaHDX = dr[0].ToString();
                hoadon.MaNV = dr[1].ToString();
                hoadon.MaKH = dr[2].ToString();
                hoadon.NgayXuat = DateTime.Parse(dr[3].ToString());
                hoadon.TongTien = int.Parse(dr[4].ToString());
                hoadon.TrangThai = int.Parse(dr[5].ToString());
                lsthoadonxuat.Add(hoadon);
            }
            dr.Close();
            conn.Close();
            return lsthoadonxuat;
        }

        public List<HoaDonXuatDTO> LayHoaDonTheoMaNhanVien(string maNV)
        {
            
            List<HoaDonXuatDTO> lshoadon = new List<HoaDonXuatDTO>();
            
            string caulenh = "SELECT MaHDX, nv.TenNV, kh.TenKH, NgayXuat, TongTien, hdx.TrangThai FROM HoaDonXuat hdx INNER JOIN NhanVien nv ON hdx.MaNV=nv.MaNV INNER JOIN KhachHang kh ON hdx.MaKH=kh.MaKH WHERE hdx.TrangThai=1 and TenNV = '" + maNV + "'";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                HoaDonXuatDTO hoadon = new HoaDonXuatDTO();
                hoadon.MaHDX = dr[0].ToString();
                hoadon.MaNV = dr[1].ToString();
                hoadon.MaKH = dr[2].ToString();
                hoadon.NgayXuat = Convert.ToDateTime(dr[3].ToString());
                hoadon.TongTien = int.Parse(dr[4].ToString());
                hoadon.TrangThai = int.Parse(dr[5].ToString());
                lshoadon.Add(hoadon);
            }
            dr.Close();
            conn.Close();
            return lshoadon;
        }

        public string TangHD()
        {
            string caulenh = "SELECT MAX(MaHDX) FROM HoaDonXuat";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    int hd = Convert.ToInt32(dr.GetString(0).Remove(0, 3));
                    hd++;
                    dr.Close();
                    conn.Close();
                    return "HDX" + hd.ToString("d4");
                }
            }
            return "HDX0001";
        }

        public bool XoaHoaDonXuat(string HoaDonXuatDTO)
        {
            string CauLenh = "UPDATE HoaDonXuat SET TrangThai = 0 WHERE MaHDX = '" + HoaDonXuatDTO + "'";
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

        public int ThemHoaDon(HoaDonXuatDTO hoadonxuatDTO)
        {
            string CauLenh = "INSERT INTO HoaDonXuat(MaHDX, MaNV, MaKH, NgayXuat, TongTien, TrangThai) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '1')";

            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(string.Format(CauLenh, hoadonxuatDTO.MaHDX, hoadonxuatDTO.MaNV, hoadonxuatDTO.MaKH, hoadonxuatDTO.NgayXuat, hoadonxuatDTO.TongTien, hoadonxuatDTO.TrangThai=1), conn);
            return kq;
        }
    }
}
