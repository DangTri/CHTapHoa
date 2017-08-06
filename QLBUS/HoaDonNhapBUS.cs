using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDAO;
using QLDTO;

namespace QLBUS
{
    public class HoaDonNhapBUS
    {
        HoaDonNhapDAO hoadonhapdao = new HoaDonNhapDAO();

        public List<HoaDonNhapDTO> DanhSachHoaDonNhap()
        {
            return hoadonhapdao.DSHoaDonNhap();
        }

        public HoaDonNhapDTO LayHDNhapTheoMa(string maHD)
        {
            return hoadonhapdao.LayHoaDonNhapTheoMa(maHD);
        }

        public List<HoaDonNhapDTO> TimDanhSachHoaDonNhap(DateTime tungay, DateTime denngay)
        {
            return hoadonhapdao.TimHoaDonNhap(tungay, denngay);
        }
        public string TangHD()
        {
            return hoadonhapdao.TangHD();
        }

        public bool XoaHoaDonNhap(string HoaDonNhapDTO)
        {
            return hoadonhapdao.XoaHoaDonNhap(HoaDonNhapDTO);
        }

        public int ThemHoaDonNhap(HoaDonNhapDTO HoaDonNhapDTO)
        {
            return hoadonhapdao.ThemHoaDonNhap(HoaDonNhapDTO);
        }
    }
}
