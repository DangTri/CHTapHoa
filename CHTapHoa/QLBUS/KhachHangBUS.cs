using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using QLDAO;

namespace QLBUS
{
    public class KhachHangBUS
    {
        KhachHangDAO khdao = new KhachHangDAO();

        public List<KhachHangDTO> DanhSachKhachHang()
        {
            return khdao.DanhSachKhachHang();
        }

        public KhachHangDTO LayKHTheoMa(string maKH)
        {
            return khdao.LayKHTheoMa(maKH);
        }

        public bool ThemKhachHang(KhachHangDTO khachhangdto)
        {
            return khdao.ThemKhachhang(khachhangdto);
        }

        public bool SuaKhachHang(KhachHangDTO khachhangdto)
        {
            return khdao.SuaKhachHang(khachhangdto);
        }

        public bool XoaKhachHang(string makh)
        {
            return khdao.XoaKhachHang(makh);
        }
            
        public string TangKhachHang()
        {
            return khdao.TangKhachHang();
        }
    }
}
