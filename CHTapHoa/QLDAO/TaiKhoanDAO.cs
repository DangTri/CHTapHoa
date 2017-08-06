using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QLDAO
{
    public class TaiKhoanDAO
    {
        public int DoiMatKhauDAO(string manv,string matkhau)
        {
            SqlConnection conn = DataProvider_QLCHTapHoa.TaoKetNoi();
            string query = "Update NhanVien set MatKhau= N'" + matkhau + "' where MaNV='" + manv + "'";
            int kq = DataProvider_QLCHTapHoa.ThucThiCauLenh(query,conn);
            return kq;
        }
    }
}
