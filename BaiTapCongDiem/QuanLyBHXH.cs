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
            string input = Console.ReadLine();
            DateTime ngaySinh;
            while (!DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
            {
                Console.WriteLine("Ngay sinh khong hop le! Vui long nhap lai (dd/MM/yyyy): ");
                input = Console.ReadLine();
            }
            nld.NgaySinh = ngaySinh;

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
            int k;
            while (!int.TryParse(Console.ReadLine(), out k) || k <= 0)
            {
                Console.WriteLine("So giai doan K phai la so nguyen duong. Vui long nhap lai: ");
            }

            for (int i = 0; i < k; i++)
            {
                var giaiDoan = new GiaiDoanDongBHXH();

                Console.Write($"Giai doan {i + 1} - Tu (Thang/Nam, MM/yyyy): ");
                while (true)
                {
                    giaiDoan.TuThangNam = Console.ReadLine();
                    if (DateTime.TryParseExact(giaiDoan.TuThangNam, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
                    {
                        break;
                    }
                    Console.WriteLine("Nhap sai dinh dang. Vui long nhap lai (MM/yyyy): ");
                }

                Console.Write($"Giai doan {i + 1} - Den (Thang/Nam, MM/yyyy): ");
                while (true)
                {
                    giaiDoan.DenThangNam = Console.ReadLine();
                    if (DateTime.TryParseExact(giaiDoan.DenThangNam, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
                    {
                        break;
                    }
                    Console.WriteLine("Nhap sai dinh dang. Vui long nhap lai (MM/yyyy): ");
                }

                Console.Write($"Giai doan {i + 1} - Muc luong: ");
                double mucLuong;
                while (!double.TryParse(Console.ReadLine(), out mucLuong) || mucLuong <= 0)
                {
                    Console.WriteLine("Muc luong phai la so duong. Vui long nhap lai: ");
                }
                giaiDoan.MucLuong = mucLuong;

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
            Console.WriteLine("\n--- Tinh tien BHXH 1 lan ---");
            foreach (var nld in danhSach)
            {
                double tienBHXH = nld.TinhTienBHXH1Lan();
                Console.WriteLine($"Ho ten: {nld.HoTen}, Tien BHXH 1 lan: {tienBHXH:N0}");
            }
        }
    }
}
