using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDTO
{
    public class HoaDonXuatDTO
    {
        public string MaHDX { get; set; }

        public string MaNV { get; set; }

        public string MaKH { get; set; }
        public string TenKH { get; set; }

        public DateTime NgayXuat { get; set; }

        public int TongTien { get; set; }

        public int TrangThai { get; set; }
    }
}
