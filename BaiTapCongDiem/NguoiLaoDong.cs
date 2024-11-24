using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBHXH
{
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

        public double TinhTienBHXH1Lan()
        {
            int thoiGianTruoc2014 = CacGiaiDoanDong
                .Where(gd => DateTime.ParseExact(gd.DenThangNam, "MM/yyyy", null).Year < 2014)
                .Sum(gd => TinhSoThang(gd.TuThangNam, gd.DenThangNam));

            int thoiGianSau2014 = CacGiaiDoanDong
                .Where(gd => DateTime.ParseExact(gd.DenThangNam, "MM/yyyy", null).Year >= 2014)
                .Sum(gd => TinhSoThang(gd.TuThangNam, gd.DenThangNam));

            int tongSoThangDong = thoiGianTruoc2014 + thoiGianSau2014;

            double tongTienLuongDong = CacGiaiDoanDong
                .Sum(gd => TinhSoThang(gd.TuThangNam, gd.DenThangNam) * gd.MucLuong);

            double mbqtl = tongTienLuongDong / tongSoThangDong;

            double mucHuong = mbqtl * ((1.5 * thoiGianTruoc2014) + (2 * thoiGianSau2014));

            return mucHuong;
        }

        private int TinhSoThang(string tuThangNam, string denThangNam)
        {
            DateTime tu = DateTime.ParseExact(tuThangNam, "MM/yyyy", null);
            DateTime den = DateTime.ParseExact(denThangNam, "MM/yyyy", null);

            return ((den.Year - tu.Year) * 12) + (den.Month - tu.Month + 1);
        }

        public override string ToString()
        {
            return $"Ma BHXH: {MaBHXH}, Ho ten: {HoTen}, Gioi tinh: {GioiTinh}, Ngay sinh: {NgaySinh:dd/MM/yyyy}";
        }
    }
}
