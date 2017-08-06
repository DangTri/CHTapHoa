using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using System.Data.SqlClient;

namespace QLDAO
{
    public class LoaiNhanVienDAO
    {
        public static List<LoaiNhanVienDTO> DanhSachLoaiNhanVien()
        {
            List<LoaiNhanVienDTO> lstloainhanvien = new List<LoaiNhanVienDTO>();
            string caulenh = "SELECT * FROM LoaiNhanVien";
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            SqlDataReader dr = DataProvider_QLCHTapHoa.TruyVanDuLieu(caulenh, conn);
            while (dr.Read())
            {
                LoaiNhanVienDTO loai = new LoaiNhanVienDTO();
                loai.MaLoaiNV = dr[0].ToString();
                loai.LoaiNV = dr[1].ToString();
                loai.TrangThai = int.Parse(dr[2].ToString());

                lstloainhanvien.Add(loai);
            }
            return lstloainhanvien;
        }
    }
}
