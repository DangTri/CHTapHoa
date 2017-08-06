using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using System.Data.SqlClient;

namespace QLDAO
{
    public class SanPhamDAO
    {
      public List<SanPhamDTO> DanhSachSanPham()
        {
          List<SanPhamDTO> lstsanpham = new List<SanPhamDTO>();
          string caulenh = "Select MaSP, TenSP, TenLoaiSP, XuatXu, GiaTien, HinhAnh, SoLuong, TenNCC, sp.TrangThai FROM SanPham sp INNER JOIN LoaiSanPham lsp ON sp.MaLoaiSP = lsp.MaLoaiSP INNER JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC where sp.TrangThai = 1";
          SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
          SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
          while(dr.Read())
          {
              SanPhamDTO sanphamdto = new SanPhamDTO();
              sanphamdto.MaSP = dr[0].ToString();
              sanphamdto.TenSP = dr[1].ToString();
              sanphamdto.MaLoaiSP = dr[2].ToString();
              sanphamdto.XuatXu = dr[3].ToString();
              sanphamdto.GiaTien = Convert.ToDouble(dr[4].ToString());
              sanphamdto.HinhAnh = dr[5].ToString();
              sanphamdto.SoLuong = int.Parse(dr[6].ToString());
              sanphamdto.MaNCC = dr[7].ToString();

              sanphamdto.TrangThai = int.Parse(dr[8].ToString());
              lstsanpham.Add(sanphamdto);   
          }
          dr.Close();
          conn.Close();
          return lstsanpham;
        }

      public List<SanPhamDTO> DanhSachSanPhamHetHang()
      {
          List<SanPhamDTO> lstsanpham = new List<SanPhamDTO>();
          string caulenh = "Select MaSP, TenSP, TenLoaiSP, SoLuong, sp.TrangThai FROM SanPham sp INNER JOIN LoaiSanPham lsp ON sp.MaLoaiSP = lsp.MaLoaiSP where sp.TrangThai = 1 AND SoLuong < 20";
          SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
          SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
          while (dr.Read())
          {
              SanPhamDTO sanphamdto = new SanPhamDTO();
              sanphamdto.MaSP = dr[0].ToString();
              sanphamdto.TenSP = dr[1].ToString();
              sanphamdto.MaLoaiSP = dr[2].ToString();
              sanphamdto.SoLuong = int.Parse(dr[3].ToString());
              sanphamdto.TrangThai = int.Parse(dr[4].ToString());
              lstsanpham.Add(sanphamdto);
          }
          dr.Close();
          conn.Close();
          return lstsanpham;
      }

      public List<SanPhamDTO> DanhSachSanPhamBanChay()
      {
          List<SanPhamDTO> lstsanpham = new List<SanPhamDTO>();
          string caulenh = "SELECT TOP 10 cthd.MaSP, sp.TenSP, sp.GiaTien, sp.XuatXu, ncc.TenNCC , SUM( cthd.SoLuong ) as SoLuongDaBan FROM SanPham sp, NhaCungCap ncc, ChiTietHoaDonXuat cthd, HoaDonXuat hd WHERE hd.MaHDX = cthd.MaCTHoaDonXuat AND sp.MaSP = cthd.MaSP AND sp.MaNCC = ncc.MaNCC and sp.TrangThai = 1 GROUP BY cthd.MaSP, sp.TenSP, ncc.TenNCC, sp.GiaTien, sp.XuatXu ORDER BY SUM( cthd.SoLuong) desc";
          SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
          SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
          while (dr.Read())
          {
              SanPhamDTO sanphamdto = new SanPhamDTO();
              sanphamdto.MaSP = dr[0].ToString();
              sanphamdto.TenSP = dr[1].ToString();
              sanphamdto.GiaTien = Convert.ToDouble(dr[2].ToString());
              sanphamdto.XuatXu = dr[3].ToString();
              sanphamdto.MaNCC = dr[4].ToString();
              sanphamdto.TrangThai = int.Parse(dr[5].ToString());
              lstsanpham.Add(sanphamdto);
          }
          dr.Close();
          conn.Close();
          return lstsanpham;
      }
      public bool ThemSanPham(SanPhamDTO sanphamdto)
      {
          string caulenh = "INSERT INTO SanPham (MaSP,TenSP,MaLoaiSP,XuatXu,GiaTien,HinhAnh,SoLuong,MaNCC,TrangThai) VALUES('{0}',N'{1}','{2}',N'{3}','{4}','{5}','{6}','{7}',1)";
          try
          {
              SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
              int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(string.Format(caulenh, sanphamdto.MaSP,sanphamdto.TenSP,sanphamdto.MaLoaiSP,sanphamdto.XuatXu,sanphamdto.GiaTien,sanphamdto.HinhAnh,sanphamdto.SoLuong,sanphamdto.MaNCC), conn);
              return kq != 0;
          }
          catch
          {
              return false;
          }
      } 
      public bool XoaSanPham(string MaSanPham)
      {
          string caulenh = "UPDATE SanPham set TrangThai = 0 WHERE MaSP = '" + MaSanPham + "' ";
          try
          {
              SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
              int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh("UPDATE SanPham set TrangThai = 0 WHERE MaSP = '"+ MaSanPham +"' ", conn);
              return kq != 0;
          }
          catch
          {
              return false;
          }
      }

      public bool SuaSanPham(SanPhamDTO sanphamdto)
      {
          string caulenh = "UPDATE SanPham SET TenSP = N'{0}', MaLoaiSP = {1}, XuatXu = N'{2}', GiaTien = {3},HinhAnh = {4}, SoLuong = {5}, MaNCC = {6}, TrangThai = {7} WHERE MaSP = '"+ sanphamdto.MaSP +"' ";
       
              SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
              int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh("UPDATE SanPham SET TenSP = N'" + sanphamdto.TenSP + "', MaLoaiSP = '" + sanphamdto.MaLoaiSP + "', XuatXu = N'" + sanphamdto.XuatXu + "', GiaTien = " + sanphamdto.GiaTien + ",HinhAnh = '" + sanphamdto.HinhAnh + "', SoLuong = " + sanphamdto.SoLuong + ", MaNCC = '" + sanphamdto.MaNCC + "' WHERE MaSP = '" + sanphamdto.MaSP + "' ", conn);
              return kq != 0;
       
      }

       public  string LayMaSPMax()
        {
           string masp;
          SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
          string query = "SELECT max(MaSP) from SanPham";
          SqlDataReader read = DataProvider_QLCHTapHoa.TruyVanDuLieu(query, conn);
          read.Read();
           masp = read[0].ToString();
           return masp;
        }
    
        public string TangSanPham()
       {
           string newMaSP = "SP0001";
           string caulenh = "SELECT MAX(MaSP) FROM SanPham";
           SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
           SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            if(dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    int sp = Convert.ToInt32(dr.GetString(0).Remove(0, 2));
                    sp++;
                    newMaSP = "SP" + sp.ToString("d4");
                    dr.Close();
                    conn.Close();
                    return newMaSP;
                }
                else
                    return newMaSP;
            }
            return newMaSP;
       }

        public bool TimMaSP(string MaSP)
        {
            string caulenh = "SELECT * FROM SanPham WHERE  MaSP='" + MaSP + "'";
            try
            {
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
                if(dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public bool TruSL(SanPhamDTO tc1)
        {
            string CauLenh = "UPDATE SanPham SET SoLuong -=" + tc1.SoLuong + " WHERE MaSP = '" + tc1.MaSP + "'";
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

        public bool CongSL(SanPhamDTO tc1)
        {
            string CauLenh = "UPDATE SanPham SET SoLuong +=" + tc1.SoLuong + " WHERE MaSP = '" + tc1.MaSP + "'";
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
    }

}
