using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDTO;
using QLDAO;

namespace QLBUS
{
    public class NhaCungCapBUS
    {
        NhaCungCapDAO ncc = new NhaCungCapDAO();

        public List<NhaCungCapDTO> LayNhaCungCap()
        {
            return NhaCungCapDAO.DanhSachNhaCungCap();
        }

        public bool ThemNhaCungCap(NhaCungCapDTO nccdto)
        {
            return ncc.ThemNhaCungCap(nccdto);
        }

        public bool SuaNhaCungCap(NhaCungCapDTO nccdto)
        {
            return ncc.SuaNhaCungCap(nccdto);
        }

        public bool XoaNhaCungCap(string mancc)
        {
            return ncc.XoaNhaCungCap(mancc);
        }

        public string TangNhaCungCap()
        {
            return ncc.TangNhaCungCap();
        }
    }
}
