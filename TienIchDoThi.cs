﻿using System;

namespace TienIchDoThi
{
    class TienIchDoThi
    {
        ////In ma tran
        public static void InMaTran(int[,] maTran)
        {
            for (int i = 0; i < maTran.GetLength(0); i++)
            {
                for (int j = 0; j < maTran.GetLength(0); j++)
                {
                    Console.Write(maTran[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        ////doc du lieu tu file
        public static int[,] DocMaTranTuFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int soDinh = int.Parse(sr.ReadLine());
                    int[,] maTran = new int[soDinh, soDinh];

                    for (int i = 0; i < maTran.GetLength(0); i++)
                    {
                        string[] line = sr.ReadLine().Split('_');
                        for (int j = 0; j < maTran.GetLength(1); j++)
                        {
                            maTran[i, j] = int.Parse(line[j]);
                        }
                    }

                    return maTran;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Cannot read from " + path);
            }

            return null;
        }

        //ghi du lieu vao file
        public static void VietMaTranXuongFile(string path, int[,] maTran)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    //ghi so dinh xuong file
                    sw.WriteLine(maTran.GetLength(0));

                    //ghi tung dong xuong file
                    for (int i = 0; i < maTran.GetLength(0); i++)
                    {
                        //ghi 1 dong xuong file
                        for (int j = 0; j < maTran.GetLength(0); j++)
                        {
                            if (j == maTran.GetLength(0) - 1)
                            {
                                sw.WriteLine(maTran[i,j]);
                            }
                            else
                            {
                                sw.Write(maTran[i, j] + "_");
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Cannot write into file");
            }
        }

        //tinh so bac cua dinh
        public static int TinhBacCuaDinhMaTranKe(int[,] maTran, int dinhI)
        {
            int bac = 0;

            for (int i = 0; i < maTran.GetLength(0); i++)
            {
                bac += maTran[dinhI, i];
            }

            return bac;
        }

        public static int[] TinhBacCuaDinhMaTranKe(int[,] maTran)
        {
            int[] dsBac = new int[maTran.GetLength(0)];

            for (int i = 0; i < maTran.GetLength(0); i++)
            {
                dsBac[i] = 0;
                for (int j = 0; j < maTran.GetLength(1); j++)
                {
                    dsBac[i] += maTran[i, j];
                }
            }

            return dsBac;
        }

        //chuyen ma tran ke thanh danh sach ke
        public static LinkedList<int>[] ChuyenThanhDanhSachKe(int[,] mtKe)
        {
            LinkedList<int>[] dsKe = new LinkedList<int>[mtKe.GetLength(0)];

            for (int i = 0; i < dsKe.Length; i++)
            {
                dsKe[i] = new LinkedList<int>();
                for (int j = 0; j < dsKe.Length; j++)
                {
                    if (mtKe[i,j] != 0) // la dinh ke
                    {
                        dsKe[i].AddLast(j);
                    }
                }
            }

            return dsKe;
        }

        //MA TRAN TRONG SO
        //dem so luong phan tu khac 0 <=> tinh bac cho ma tran trong so
        public static int TinhBacCuaDinh(int[,] maTran, int dinhI)
        {
            int bac = 0;

            for (int i = 0; i < maTran.GetLength(0); i++)
            {
                if (maTran[dinhI,i] != 0)
                {
                    bac++;
                }
            }
            return bac;
        }

        public static int[] TinhBacCuaDinh(int[,] maTran)
        {
            int[] dsBac = new int[maTran.GetLength(0)];

            for (int i = 0; i < maTran.GetLength(0); i++)
            {
                dsBac[i] = 0;
                for (int j = 0; j < maTran.GetLength(1); j++)
                {
                    if (maTran[i, j] != 0)
                    {
                        dsBac[i]++;
                    }
                }
            }
            return dsBac;
        }

        //DANH SACH KE
        //ghi du lieu vao file
        public static void VietDSKeXuongFile(string path, LinkedList<int>[] dsKe)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    //ghi so dinh xuong file
                    sw.WriteLine(dsKe.GetLength(0));

                    //ghi tung dong xuong file
                    for (int i = 0; i < dsKe.GetLength(0); i++)
                    {
                        //ghi 1 dong xuong file
                        for (LinkedListNode<int> j = dsKe[i].First; j != null; j = j.Next)
                        {
                            if (j == dsKe[i].Last)
                            {
                                sw.WriteLine(j.Value);
                            }
                            else
                            {
                                sw.Write(j.Value + "_");
                            }
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Cannot write into file");
            }
        }

        //doc du lieu tu file
        public static LinkedList<int>[] DocDSKeTuFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int soDinh = int.Parse(sr.ReadLine());
                    LinkedList<int>[] dsKe = new LinkedList<int>[soDinh];

                    string[] line;

                    //doc tung dong do thi
                    for (int i = 0; i < dsKe.Length; i++)
                    {
                        try
                        {
                            line = sr.ReadLine().Split('_');
                        }
                        catch (NullReferenceException)
                        {
                            line = new string[0];
                        }
                        
                        dsKe[i] = new LinkedList<int>();
                        for (int j = 0; j < line.Length; j++)
                        {
                            //them dinh vao danh sach ke
                            dsKe[i].AddLast(int.Parse(line[j]));
                        }

                    }

                    return dsKe;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Cannot read from " + path);
            }

            return null;
        }

        //in danh sach ke
        public static void InDSKe(LinkedList<int>[] dsKe)
        {
            for (int i = 0; i < dsKe.Length; i++)
            {
                Console.Write($"Dinh {i}: ");
                for (LinkedListNode<int> j = dsKe[i].First; j != null; j = j.Next)
                {
                    if (j == dsKe[i].Last)
                    {
                        Console.WriteLine(j.Value);
                    }
                    else
                    {
                        Console.Write(j.Value + ", ");
                    }
                }
            }
        }

        //tinh bac cua dinh
        public static int TinhBacCuaDinh(LinkedList<int>[] dsKe, int dinhI)
        {
            return dsKe[dinhI].Count;
        }

        //chuyen danh sach ke thanh ma tran ke
        public static int[,] ChuyenThanhMaTranKe(LinkedList<int>[] dsKe)
        {
            int[,] mtKe = new int[dsKe.Length,dsKe.Length];

            for (int i = 0; i < dsKe.Length; i++)
            {
                for (int j = 0; j < dsKe.Length; j++)
                {
                    if (dsKe[i].Contains(j))
                    {
                        mtKe[i,j] = 1;
                    }
                    else
                    {
                        mtKe[i,j] = 0;
                    }
                }
            }

            return mtKe;
        }

        //TINH LIEN THONG
        //xet tinh lien thong
        public static bool XetTinhLienThong(LinkedList<int>[] dsKe)
        {
            int[] dinhDaXet = new int[dsKe.Length];
            for (int i = 0; i < dinhDaXet.Length; i++)
            {
                dinhDaXet[i] = 0;
            }
            Queue<int> hangDoi = new Queue<int>();

            dinhDaXet[0] = 1;
            hangDoi.Enqueue(0);

            while (hangDoi.Count > 0)
            {
                int dinhDangXet = hangDoi.Dequeue();
                for (int i = 0; i < dinhDaXet.Length; i++) // i la 1 dinh 
                {
                    for (LinkedListNode<int> j = dsKe[dinhDangXet].First; j != null; j = j.Next) //j.Value la dinh ke
                    {
                        if (dinhDaXet[j.Value] == 0)
                        {
                            dinhDaXet[j.Value] = 1;
                            hangDoi.Enqueue(j.Value);
                        }
                    }
                }
            }

            return !dinhDaXet.Contains(0);
        }

        //xet tinh lien thong
        public static bool XetTinhLienThong(int[,] mtKe)
        {
            LinkedList<int>[] dsKe = ChuyenThanhDanhSachKe(mtKe);
            int[] dinhDaXet = new int[dsKe.Length];
            for (int i = 0; i < dinhDaXet.Length; i++)
            {
                dinhDaXet[i] = 0;
            }
            Queue<int> hangDoi = new Queue<int>();

            dinhDaXet[0] = 1;
            hangDoi.Enqueue(0);

            while (hangDoi.Count > 0)
            {
                int dinhDangXet = hangDoi.Dequeue();
                for (int i = 0; i < dinhDaXet.Length; i++) // i la 1 dinh 
                {
                    for (LinkedListNode<int> j = dsKe[dinhDangXet].First; j != null; j = j.Next) //j.Value la dinh ke
                    {
                        if (dinhDaXet[j.Value] == 0)
                        {
                            dinhDaXet[j.Value] = 1;
                            hangDoi.Enqueue(j.Value);
                        }
                    }
                }
            }

            return !dinhDaXet.Contains(0);
        }

        //CHU TRINH VA DUONG DI EULER
        /// <summary>
        /// tra ve 0 neu khong co duong di hay chu trinh euler
        /// tra ve 1 neu co duong di euler
        /// tra ve 2 neu co chu trinh euler
        /// </summary>
        /// <param name="dsKe"></param>
        /// <returns></returns>
        public static int KiemTraEuler(LinkedList<int>[] dsKe)
        {
            int[,] mtKe = ChuyenThanhMaTranKe(dsKe);
            int[] dsBac = TinhBacCuaDinh(mtKe);
            int demBacle = 0;

            if (XetTinhLienThong(mtKe) == false) // khong co chu trinh hay duong di euler
            {
                return 0;
            }


            for (int i = 0; i < dsBac.Length; i++)
            {
                if (dsBac[i] % 2 != 0) // dem dinh bac le
                {
                    demBacle++;
                }

                if (demBacle > 2) // khong co
                {
                    return 0;
                }
            }

            if (demBacle == 2)
            {
                return 1; // co duong di euler
            } else  if( demBacle == 0)
            {
                return 2; // co ch trinh euler
            } else // khong co
            {
                return 0;
            }
        }

        public static int[] TimChuTrinhEuler(LinkedList<int>[] dsKe)
        {
            Stack<int> st = new Stack<int>();
            st.Push(0);
            int[] list = new int[0];

            while (st.Count != 0)
            {
                int dinhHienHanh = st.Pop();

                //them dinh vao stack
                if (dsKe[dinhHienHanh].Count > 0)
                {
                    int dinhKe = dsKe[dinhHienHanh].First.Value;
                    Console.WriteLine($"chon canh {dinhHienHanh * 10 + dinhKe:00} ke voi dinh {dinhHienHanh}");

                    Console.WriteLine($"Them dinh {dinhKe} vao Stack");
                    st.Push(dinhKe);

                    Console.Write("Stack: ");
                    foreach (var item in st)
                    {
                        Console.Write(item+"  ");
                    }
                    Console.WriteLine();

                    //xoa canh vua chon
                    dsKe[dinhKe].Remove(dinhHienHanh);
                    dsKe[dinhHienHanh].RemoveFirst();

                    //luu vao list
                    Array.Resize(ref list, list.Length + 1);
                    list[list.Length - 1] = dinhHienHanh *10 + dinhKe;

                    Console.Write("List: ");
                    for (int i = 0; i < list.Length; i++)
                    {
                        Console.Write(list[i] + "   ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }

            }

            return list;
        }
    }
}