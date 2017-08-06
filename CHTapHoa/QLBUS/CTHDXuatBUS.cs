using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using QLDAO;

namespace QLBUS
{
    public class CTHDXuatBUS
    {
        CTHDXuatDAO cthdxdao = new CTHDXuatDAO();

        public List<CTHDXuatDTO> DSChiTietHoaDonXuat()
        {
            return cthdxdao.DanhSachCTHDXuat();
        }
        public List<CTHDXuatDTO> DanhSachChiTietHoaDonXuat(string MaHD)
        {
            return cthdxdao.DSCTHDXuat(MaHD);
        }

        public bool XoaCTHoaDonNhap(string HoaDonXuatDTO)
        {
            return cthdxdao.XoaCTHoaDonXuat(HoaDonXuatDTO);
        }

        public bool ThemCTHoaDonXuat(CTHDXuatDTO CTHoaDonXuatDTO)
        {
            return cthdxdao.ThemCTHoaDonXuat(CTHoaDonXuatDTO);
        }

    }
}
