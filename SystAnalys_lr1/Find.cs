using System;
using System.Collections;
using System.Collections.Generic;

namespace SystAnalys_lr1
{
    class Find_Path
    {
        public static int i, j, k, kol;
        public struct uzel
        {
            public int nom;
            public int ki;
            public int kj;
        };
        public static uzel n = new uzel();
        static void vkl(Stack vst, uzel n)
        {
            vst.Push(n);
        }
        static void iskl(Stack vst)
        {
            if (vst == null) Console.WriteLine("Стек пуст !");
            else n = (uzel)vst.Pop();
        }

        public static int Find_Path_Graph(int[,] matrix, int start_point, int end_point)
        {
            ArrayList path_list = new ArrayList();
            int matr_len = matrix.GetLength(1);
            Stack vstek = new Stack();
            string buf;
            int en, x, i1, i2;
            uzel y1 = new uzel();
            bool[] nov = new bool[matr_len + 1];
            int[,] p = new int[matr_len, matr_len];
            int[] m = new int[matr_len + 1];

            //Формирование списков смежных вершин по матрице а  
            for (i = 0; i < matr_len; i++)
            {
                p[i, 0] = i; k = 1;
                for (j = 0; j < matr_len; j++)
                    if ((matrix[i, j] != 1000) && (matrix[i, j] != 0))
                    {
                        p[i, k] = j;
                        k++;
                    }
                p[i, k] = 1000;
            }


            //Начальные установки программы
            for (i = 0; i < matr_len; i++)
            {
                nov[i] = true;
                m[i] = 0;
            }
            nov[matr_len] = false;
            x = 1;         //Номер очередного маршрута
            m[1] = start_point; i1 = 2;
            y1.nom = start_point; //Определяем поле nom узла y1
            y1.ki = start_point;  // Запоминаем номер списка смеж. вершин
            y1.kj = 0;  // Запоминаем номер текущей позиции в списке
            vkl(vstek, y1);
            kol = 1;       //Количество элементов в стеке
            nov[start_point] = false;
            nov[end_point] = false;
            i = start_point; j = 0;
            //Цикл поиска всех маршрутов в графе
            while (kol != 0)
            {
                do
                {
                    j++;
                    if (p[i, j] == end_point)
                    {
                        x++;
                        List<int> temp_list = new List<int>();
                        for (i2 = 1; i2 < i1; i2++)
                        {
                            temp_list.Add(m[i2]);
                        }
                        temp_list.Add(end_point);
                        path_list.Add(temp_list);
                    }
                }
                while ((p[i, j] != 1000) && (!nov[p[i, j]]));
                if (p[i, j] != 1000)
                    if (nov[p[i, j]])
                    {
                        y1.ki = i;
                        y1.kj = j;
                        i = p[i, j];
                        y1.nom = i;
                        vkl(vstek, y1);
                        j = 0;
                        kol++;
                        nov[i] = false;
                        m[i1] = i;
                        i1++;
                    };

                if (p[i, j] == 1000)
                {
                    kol--;
                    if (kol != 0)
                    {
                        iskl(vstek);
                        i = n.ki;
                        j = n.kj;
                        i1--;
                        m[i1] = 0;
                        nov[n.nom] = true;
                    }
                };
            }

            int max_len = 999999999;
            foreach (List<int> o in path_list)
            {
                if (max_len > o.Count)
                    max_len = o.Count - 1;
            }

            return max_len;
        }

    }
}
