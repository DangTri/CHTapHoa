using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDAO;
using QLDTO;

namespace QLBUS
{
    public class NhanVienBUS
    {
        NhanVienDAO nhanviendao = new NhanVienDAO();

        public List<NhanVienDTO> DanhSachNhanVien()
        {
            return nhanviendao.DanhSachNhanVien();
        }

        public List<LoaiNhanVienDTO> DanhSachLoaiNhanVien()
        {
            return nhanviendao.DanhSachLoaiNhanVien();
        }

        public bool ThemNhanVien(NhanVienDTO nhanviendto)
        {
            return nhanviendao.ThemNhanVien(nhanviendto);
        }

        public bool SuaNhanVien(NhanVienDTO nhanviendto)
        {
            return nhanviendao.SuaNhanVien(nhanviendto);
        }

        public bool XoaNhanVien(string MaNV)
        {
            return nhanviendao.XoaNhanVien(MaNV);
        }

        public string TangNhanVien()
        {
            return nhanviendao.TangNhanVien();
        }
    
    }
}
