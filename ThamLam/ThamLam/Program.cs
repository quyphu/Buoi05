using System;
using System.Collections.Generic;
using System.Linq;

namespace ThamLam
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List<DenTien> danhSachDenTien = new List<DenTien>
            {
                new DenTien { GiaTri = 1, Ten = "xu 1" },
                new DenTien { GiaTri = 5, Ten = "xu 5" },
                new DenTien { GiaTri = 10, Ten = "xu 10" },
                new DenTien { GiaTri = 25, Ten = "xu 25" },
                new DenTien { GiaTri = 50, Ten = "xu 50" }
            };

            int soTienCanPhanChia = 87; 

            var ketQua = PhanChiaTien(soTienCanPhanChia, danhSachDenTien);

            Console.WriteLine("Ket Qua Chia Tien:");
            foreach (var item in ketQua)
            {
                Console.WriteLine("So Luong: " + item.SoLuong + ", " + item.Ten);

            }

            Console.ReadKey();
        }

        public class DenTien
        {
            public int GiaTri { get; set; }
            public string Ten { get; set; }
        }

        public class KetQuaPhanChia
        {
            public string Ten { get; set; }
            public int SoLuong { get; set; }
        }

        public static List<KetQuaPhanChia> PhanChiaTien(int soTien, List<DenTien> danhSachDenTien)
        {
            
            danhSachDenTien.Sort((x, y) => y.GiaTri.CompareTo(x.GiaTri));

            List<KetQuaPhanChia> ketQua = new List<KetQuaPhanChia>();

            foreach (var denTien in danhSachDenTien)
            {
                if (soTien >= denTien.GiaTri)
                {
                    int soLuong = soTien / denTien.GiaTri;
                    soTien -= soLuong * denTien.GiaTri;
                    ketQua.Add(new KetQuaPhanChia { Ten = denTien.Ten, SoLuong = soLuong });
                }
            }

            return ketQua;
        }
    }
}
