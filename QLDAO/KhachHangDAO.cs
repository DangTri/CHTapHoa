using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using System.Data.SqlClient;

namespace QLDAO
{
    public class KhachHangDAO
    {
        public List<KhachHangDTO> DanhSachKhachHang()
        {
            List<KhachHangDTO> lstkh = new List<KhachHangDTO>();
            string caulenh = "SELECT *FROM KhachHang WHERE TrangThai=1";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                KhachHangDTO khdto = new KhachHangDTO();
                khdto.MaKH = dr["MaKH"].ToString();
                khdto.TenKH = dr["TenKH"].ToString();
                khdto.DiaChi = dr["DiaChi"].ToString();
                khdto.SDT = dr["SDT"].ToString();
                khdto.TrangThai = int.Parse(dr["TrangThai"].ToString());

                lstkh.Add(khdto);

            }
            dr.Close();
            conn.Close();
            return lstkh;
        }

        public KhachHangDTO LayKHTheoMa(string MaKH)
        {
            KhachHangDTO khdto = new KhachHangDTO();
            string caulenh = "SELECT *FROM KhachHang WHERE TrangThai=1 AND MaKH='"+MaKH+"'";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                
                khdto.MaKH = dr["MaKH"].ToString();
                khdto.TenKH = dr["TenKH"].ToString();
                khdto.DiaChi = dr["DiaChi"].ToString();
                khdto.SDT = dr["SDT"].ToString();
                khdto.TrangThai = int.Parse(dr["TrangThai"].ToString());


            }
            dr.Close();
            conn.Close();
            return khdto;
        }

        public bool ThemKhachhang(KhachHangDTO khachhangdto)
        {
            string caulenh = "INSERT INTO KhachHang (MaKH, TenKH, DiaChi, SDT, TrangThai)VALUES('{0}',N'{1}',N'{2}','{3}',1)";
            try
            {
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(string.Format(caulenh, khachhangdto.MaKH, khachhangdto.TenKH, khachhangdto.DiaChi, khachhangdto.SDT, khachhangdto.TrangThai), conn);
                return kq != 0;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaKhachHang(KhachHangDTO khachhangdto)
        {
            string caulenh = "UPDATE KhachHang SET TenKH=N'" + khachhangdto.TenKH + "',DiaChi=N'" + khachhangdto.DiaChi + "',SDT='" + khachhangdto.SDT + "'WHERE MaKH='" + khachhangdto.MaKH + "'";
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

        public bool XoaKhachHang(string Makhachhang)
        {
            string caulenh = "UPDATE KhachHang SET TrangThai=0 WHERE MaKH='" + Makhachhang + "'";
            try
            {
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(string.Format(caulenh,Makhachhang),conn);
                return kq != 0;
            }
            catch
            {
                return false;
            }
        }

        public string TangKhachHang()
        {
            string caulenh = "SELECT MAX(MaKH) FROM KhachHang";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            if(dr.Read())
            {
                if(!dr.IsDBNull(0))
                {
                    int kh = Convert.ToInt32(dr.GetString(0).Remove(0, 2));
                    kh++;
                    dr.Close();
                    conn.Close();
                    return "KH" + kh.ToString("d4");

                }
            }
            return "KH0001";
        }
    }
}
