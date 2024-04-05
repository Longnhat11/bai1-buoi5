using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1_buoi5
{
    public struct NhanVien
    {
        public string MaNhanVien;
        public string HoDem;
        public string Ten;
        public DateTime NgaySinh;
        public DateTime NgayVaoLam;
    }
    internal class Program
    {
        public static List<NhanVien> NhapNhanVien(List<NhanVien>NhanvienNhap )
        {          
            Console.Write("Nhap so luong nhan vien: ");
            string SoNhanvienVao = Console.ReadLine();
            int TongNhanvien;
            bool Tongnvlaso = int.TryParse(SoNhanvienVao, out TongNhanvien);
            while (Tongnvlaso == false)
            {
                Console.WriteLine("ban nhap khong phai so! xin moi nhap lai:");
                SoNhanvienVao = Console.ReadLine();
                Tongnvlaso = int.TryParse(SoNhanvienVao, out TongNhanvien);
                if ((TongNhanvien < 0) && (TongNhanvien > 2147483647) && (Tongnvlaso == true))
                {
                    Console.WriteLine("ban nhap so khong trong khoang int, xin moi nhap lai.");
                    Tongnvlaso = false;
                }
            }

            for (int i = 0; i < TongNhanvien; i++)
            {
                NhanVien nv = new NhanVien();

                Console.Write("Nhap ma nhan vien: ");
                nv.MaNhanVien = Console.ReadLine();

                Console.Write("Nhap ho dem: ");
                nv.HoDem = Console.ReadLine();

                Console.Write("Nhap ten: ");
                nv.Ten = Console.ReadLine();

                Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
                string NgaySinhvao = Console.ReadLine();
                DateTime NgaySinh;
                bool langay = DateTime.TryParseExact(NgaySinhvao, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out NgaySinh);
                while (langay == false)
                {
                    Console.WriteLine("ban nhap khong dung dinh dang, xin moi nhap lai!");
                    NgaySinhvao = Console.ReadLine();
                    langay = DateTime.TryParseExact(NgaySinhvao, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out NgaySinh);
                }
                nv.NgaySinh = NgaySinh;
                Console.Write("Nhap ngay vao lam (dd/MM/yyyy): ");
                string Ngayvao = Console.ReadLine();
                DateTime ngayvaolam;
                bool Isday = DateTime.TryParseExact(Ngayvao, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out ngayvaolam);
                while (Isday == false)
                {
                    Console.WriteLine("ban nhap khong dung dinh dang, xin moi nhap lai!");
                    Ngayvao = Console.ReadLine();
                    Isday = DateTime.TryParseExact(Ngayvao, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out ngayvaolam);
                }
                nv.NgayVaoLam = ngayvaolam;
                NhanvienNhap.Add(nv);
            }

            return NhanvienNhap;
        }
        public static void HienThiDanhSach(List<NhanVien> danhSach)
        {
            foreach (var nv in danhSach)
            {
                Console.WriteLine($"Ma NV: {nv.MaNhanVien}, Ho dem: {nv.HoDem}, Ten: {nv.Ten}, Ngay sinh: {nv.NgaySinh.ToString("dd/MM/yyyy")}, Ngay vao lam: {nv.NgayVaoLam.ToString("dd/MM/yyyy")}");
            }
        }
        public static void SapXepTheoNgaySinh(List<NhanVien> danhSach)
        {
            danhSach = danhSach.OrderByDescending(nv => nv.NgaySinh).ToList();
            HienThiDanhSach(danhSach);
        }
        public static void InNhanVienLamViec5Nam(List<NhanVien> danhSach)
        {
            Console.WriteLine("Danh sach nhan vien co so nam lam viec >= 5:");
            foreach (var nv in danhSach)
            {
                if ((DateTime.Now.Year - nv.NgayVaoLam.Year) >= 5)
                {
                    Console.WriteLine($"Ma NV: {nv.MaNhanVien}, Ho dem: {nv.HoDem}, Ten: {nv.Ten}, Ngay sinh: {nv.NgaySinh.ToString("dd/MM/yyyy")}, Ngay vao lam: {nv.NgayVaoLam.ToString("dd/MM/yyyy")}");
                }
            }
        }
        static void Main(string[] args)
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            Console.WriteLine("dau tien ban phai nhap thong tin nhan vien va so luong nhan vien!");
            NhapNhanVien(nhanViens);
            Console.WriteLine("xin moi nhap lua chon cua ban:");
            Console.WriteLine("1.Hien thi danh sach sinh vien.");
            Console.WriteLine("2.Sap xep anh sach theo ngay sinh giam dan.");
            Console.WriteLine("3. in nhan vien lam viec tren 5 nam.");
            string Sochon = Console.ReadLine();
            int So;
            bool Laso = int.TryParse(Sochon, out So);
            while (Laso == false)
            {
                Console.WriteLine("ban nhap khong phai so! xin moi nhap lai:");
                Sochon = Console.ReadLine();
                Laso = int.TryParse(Sochon, out So);
                if ((So < 0) && (So > 3) && (Laso == true))
                {
                    Console.WriteLine("ban nhap so khong trong khoang chon, xin moi nhap lai.");
                    Laso = false;
                }
            }
            switch (So)
            {
                case 1:
                HienThiDanhSach(nhanViens); break;
                case 2:
                SapXepTheoNgaySinh(nhanViens); break;
                case 3:
                InNhanVienLamViec5Nam(nhanViens);break;
                default:
                Console.WriteLine("ban nhap khong phai trong danh sach chon!"); break;
            }
            Console.ReadKey();
        }
    }
}
