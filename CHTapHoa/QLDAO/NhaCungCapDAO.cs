using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using System.Data.SqlClient;

namespace QLDAO
{
    public class NhaCungCapDAO
    {
        public static List<NhaCungCapDTO> DanhSachNhaCungCap()
        {
            List<NhaCungCapDTO> lstncc = new List<NhaCungCapDTO>();
            string caulenh = "SELECT * FROM NhaCungCap WHERE TrangThai=1";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read()) 
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO();
                ncc.MaNCC = dr["MaNCC"].ToString();
                ncc.TenNCC = dr["TenNCC"].ToString();
                ncc.DiaChi = dr["DiaChi"].ToString();
                ncc.SDT = dr["SDT"].ToString();
                ncc.Email = dr["Email"].ToString();
                ncc.TrangThai = int.Parse(dr["TrangThai"].ToString());

                lstncc.Add(ncc);
            }
            dr.Close();
            conn.Close();
            return lstncc;
        }

        public bool ThemNhaCungCap(NhaCungCapDTO nccdto)
        {
            string caulenh = "INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, Email, SDT, TrangThai)VALUES('{0}',N'{1}',N'{2}','{3}','{4}',1)";
            try
            {
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(string.Format(caulenh, nccdto.MaNCC, nccdto.TenNCC, nccdto.DiaChi, nccdto.Email, nccdto.SDT, nccdto.TrangThai), conn);
                return kq != 0;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaNhaCungCap(NhaCungCapDTO nccdto)
        {
            string caulenh = "UPDATE NhaCungCap SET TenNCC = N'" + nccdto.TenNCC + "', DiaChi = N'" + nccdto.DiaChi + "', SDT = N'" + nccdto.SDT + "', Email = N'" + nccdto.Email + "' WHERE MaNCC = '" + nccdto.MaNCC + "'";
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

        public bool XoaNhaCungCap(string mancc)
        {
            string caulenh = "UPDATE NhaCungCap set TrangThai = 0 WHERE MaNCC = '" + mancc + "' ";
            try
            {
                SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
                int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(string.Format(caulenh, mancc), conn);
                return kq != 0;
            }
            catch
            {
                return false;
            }
        }

        public string TangNhaCungCap()
        {
            string caulenh = "SELECT MAX(MaNCC) FROM NhaCungCap";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            if(dr.Read())
            {
                if(!dr.IsDBNull(0))
                {
                    int ncc = Convert.ToInt32(dr.GetString(0).Remove(0, 3));
                    ncc++;
                    dr.Close();
                    conn.Close();
                    return "NCC" + ncc.ToString("d4");
                }
            }
            return "NCC0001";
        }
    }
}
