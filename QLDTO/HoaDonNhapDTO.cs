using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDTO
{
    public class HoaDonNhapDTO
    {
        public string MaHDN { get; set; }

        public string MaNV { get; set; }

        public DateTime NgayNhap { get; set; }

        public double TongTien { get; set; }

        public int TrangThai { get; set; }
    }
}
