using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using QLDAO;

namespace QLBUS
{
    public class HoaDonXuatBUS
    {
        HoaDonXuatDAO hoadonxuatdao = new HoaDonXuatDAO();

        public List<HoaDonXuatDTO> DanhSachHoaDonXuat()
        {
            return hoadonxuatdao.DSHoaDonXuat();
        }

        public HoaDonXuatDTO LayHDTheoMa(string maHD)
        {
            return hoadonxuatdao.LayHoaDonTheoMa(maHD);
        }

        public List<HoaDonXuatDTO> LayHDTheoMaNhanVien(string maNV)
        {
            return hoadonxuatdao.LayHoaDonTheoMaNhanVien(maNV);
        }

        public List<HoaDonXuatDTO> TimDanhSachHoaDon(DateTime tungay, DateTime denngay)
        {
            return hoadonxuatdao.TimDanhSachHoaDon(tungay, denngay);
        }
        public string TangHD()
        {
            return hoadonxuatdao.TangHD();
        }

        public bool XoaHoaDonXuat(string HoaDonXuatDTO)
        {
            return hoadonxuatdao.XoaHoaDonXuat(HoaDonXuatDTO);
        }

        public int themHoaDon(HoaDonXuatDTO hoadonxuatDTO)
        {
            return hoadonxuatdao.ThemHoaDon(hoadonxuatDTO);
        }
    }
}
