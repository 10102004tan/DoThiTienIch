using System;
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
                    System.Console.Write(maTran[i,j] + " ");
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
                    maTran = new int[soDinh,soDinh];
                    

                    for (int i = 0; i < maTran.GetLength(0); i++)
                    {
                        // convert item in arrSt type string to int
                        string[] arrSt = streamReader.ReadLine().Split(',');
                        for (int j = 0; j < arrSt.Length; j++)
                        {
                            maTran[i,j] = int.Parse(arrSt[j]);
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
        public static bool GhiMaTranKeXuongFile(int[,] maTran,string path)
        {
            try
            {
               using(StreamWriter streamWriter = new StreamWriter(path))
               {
                
                streamWriter.WriteLine(maTran.GetLength(0));// ghi xuong so luong phan tu


                // Ghi xuong item
                for (int i = 0; i < maTran.GetLength(0) ; i++)
                {
                    string line = "";
                    for (int j = 0 ; j <  maTran.GetLength(1) ; j++)
                    {
                        line = (j == (maTran.GetLength(1) - 1)) ? line+=(maTran[i,j]) : line+=(maTran[i,j] + ",");
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
        public static int TinhBacCuaDinhMaTranKKe(int [,] maTran, int dinh)
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

            for (int i = 0 ; i < maTran.GetLength(1) ; i++)
            {
                bac+=maTran[dinh,i];
            }
            return bac;
        }

        //Fun5 : Tinh va tra ve danh sach bac cua dinh ma tran ke (int [,]) return int [];
        public static int[] TaoDanhSachBacCuaDinhMaTranKe(int[,] maTran)
        {
            int [] danhSachBac = new int[maTran.GetLength(0)];

            for (int i = 0 ; i < maTran.GetLength(0) ; i++)
            {
                danhSachBac[i] = TinhBacCuaDinhMaTranKKe(maTran,i);
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
        public static List<List<int>> ChuyenMaTranKeSangDanhSachKe(int [,] maTranKe)
        {
            List<List<int>> danhSachKe = new List<List<int>>();

            for (int i = 0 ; i < maTranKe.GetLength(0) ; i++)
            {
                danhSachKe.Add(new List<int>());
                for (int j = 0 ; j < maTranKe.GetLength(1) ; j++)
                {
                    if (maTranKe[i,j] != 0)
                    {
                        danhSachKe[i].Add(j);
                    }
                }
            }

            return danhSachKe;
        } 






        //main
        static void Main(string[] args)
        {
           int [,] maTranKe = DocMaTranTuFile("maTranKe.txt");
           System.Console.WriteLine("Ghi file : " + GhiMaTranKeXuongFile(maTranKe,"testGhiMaTranKKe.txt"));
           InMaTran(maTranKe);
           int [] danhSachBacCuaDinh = TaoDanhSachBacCuaDinhMaTranKe(maTranKe);
           InDanhSachBacCuaDinh(danhSachBacCuaDinh);
           List<List<int>> danhSachKe = ChuyenMaTranKeSangDanhSachKe(maTranKe);
           InDanhSachKe(danhSachKe);


        }

        static void InDanhSachBacCuaDinh(int[] dsBac)
        {
            for (int i= 0 ; i < dsBac.Length ; i++)
            {
                System.Console.WriteLine($"Dinh {i} co bac la : " + dsBac[i]);
            }
        }

        static void InDanhSachKe( List<List<int>> danhSachKe)
        {
            int i = 0;
            foreach (List<int> items in danhSachKe)
            {
                System.Console.Write($"Dinh {i} : " );
                foreach (int item in items)
                {
                    System.Console.Write(item + " ");
                }
                System.Console.WriteLine();
            }
        }
    }
}