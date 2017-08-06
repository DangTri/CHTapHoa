using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDAO;
using QLDTO;

namespace QLBUS
{
    public class SanPhamBUS
    {
        SanPhamDAO sanphamdao = new SanPhamDAO();

        public List<SanPhamDTO> DanhSachSanPham()
        {
            return sanphamdao.DanhSachSanPham();
        }

        public List<SanPhamDTO> DanhSachSanPhamHetHang()
        {
            return sanphamdao.DanhSachSanPhamHetHang();
        }

        public List<SanPhamDTO> DanhSachSanPhamBanChay()
        {
            return sanphamdao.DanhSachSanPhamBanChay();
        }

        public bool XoaSanPham(string MaSanPham)
        {
            return sanphamdao.XoaSanPham(MaSanPham);
        }

        public bool ThemSanPham(SanPhamDTO sanphamdto)
        {
            return sanphamdao.ThemSanPham(sanphamdto);
        }

        public bool SuaSanPham(SanPhamDTO sanphamdto)
        {
            return sanphamdao.SuaSanPham(sanphamdto);
        }

        public string TangSanPham()
        {
            return sanphamdao.TangSanPham();
        }

        public bool TimSP(string MaSP)
        {
            return sanphamdao.TimMaSP(MaSP);
        }

        public bool TruSL(SanPhamDTO tc1)
        {
            return sanphamdao.TruSL(tc1);
        }

        public bool CongSL(SanPhamDTO tc1)
        {
            return sanphamdao.CongSL(tc1);
        }


    }
}
