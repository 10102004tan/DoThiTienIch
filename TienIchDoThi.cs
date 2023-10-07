using System;
using System.ComponentModel;
namespace TienIchDoThi
{

    class TienIchDoThi
    {
        /*FUNCTIONLITY CUA DO THI GOM : 

        #MA TRAN KE
        Fun1 : InMaTran(int[,] maTran)
        Fun2 :  Doc ma tran tu FIle
        Fun3 : Viet xuong ma tran
        Fun4 : Tinh bac cua dinh ma tran ke (int[,] va dinh)
        Fun5 : Tinh va tra ve danh sach bac cua dinh ma tran ke (int [,]) return int [];
        Fun6 : Chuyen thanh danh sach ke

        #MA TRAN TRONG SO
        fun1 : Tinh bac cua dinh
        fun2 : Tinh danh sach bac cua dinh


        #Danh sach ke
        fun1 : Doc file 
        fun2 : Ghi file 
        fun3 : Tinh bac cua danh sach ke
        fun4 : In danh sach ke
        fun4 : Chuyen sang ma tran ke

        #Xet tinh lien thong
        fun1 : Xet tinh lien thong cau danh sach ke
        fun2 : Xet tinh lien thong cua ma tran ke

        #Chu trinh euler va duong di euler

        */



        // MA TRAN KE
        // in ma tran
        public static void InMaTran(int[,] maTran)
        {
            for (int i = 0; i < maTran.GetLength(0); i++)
            {
                for (int j = 0; j < maTran.GetLength(1); j++)
                {
                    System.Console.Write(maTran[i, j] + " ");
                }
                System.Console.WriteLine();
            }
        }

        //doc ma tran tu file
        public static int[,] DocMaTranTuFile(string path)
        {
            int soDinh = 0;
            int[,] maTran;
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    soDinh = int.Parse(streamReader.ReadLine());
                    maTran = new int[soDinh, soDinh];


                    for (int i = 0; i < maTran.GetLength(0); i++)
                    {
                        // convert item in arrSt type string to int
                        string[] arrSt = streamReader.ReadLine().Split(',');
                        for (int j = 0; j < arrSt.Length; j++)
                        {
                            maTran[i, j] = int.Parse(arrSt[j]);
                        }
                    }

                    return maTran;
                }
            }
            catch (System.Exception)
            {

                System.Console.WriteLine("Read from file not ok");
            }
            return null;
        }

        //ghi ma tran ke
        public static bool GhiMaTranKeXuongFile(int[,] maTran, string path)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {

                    streamWriter.WriteLine(maTran.GetLength(0));// ghi xuong so luong phan tu


                    // Ghi xuong item
                    for (int i = 0; i < maTran.GetLength(0); i++)
                    {
                        string line = "";
                        for (int j = 0; j < maTran.GetLength(1); j++)
                        {
                            line = (j == (maTran.GetLength(1) - 1)) ? line += (maTran[i, j]) : line += (maTran[i, j] + ",");
                        }
                        streamWriter.WriteLine(line);
                    }

                    return true;
                }
            }
            catch (System.Exception)
            {

                System.Console.WriteLine("Write from file not ok");
            }
            return false;
        }

        // Fun4 : Tinh bac cua dinh ma tran ke (int[,] va dinh)
        public static int TinhBacCuaDinhMaTranKKe(int[,] maTran, int dinh)
        {
            /*
        ^-> 0 1 2 3  
        0   0 1 1 0
        1   1 0 0 1
        2   1 0 0 1
        3   0 1 1 0

        exemple : 
        Dinh 0 : co bac la : 2


            */
            int bac = 0;

            for (int i = 0; i < maTran.GetLength(1); i++)
            {
                bac += maTran[dinh, i];
            }
            return bac;
        }

        //Fun5 : Tinh va tra ve danh sach bac cua dinh ma tran ke (int [,]) return int [];
        public static int[] TaoDanhSachBacCuaDinhMaTranKe(int[,] maTran)
        {
            int[] danhSachBac = new int[maTran.GetLength(0)];

            for (int i = 0; i < maTran.GetLength(0); i++)
            {
                danhSachBac[i] = TinhBacCuaDinhMaTranKKe(maTran, i);
            }

            return danhSachBac;
        }

        /*CHUYEN DOI MA TRAN KKE SANG DANH SACH KE
        ^-> 0 1 2 3  
        0   0 1 1 0
        1   1 0 0 1
        2   1 0 0 1
        3   0 1 1 0

        => Danh sach ke sau kh ichuyen la : 
        Dinh 0 : 1 2
        Dinh 1 : 1 4
        Dinh 2 : 1 4
        Dinh 3 : 2 3

        Luu y : Vi chua biet so luong item nen kkhong the dung array, ma thay vao do co the dung LinkList hoac List

        */

        public static List<List<int>> ChuyenMaTranKeSangDanhSachKe(int[,] maTranKe)
        {
            List<List<int>> danhSachKe = new List<List<int>>();

            for (int i = 0; i < maTranKe.GetLength(0); i++)
            {
                danhSachKe.Add(new List<int>());
                for (int j = 0; j < maTranKe.GetLength(1); j++)
                {
                    if (maTranKe[i, j] != 0)
                    {
                        danhSachKe[i].Add(j);
                    }
                }
            }

            return danhSachKe;
        }





        //MA TRAN TRONG SO
        /*BAC CUA DINH TRONG MA TRAN TRONG SO
        Dieu kien : MaTRan[i,j] != 0 => bac++;
        */
        public static int TinhBacCuaDinhTrongMaTranTrongSo(int[,] maTran, int dinh)
        {
            int bac = 0;
            for (int i = 0; i < maTran.GetLength(1); i++)
            {
                if (maTran[dinh, i] != 0)
                {
                    bac++;
                }
            }

            return bac;
        }

        //tao danh sach bac cua dinh trong ma tran trong so
        public static int[] TaoDanhSachBacCuaDinhTrongMaTranTrongSo(int[,] maTran)
        {
            int[] danhSachBac = new int[maTran.GetLength(0)];
            for (int i = 0; i < maTran.GetLength(0); i++)
            {
                danhSachBac[i] = TinhBacCuaDinhTrongMaTranTrongSo(maTran, i);
            }

            return danhSachBac;
        }



        /*DANH SACH KE
        Dinh 0 : 1 2
        Dinh 1 : 1 4
        Dinh 2 : 1 4
        Dinh 3 : 2 3  


        fun1 : Doc file 
        fun2 : Ghi file 
        fun3 : Tinh bac cua danh sach ke
        fun4 : In danh sach ke
        fun4 : Chuyen sang ma tran ke   
        */

        //Doc file danh sach ke
        public static List<List<int>> TaoDanhSachKeTuFile(string path)
        {
            int soDinh = 0;
            List<List<int>> danhSachKe = new List<List<int>>();

            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    soDinh = int.Parse(streamReader.ReadLine());

                    for (int i = 0; i < soDinh; i++)
                    {

                        danhSachKe.Add(new List<int>());
                        string[] arrSt1 = streamReader.ReadLine().Split(":"); // lay cac phan tu danh sach ke
                        string[] arrSt2 = arrSt1[1].Split(",");

                        for (int j = 0; j < arrSt2.Length; j++)
                        {
                            danhSachKe[i].Add(int.Parse(arrSt2[j]));
                        }
                    }

                    return danhSachKe;

                }
            }
            catch (System.Exception)
            {

               System.Console.WriteLine("Doc file danh sach ke khong thanh cong");
            }
            return null;
        }

        //ghi file
        public static bool GhiDanhSachKeVaoFile(List<List<int>> danhSachKe,string path)
        {
            try
            {
                using(StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine(danhSachKe.Count);

                    for (int i = 0 ; i < danhSachKe.Count ; i++)
                    {
                        string line = "";
                        for (int j = 0 ; j < danhSachKe[i].Count ; j++)
                        {
                            line = (j == danhSachKe[i].Count -1) ? line+=danhSachKe[i][j] : line+=danhSachKe[i][j] + ",";
                        }
                        streamWriter.WriteLine((i + 1) + ":" + line);
                    }

                    return true;
                }
            }
            catch (System.Exception)
            {
                
                System.Console.WriteLine("Ghi file danh sach ke khong thanh cong");
            }
            return false;
        }

        /*BAC CUA DANH SACH KE : La so luong dinh cua cua dinh
        
        */
        public static int TinhBacCuaDinhDanhSachKe(List<List<int>> danhSachKe,int dinh)
        {
            return danhSachKe[dinh].Count;
        }

        // yao danh sach bac cua dinh trong danh sach ke

        public static int [] TaoDanhSachBacCuaDinhTrongDanhSachKe(List<List<int>> danhSachKe)
        {
            int [] dsBac = new int [danhSachKe.Count];

            for (int i = 0; i < danhSachKe.Count; i++)
            {
                dsBac[i] = TinhBacCuaDinhDanhSachKe(danhSachKe,i);
            }
            return dsBac;
        }

        //In danh sach ke
        public static void InDanhSachKe(List<List<int>> danhSachKe)
        {
            int i = 0;
            foreach (List<int> items in danhSachKe)
            {
                System.Console.Write($"Dinh {i} : ");
                foreach (int item in items)
                {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
            }
        }

        /*CHUYEN DOI DANH SACH KE SANG MA TRAN KE

        => Danh sach ke 
        Dinh 0 : 1 2
        Dinh 1 : 1 4
        Dinh 2 : 1 4
        Dinh 3 : 2 3

        => Ma tran ke :
        0 1 1 0 
        0 1 0 1
        0 1 0 1
        0 0 1 1
        */


        //main
        static void Main(string[] args)
        {
            // ma tran ke
            int[,] maTranKe = DocMaTranTuFile("maTranKe.txt");
            System.Console.WriteLine("Ghi file : " + GhiMaTranKeXuongFile(maTranKe, "testGhiMaTranKKe.txt"));
            InMaTran(maTranKe);
            int[] danhSachBacCuaDinh = TaoDanhSachBacCuaDinhMaTranKe(maTranKe);
            InDanhSachBacCuaDinh(danhSachBacCuaDinh);
            List<List<int>> danhSachKe = ChuyenMaTranKeSangDanhSachKe(maTranKe);
            InDanhSachKe(danhSachKe);

            //ma tran trong so
            int[,] maTranTrongSo = DocMaTranTuFile("maTranTrongSo.txt");
            InMaTran(maTranTrongSo);
            int[] danhSachBacCuaDinhMTTrongSo = TaoDanhSachBacCuaDinhTrongMaTranTrongSo(maTranTrongSo);
            InDanhSachBacCuaDinh(danhSachBacCuaDinhMTTrongSo);




        }

        static void InDanhSachBacCuaDinh(int[] dsBac)
        {
            for (int i = 0; i < dsBac.Length; i++)
            {
                System.Console.WriteLine($"Dinh {i} co bac la : " + dsBac[i]);
            }
        }

        
    }
}