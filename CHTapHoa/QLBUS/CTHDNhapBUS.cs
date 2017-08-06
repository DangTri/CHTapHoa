using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDAO;
using QLDTO;

namespace QLBUS
{
    public class CTHDNhapBUS
    {
        CTHDNhapDAO cthdnhapdao = new CTHDNhapDAO();

        public List<CTHDNhapDTO> DanhSachChiTietHoaDonNhap(string MaHDN)
        {
            return cthdnhapdao.DSCTHDNhap(MaHDN);
        }

        public bool XoaCTHoaDonNhap(string HoaDonNhapDTO)
        {
            return cthdnhapdao.XoaCTHoaDonNhap(HoaDonNhapDTO);
        }

        public bool ThemCTHoaDonNhap(CTHDNhapDTO CTHoaDonNhapDTO)
        {
            return cthdnhapdao.ThemCTHoaDonNhap(CTHoaDonNhapDTO);
        }
    }
}
