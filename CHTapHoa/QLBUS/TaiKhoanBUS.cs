using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDAO;

namespace QLBUS
{
    public class TaiKhoanBUS
    {
        TaiKhoanDAO tk = new TaiKhoanDAO();
        public int DoiMatKhauBUS(string manv,string matkhau)
        {
            return tk.DoiMatKhauDAO(manv, matkhau);
        }
    }
}
