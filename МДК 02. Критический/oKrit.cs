using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МДК_02.Критический
{
    class oKrit
    {
        string str = "";
        /// <summary>
        /// пути + продолжительность (дни по условию задачи)
        /// </summary>
        public struct ofPP
        {
            public int punkt1;
            public int punkt2;
            public int dlina;

            public override string ToString()
            {
                return punkt1.ToString() + " - " + punkt2.ToString() + " " + dlina.ToString();
            }

        }
        /// <summary>
        /// Модуль решения (вложенный вызов методов)
        /// </summary>
        public void Reshenie()
        {
            List<ofPP> Lway; //пути
            List<ofPP> Stq = Vvod(); //
            Lway = Stq.FindAll(x => x.punkt1 == Stq[MinElem(Stq)].punkt1);
            List<List<ofPP>> LwayPunkt = new List<List<ofPP>>();
            foreach (ofPP rb in Lway)//построение путей из начальных возможных перемещений
            {
                CreatePath(Stq, rb);//Построение пути
                LwayPunkt.Add(Branches(Stq, str));//Построение ветвей
                str = "";
            }

            Debug.WriteLine("Все пути: ");
            for (int i = 0; i < LwayPunkt.Count; i++)
            {
                foreach (ofPP path in LwayPunkt[i])
                {
                    Debug.Write(path.punkt1 + " - " + path.punkt2 + ";(" + path.dlina + ") ");
                }
                Debug.WriteLine("");
            }
            int max = LwayPunkt[0][0].dlina, maxind = 0;
            for (int i = 0; i < Lway.Count; i++)// подсчет стоимости путей
            {
                if (Dl(LwayPunkt[i]) >= max)// выбор самого большого
                {
                    max = Dl(LwayPunkt[i]);
                    maxind = i;
                }
            }
            vivod(LwayPunkt, maxind, max);
        }
        //!check
        /// <summary>
        /// Метод считывания из файла
        /// </summary>
        /// <returns> Возвращает заполненный лист</returns>
        public List<ofPP> Vvod()
        {
            List<ofPP> l = new List<ofPP>();
            using (StreamReader sr = new StreamReader("Vvod.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] count1 = sr.ReadLine().Split(';');
                    string[] count2 = count1[0].Split('-');
                    //Debug.WriteLine(count2[0] + " - " + count2[1] + "; " + count1[1]);
                    l.Add(new ofPP { punkt1 = Convert.ToInt32(count2[0]), punkt2 = Convert.ToInt32(count2[1]), dlina = Convert.ToInt32(count1[1]) });
                }

            }
            return l;
        }
        /// <summary>
        /// Построение всех возможных путей
        /// </summary>
        /// <param name="StQ"> лист с данными</param>
        /// <param name="minel"></param>
        /// <returns></returns>
        public int CreatePath(List<ofPP> StQ, ofPP minel)

        {

            int dlina = 0;

            ofPP MoveVar = StQ.Find(x => x.punkt1 == minel.punkt1 && x.punkt2 == minel.punkt2);//Поиск возможных вариантов передвижения

            str += MoveVar.punkt1.ToString() + "-" + MoveVar.punkt2.ToString();//Пишем передвижение

            if (MoveVar.punkt2 == StQ[MaxElem(StQ)].punkt2)//Смотрим не в конце ли мы

            {

                str += ";";

                return MoveVar.dlina;

            }

            else

            {

                for (int i = 0; i < StQ.Count; i++)//Ищем стоимость перемещения в ту точку в которую мы пришли

                {

                    if (StQ[i].punkt1 == MoveVar.punkt2)

                    {

                        str += ",";

                        dlina = CreatePath(StQ, StQ[i]) + MoveVar.dlina;

                    }

                }

            }

            return dlina;
        }
        /// <summary>
        /// Поиск конечной точки (берем )
        /// </summary>
        /// <param name="StQ">Лист значений</param>
        /// <returns></returns>
        public int MaxElem(List<ofPP> StQ)
        {
            int max = StQ[0].punkt2, MaxId = 0;
            foreach (ofPP pp in StQ)
            {
                if (pp.punkt2 >= max)
                {
                    max = pp.punkt1;
                    MaxId = StQ.IndexOf(pp);
                }
            }
            return MaxId;
        }
        /// <summary>
        /// Поиск начальной точки (Смотрим минимальный элемент исходящего столбца, которого нет в столбце прибытия)
        /// </summary>
        /// <param name="StQ"> Лист значений</param>
        /// <returns></returns>
        public int MinElem(List<ofPP> StQ)
        {
            int Min = StQ[0].punkt1, MinId = 0;
            foreach (ofPP pp in StQ)
            {
                if (pp.punkt1 <= Min)

                {
                    Min = pp.punkt1;
                    MinId = StQ.IndexOf(pp);
                }
            }
            return MinId;
        }
        /// <summary>
        /// Длина путей
        /// </summary>
        /// <param name="StQ"></param>
        /// <returns></returns>
        public int Dl(List<ofPP> StQ)

        {
            int LN = 0;
            foreach (ofPP rb in StQ)

            {
                LN += rb.dlina;
            }
            return LN;
        }
        public List<ofPP> Branches(List<ofPP> StQ, string s)
        {
            List<List<ofPP>> LBr = new List<List<ofPP>>();
            string[] s1 = s.Split(';');
            foreach (string st1 in s1)
            {
                if (st1 != "")
                {
                    LBr.Add(new List<ofPP>());
                    string[] s2 = st1.Split(',');
                    foreach (string str2 in s2)
                    {
                        if (str2 != "")
                        {
                            string[] str3 = str2.Split('-');
                            LBr[LBr.Count - 1].Add(StQ.Find(x => x.punkt1 == Convert.ToInt32(str3[0]) && x.punkt2 == Convert.ToInt32(str3[1])));
                        }
                    }
                }
            }
            foreach (List<ofPP> l in LBr)
            {
                if (l[0].punkt1 != StQ[MinElem(StQ)].punkt1)
                {
                    foreach (List<ofPP> l1 in LBr)
                    {
                        if (l1[0].punkt1 == StQ[MinElem(StQ)].punkt1)
                        {
                            l.InsertRange(0, l1.FindAll(x => l1.IndexOf(x) <= l1.FindIndex(y => y.punkt2 == l[0].punkt1)));
                        }
                    }
                }
            }
            int max = LBr[0][0].dlina, maxind = 0;
            for (int i = 0; i < LBr.Count; i++)
            {
                if (Dl(LBr[i]) >= max)
                {
                    max = Dl(LBr[i]);
                    maxind = i;
                }
            }
            return LBr[maxind];
        }
        public void vivod(List<List<ofPP>> LPathFunc, int maxind, int max)
        {
            using (StreamWriter sr = new StreamWriter(@"Вывод.csv", false, Encoding.Default, 10))
            {
                foreach (ofPP Path in LPathFunc[maxind])
                {
                    sr.Write(Path.punkt1 + " - " + Path.punkt2 + ";(" + Path.dlina + ") ");
                }
                sr.WriteLine("Длина " + max);
            }
        }
    }
}
