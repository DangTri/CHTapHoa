using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using System.Data.SqlClient;

namespace QLDAO
{
    public class LoaiSanPhamDAO
    {
        public static List<LoaiSanPhamDTO> DanhSachLoaiSanPham()
        {
            List<LoaiSanPhamDTO> lstloaisanpham = new List<LoaiSanPhamDTO>();
            string caulenh = "SELECT * FROM LoaiSanPham";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                LoaiSanPhamDTO loai = new LoaiSanPhamDTO();
                loai.MaLoaiSP = dr[0].ToString();
                loai.TenLoaiSP = dr[1].ToString();
                loai.TrangThai = int.Parse(dr[2].ToString());

                lstloaisanpham.Add(loai);
            }
            return lstloaisanpham;
        }
    }
}
