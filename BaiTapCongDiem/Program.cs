using System;

namespace QuanLyBHXH
{
    class Program
    {
        static void Main(string[] args)
        {
            var qlbhxh = new QuanLyBHXH();

            while (true)
            {
                Console.WriteLine("\n--- Menu Quan Ly BHXH ---");
                Console.WriteLine("1. Them moi nguoi lao dong");
                Console.WriteLine("2. Them giai doan dong BHXH");
                Console.WriteLine("3. Xuat danh sach");
                Console.WriteLine("4. Thong ke so luong lao dong theo gioi tinh");
                Console.WriteLine("5. Tinh tien BHXH 1 lan");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        qlbhxh.ThemNguoiLaoDong();
                        break;
                    case 2:
                        qlbhxh.ThemGiaiDoanDongBHXH();
                        break;
                    case 3:
                        qlbhxh.XuatDanhSach();
                        break;
                    case 4:
                        qlbhxh.ThongKeGioiTinh();
                        break;
                    case 5:
                        qlbhxh.TinhTienBHXH1Lan();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            }
        }
    }
}
