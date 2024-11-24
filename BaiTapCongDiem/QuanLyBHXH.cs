using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBHXH
{
    public class QuanLyBHXH
    {
        private List<NguoiLaoDong> danhSach;

        public QuanLyBHXH()
        {
            danhSach = new List<NguoiLaoDong>();
        }

        public void ThemNguoiLaoDong()
        {
            var nld = new NguoiLaoDong();

            Console.Write("Nhap ma so BHXH: ");
            nld.MaBHXH = Console.ReadLine();
            Console.Write("Nhap ho ten: ");
            nld.HoTen = Console.ReadLine();
            Console.Write("Nhap gioi tinh (Nam/Nu): ");
            nld.GioiTinh = Console.ReadLine();
            Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
            nld.NgaySinh = DateTime.Parse(Console.ReadLine());

            danhSach.Add(nld);
            Console.WriteLine("Them moi nguoi lao dong thanh cong!");
        }

        public void ThemGiaiDoanDongBHXH()
        {
            Console.Write("Nhap ma so BHXH: ");
            string maBHXH = Console.ReadLine();
            var nld = danhSach.FirstOrDefault(n => n.MaBHXH == maBHXH);

            if (nld == null)
            {
                Console.WriteLine("Khong tim thay nguoi lao dong voi ma BHXH nay.");
                return;
            }

            Console.Write("Nhap so giai doan K: ");
            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < k; i++)
            {
                var giaiDoan = new GiaiDoanDongBHXH();
                Console.Write($"Giai doan {i + 1} - Tu (Thang/Nam): ");
                giaiDoan.TuThangNam = Console.ReadLine();
                Console.Write($"Giai doan {i + 1} - Den (Thang/Nam): ");
                giaiDoan.DenThangNam = Console.ReadLine();
                Console.Write($"Giai doan {i + 1} - Muc luong: ");
                giaiDoan.MucLuong = double.Parse(Console.ReadLine());

                if (nld.CacGiaiDoanDong.Any(g =>
                    g.TuThangNam == giaiDoan.TuThangNam && g.DenThangNam == giaiDoan.DenThangNam))
                {
                    Console.WriteLine("Giai doan nay da ton tai, khong the them.");
                    continue;
                }

                nld.CacGiaiDoanDong.Add(giaiDoan);
            }

            Console.WriteLine("Them giai doan dong BHXH thanh cong!");
        }

        public void XuatDanhSach()
        {
            Console.WriteLine("\n--- Danh sach nguoi lao dong ---");
            foreach (var nld in danhSach)
            {
                Console.WriteLine(nld);
                foreach (var gd in nld.CacGiaiDoanDong)
                {
                    Console.WriteLine($"  {gd}");
                }
            }
        }

        public void ThongKeGioiTinh()
        {
            int soNam = danhSach.Count(n => n.GioiTinh.Equals("Nam", StringComparison.OrdinalIgnoreCase));
            int soNu = danhSach.Count(n => n.GioiTinh.Equals("Nu", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"So lao dong Nam: {soNam}, Nu: {soNu}");
        }

        public void TinhTienBHXH1Lan()
        {
            foreach (var nld in danhSach)
            {
                double tongTien = nld.CacGiaiDoanDong.Sum(gd => gd.MucLuong * 0.75);
                Console.WriteLine($"Ho ten: {nld.HoTen}, Tien BHXH 1 lan: {tongTien:N0}");
            }
        }
    }
}
