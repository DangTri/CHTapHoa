using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using System.Data.SqlClient;

namespace QLDAO
{
    public class NhanVienDAO
    {
        public  List<NhanVienDTO> DanhSachNhanVien()
        {
            List<NhanVienDTO> lstnhanvien = new List<NhanVienDTO>();
            string caulenh = "SELECT MaNV, HoNV, TenNV, LoaiNV, MatKhau, GioiTinh,NgaySinh, DiaChi, SDT, Luong, HinhAnh, nv.TrangThai FROM NhanVien nv INNER JOIN LoaiNhanVien lnv ON nv.MaLoaiNV=lnv.MaLoaiNV WHERE nv.TrangThai = 1";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while(dr.Read())
            {
                NhanVienDTO nhanviendto = new NhanVienDTO();
                nhanviendto.MaNV = dr["MaNV"].ToString();
                nhanviendto.HoNV = dr[1].ToString();
                nhanviendto.TenNV = dr[2].ToString();
                nhanviendto.MaLoaiNV=dr[3].ToString();
                nhanviendto.MatKhau=dr[4].ToString();
                nhanviendto.GioiTinh = dr[5].ToString();
                nhanviendto.NgaySinh = DateTime.Parse(dr[6].ToString());
                nhanviendto.DiaChi = dr[7].ToString();
                nhanviendto.SDT = dr[8].ToString();
                nhanviendto.Luong = Convert.ToDouble(dr[9].ToString());
                nhanviendto.HinhAnh = dr[10].ToString();
                nhanviendto.TrangThai = int.Parse(dr[11].ToString());

                lstnhanvien.Add(nhanviendto);
            }
            dr.Close();
            conn.Close();
            return lstnhanvien;
        }

        public List<LoaiNhanVienDTO> DanhSachLoaiNhanVien()
        {
            List<LoaiNhanVienDTO> lstlnv = new List<LoaiNhanVienDTO>();
            string query = "SELECT * FROM LoaiNhanVien";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(query, conn);
            while(dr.Read())
            {
                LoaiNhanVienDTO lnvdto = new LoaiNhanVienDTO();
                lnvdto.MaLoaiNV = dr[0].ToString();
                lnvdto.LoaiNV = dr[1].ToString();
                lstlnv.Add(lnvdto);
            }
            dr.Close();
            conn.Close();
            return lstlnv;
        }

        public bool ThemNhanVien(NhanVienDTO nhanviendto)
        {
            string caulenh = "INSERT INTO NhanVien (MaNV, HoNV, TenNV, MaLoaiNV, MatKhau, GioiTinh, NgaySinh, DiaChi, SDT, Luong, HinhAnh, TrangThai) VALUES('{0}',N'{1}',N'{2}',N'{3}','{4}',N'{5}','{6}',N'{7}','{8}','{9}','{10}',1)";
            try
            {
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(string.Format(caulenh, nhanviendto.MaNV, nhanviendto.HoNV, nhanviendto.TenNV, nhanviendto.MaLoaiNV, nhanviendto.MatKhau, nhanviendto.GioiTinh, nhanviendto.NgaySinh, nhanviendto.DiaChi, nhanviendto.SDT, nhanviendto.Luong, nhanviendto.HinhAnh), conn);
                return kq != 0;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaNhanVien(NhanVienDTO nhanviendto)
        {
            string caulenh = "UPDATE NhanVien SET HoNV=N'" + nhanviendto.HoNV + "', TenNV=N'" + nhanviendto.TenNV + "', MaLoaiNV='" + nhanviendto.MaLoaiNV + "', MatKhau='" + nhanviendto.MatKhau + "', GioiTinh=N'" + nhanviendto.GioiTinh + "', NgaySinh='" + nhanviendto.NgaySinh + "', DiaChi = N'" + nhanviendto.DiaChi + "', SDT='" + nhanviendto.SDT + "', Luong='" + nhanviendto.Luong + "',HinhAnh='" + nhanviendto.HinhAnh + "' WHERE MaNV='" + nhanviendto.MaNV + "'";
            try
            {
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(caulenh, conn);
                return kq != 0;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaNhanVien(string MaNV)
        {
            string caulenh = "UPDATE NhanVien SET TrangThai=0 WHERE MaNV = '"+ MaNV +"'";
            try
            {
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(string.Format(caulenh, MaNV), conn);
                return kq != 0;
            }
            catch
            {
                return false;
            }
        }

        public string TangNhanVien()
        {
            string caulenh = "SELECT MAX(MaNV) FROM NhanVien";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            if(dr.Read())
            {
                if(!dr.IsDBNull(0))
                {
                    int nv = Convert.ToInt32(dr.GetString(0).Remove(0, 2));
                    nv++;
                    dr.Close();
                    conn.Close();
                    return "NV" + nv.ToString("d4");
                }
            }
            return "NV0001";
        }
    }
}
