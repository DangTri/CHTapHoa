using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using QLDAO;

namespace QLBUS
{
    public class LoaiNhanVienBUS
    {
        public List<LoaiNhanVienDTO> LayLoaiNhanVien()
        {
            return LoaiNhanVienDAO.DanhSachLoaiNhanVien();
        }
    }
}
