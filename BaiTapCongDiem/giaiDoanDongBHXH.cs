using System;

namespace QuanLyBHXH
{
    public class GiaiDoanDongBHXH
    {
        public string TuThangNam { get; set; }
        public string DenThangNam { get; set; }
        public double MucLuong { get; set; }

        public override string ToString()
        {
            return $"Tu {TuThangNam} - Den {DenThangNam} - Muc luong: {MucLuong:N0}";
        }
    }
}
