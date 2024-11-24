using System;
using System.Collections.Generic;

namespace QuanLyBHXH
{
    public class GiaiDoanDongBHXH
    {
        public string TuThangNam { get; set; } 
        public string DenThangNam { get; set; } 
        public double MucLuong { get; set; } 

        public override string ToString()
        {
            return $"Tu {TuThangNam} - den {DenThangNam} - Muc luong: {MucLuong:N0}";
        }
    }

    public class NguoiLaoDong
    {
        public string MaBHXH { get; set; } 
        public string HoTen { get; set; }
        public string GioiTinh { get; set; } 
        public DateTime NgaySinh { get; set; }
        public List<GiaiDoanDongBHXH> CacGiaiDoanDong { get; set; }

        public NguoiLaoDong()
        {
            CacGiaiDoanDong = new List<GiaiDoanDongBHXH>();
        }

        public override string ToString()
        {
            return $"Ma BHXH: {MaBHXH}, Ho ten: {HoTen}, Gioi tinh: {GioiTinh}, Ngay sinh: {NgaySinh:dd/MM/yyyy}";
        }
    }
}
