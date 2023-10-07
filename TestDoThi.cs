using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TienIchDoThi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestMaTranKe();
            //TestMaTranTrongSo();
            //TestDSKe();
            TestEuler();
        }
        static void TestDSKe()
        {
            LinkedList<int>[] dsKe = new LinkedList<int>[7];
            dsKe[0] = new LinkedList<int>();
            dsKe[0].AddLast(1);
            dsKe[0].AddLast(2);
            dsKe[0].AddLast(3);

            dsKe[1] = new LinkedList<int>();
            dsKe[1].AddLast(0);
            dsKe[1].AddLast(2);
            dsKe[1].AddLast(3);
            dsKe[1].AddLast(4);

            dsKe[2] = new LinkedList<int>();
            dsKe[2].AddLast(0);
            dsKe[2].AddLast(1);
            dsKe[2].AddLast(4);


            dsKe[3] = new LinkedList<int>();
            dsKe[3].AddLast(0);
            dsKe[3].AddLast(1);
            //dsKe[3].AddLast(4); //
            dsKe[3].AddLast(5);

            dsKe[4] = new LinkedList<int>();
            dsKe[4].AddLast(1);
            dsKe[4].AddLast(2);
            //dsKe[4].AddLast(3); //
            dsKe[4].AddLast(5);

            dsKe[5] = new LinkedList<int>();
            dsKe[5].AddLast(3);
            dsKe[5].AddLast(4);

            dsKe[6] = new LinkedList<int>();

            Console.WriteLine("\t\tDANH SACH KE CUA MA TRAN");
            TienIchDoThi.InDSKe(dsKe);
            Console.WriteLine();

            //input
            Console.WriteLine("\t\tDANH SACH KE CUA MA TRAN GHI XUONG FILE");
            TienIchDoThi.VietDSKeXuongFile("DS_KE.txt", dsKe);
            Console.WriteLine();

            //output
            Console.WriteLine("\t\tDANH SACH KE CUA MA TRAN DOC TU FILE");
            LinkedList<int>[] dsKeDocDuoc = TienIchDoThi.DocDSKeTuFile("DS_KE.txt");
            TienIchDoThi.InDSKe(dsKeDocDuoc);
            Console.WriteLine();

            //in ra so bac cua dinh
            Console.WriteLine("\t\tBAC CUA CAC DINH TRONG DANH SACH KE");
            for (int i = 0; i < dsKeDocDuoc.Length; i++)
            {
                Console.WriteLine($"So bac cua dinh {i}: {TienIchDoThi.TinhBacCuaDinh(dsKeDocDuoc, i)}");
            }
            Console.WriteLine();

            //chuyen danh sach ke thanh ma tran ke
            Console.WriteLine("\t\tMA TRAN KE TUONG UNG");
            int[,] mtKe = TienIchDoThi.ChuyenThanhMaTranKe(dsKeDocDuoc);

            TienIchDoThi.InMaTran(mtKe);
            Console.WriteLine();

            //xet tinh lien thong do thi
            Console.WriteLine("\t\tXET TINH LIEN THONG");
            Console.WriteLine("Tinh lien thong: " + TienIchDoThi.XetTinhLienThong(dsKeDocDuoc));
            Console.WriteLine();
        }

        static void TestMaTranKe()
        {
            int[,] mtKe = new int[,]
            {
                { 0, 1, 1, 0, 1 },
                { 1, 0, 1, 1, 1 },
                { 1, 1, 0, 0, 1 },
                { 0, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 0 }
            };


            //output
            Console.WriteLine("\t\tMA TRAN KE");
            TienIchDoThi.InMaTran(mtKe);
            Console.WriteLine();

            //ghi ma tran xuong file
            Console.WriteLine("\t\tVIET MA TRAN KE XUONG FILE");
            TienIchDoThi.VietMaTranXuongFile(@"dothi.txt", mtKe);
            Console.WriteLine();

            //doc ma tran tu file
            mtKe = TienIchDoThi.DocMaTranTuFile(@"dothi.txt");
            Console.WriteLine("\t\tMA TRAN KE DOC TU FILE: ");
            TienIchDoThi.InMaTran(mtKe);
            Console.WriteLine();

            //tinh so bac cua dinh
            Console.WriteLine("\t\tBAC CUA DINH: ");
            for (int i = 0; i < mtKe.GetLength(0); i++)
            {
                Console.WriteLine($"Bac cua dinh {i}: " + TienIchDoThi.TinhBacCuaDinhMaTranKe(mtKe, i));
            }
            Console.WriteLine();

            Console.WriteLine("\t\tDANH SACH BAC CUA DINH: ");
            int[] dsBac = TienIchDoThi.TinhBacCuaDinhMaTranKe(mtKe);
            for (int i = 0; i < dsBac.GetLength(0); i++)
            {
                Console.Write(dsBac[i] +" ");
            }
            Console.WriteLine();

            //chuyen thanh danh sach ke
            Console.WriteLine("\t\tDANH SACH KE: ");
            LinkedList<int>[] dsKe = TienIchDoThi.ChuyenThanhDanhSachKe(mtKe);
            TienIchDoThi.InDSKe(dsKe);
            Console.WriteLine();

            //xet tinh lien thong
            Console.WriteLine("\t\tXET TINH LIEN THONG");
            Console.WriteLine("Tinh lien thong: " + TienIchDoThi.XetTinhLienThong(mtKe));
            Console.WriteLine();
        }

        static void TestMaTranTrongSo()
        {
            int[,] mtTrongSo = new int[,]
            {
                { 0, 3, 5, 0, 1 },
                { 3, 0, 1, 6, 1 },
                { 5, 1, 0, 0, 1 },
                { 0, 6, 0, 0, 4 },
                { 1, 1, 1, 4, 0 }
            };

            //tinh bac cua dinh cho ma tran trong so
            Console.WriteLine("\t\tBAC CUA DINH (MA TRAN TRONG SO");

            for (int i = 0; i < mtTrongSo.GetLength(0); i++)
            {
                Console.WriteLine($"Dinh {i} co bac : {TienIchDoThi.TinhBacCuaDinh(mtTrongSo, i)}");
            }
            Console.WriteLine();

            Console.WriteLine("\t\tDANH SACH BAC CUA DINH: ");
            int[] dsBac = TienIchDoThi.TinhBacCuaDinh(mtTrongSo);
            for (int i = 0; i < dsBac.GetLength(0); i++)
            {
                Console.Write(dsBac[i] + " ");
            }
            Console.WriteLine();
        }

        static void TestEuler()
        {
            //khoa bao
            LinkedList<int>[] dsKe = new LinkedList<int>[6];
            dsKe[0] = new LinkedList<int>();
            dsKe[0].AddLast(1);
            dsKe[0].AddLast(5);

            dsKe[1] = new LinkedList<int>();
            dsKe[1].AddLast(0);
            dsKe[1].AddLast(2);
            dsKe[1].AddLast(4);
            dsKe[1].AddLast(5);

            dsKe[2] = new LinkedList<int>();
            dsKe[2].AddLast(1);
            dsKe[2].AddLast(3);
            dsKe[2].AddLast(4);
            dsKe[2].AddLast(5);


            dsKe[3] = new LinkedList<int>();
            dsKe[3].AddLast(2);
            dsKe[3].AddLast(4);

            dsKe[4] = new LinkedList<int>();
            dsKe[4].AddLast(1);
            dsKe[4].AddLast(2);
            dsKe[4].AddLast(3);
            dsKe[4].AddLast(5);

            dsKe[5] = new LinkedList<int>();
            dsKe[5].AddLast(0);
            dsKe[5].AddLast(1);
            dsKe[5].AddLast(2);
            dsKe[5].AddLast(4);

            //in danh sach ke
            Console.WriteLine("\t\tDANH SACH KE CUA DO THI");
            TienIchDoThi.InDSKe(dsKe);
            Console.WriteLine();

            //kiem tra do thi co chu trinh, duong di euler
            Console.WriteLine("\t\tKIEM TRA DO THI CO CHU TRINH, DUONG DI EULER");
            switch (TienIchDoThi.KiemTraEuler(dsKe))
            {
                case 0:
                    Console.WriteLine("Khong co duong di hay chu trinh Euler");
                    break;
                case 1:
                    Console.WriteLine("Do thi co duong di Euler");
                    break;
                case 2:
                    Console.WriteLine("Do thi co chu trinh Euler");
                    break;
                default:
                    break;
            }
            Console.WriteLine();

            //tim chu trinh Euler bang thuat toan Fleury
            Console.WriteLine("\t\tTIM CHU TRINH EULER");
            int[] chuTrinh = TienIchDoThi.TimChuTrinhEuler(dsKe);
            for (int i = 0; i < chuTrinh.Length; i++)
            {
                Console.Write($"{chuTrinh[i]:00}  ");
            }
            Console.WriteLine();
        }
    }
}
