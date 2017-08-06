using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; }

        public string HoNV { get; set; }

        public string TenNV { get; set; }

        public string MaLoaiNV { get; set; }

        public string MatKhau { get; set; }

        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string DiaChi { get; set; }

        public string SDT { get; set; }

        public double Luong { get; set; }

        public string HinhAnh { get; set; }

        public int TrangThai { get; set; }

        public string HoTenNV
        {
            get { return HoNV + " " + TenNV; }
        }
    }
}
