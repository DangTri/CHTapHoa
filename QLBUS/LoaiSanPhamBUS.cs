using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using QLDAO;    

namespace QLBUS
{
    public class LoaiSanPhamBUS
    {
        public List<LoaiSanPhamDTO> DSLSanPham()
        {
            return LoaiSanPhamDAO.DanhSachLoaiSanPham();
        }
    }
}
