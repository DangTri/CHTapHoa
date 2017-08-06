using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace QLDAO
{
    class DataProvider_QLCHTapHoa
    {
        //DESKTOP-RPV8OEV
        public static string strChuoiKetNoi = @"Data Source = VIVIAN\VIVIAN;Initial Catalog=CHTapHoaSSS;Integrated Security=True";

        //Kết nối đến CSDL
        public static SqlConnection TaoKetNoi()
        {
            SqlConnection conn = new SqlConnection(strChuoiKetNoi);
            conn.Open();
            return conn;
        }

        //Truy vấn CSDL bằng câu lệnh
        public static SqlDataReader TruyVanDuLieu(string strCauTruyVan, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand(strCauTruyVan, conn);
            SqlDataReader sdr = com.ExecuteReader();
            return sdr;
        }

        //Thực thi theo câu lệnh
        public static int ThucThiCauLenh(string strCaulenh, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand(strCaulenh, conn);
            return com.ExecuteNonQuery();
        }
    }
}
