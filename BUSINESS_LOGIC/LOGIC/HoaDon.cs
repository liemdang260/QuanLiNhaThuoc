using System;
using System.Collections.Generic;
using System.Text;
using DATA;
using System.Data;

namespace LOGIC
{
    public class HoaDon
    {
        private string tenKH;
        private string tenNV;
        private float triGia;
        private DateTime ngayLap;
        private string phuongThucThanhToan;
        private string maGiamGia;

        public HoaDon(DateTime ngaylap,string tenkh = "", string tennv="", float trigia = 0,string pttt = "1",string magg = "")
        {
            if (ngaylap == null)
            {
                ngayLap = DateTime.Now;
            }
            else
                ngayLap = ngaylap;
            tenKH = tenkh;
            tenNV = tennv;
            triGia = trigia;
            phuongThucThanhToan = pttt;
            maGiamGia = magg;
        }

        public List<HoaDon> SelectAllHD()
        {
            List<HoaDon> list = new List<HoaDon>();
            DataTable tb = KetNoiSQL.Query("SELECT * FROM HOADON");
            foreach(DataRow row in tb.Rows)
            {
                DateTime ngl = DateTime.Parse(row["NGAYLAPHD"].ToString());
                HoaDon hd = new HoaDon(
                    ngaylap: ngl,
                    tenkh: row["MAKH"].ToString(),
                    tennv: row["MANV"].ToString(),
                    trigia: float.Parse(row["TRIGIA"].ToString()),
                    pttt: row["PGUONGTHUCTHANHTOAN"].ToString(),
                    magg: row["MAGIAMGIA"].ToString()
                );
                list.Add(hd);
            }
            return list;
        }
    }
}
