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
                    string[] arrSt = streamReader.ReadLine().Split(',');

                    for (int i = 0; i < maTran.GetLength(0); i++)
                    {
                        // convert item in arrSt type string to int
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
                        line = j == (maTran.GetLength(1) - 1) ? line+=(maTran[i,j]) : line+=(maTran[i,j] + ",");
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
        // public static int TinhBacCuaDinhMaTranKKe(int [,] maTran, int dinh)
        // {
            
        // }
    }
}