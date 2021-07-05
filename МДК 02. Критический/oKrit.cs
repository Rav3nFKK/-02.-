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
        public struct ofPP
        {
            public int punkt1;
            public int punkt2;
            public int dlina;

        }

        public void Reshenie()
        {
            Vvod();

        }

        //!check
        /// <summary>
        /// Метод считывания из файла
        /// </summary>
        /// <returns> Возвращает заполненный лист</returns>
        public List<ofPP> Vvod()
        {
            List<ofPP> l = new List<ofPP>();
            using (StreamReader sr = new StreamReader("Ввод.csv"))
            {
                while (sr.EndOfStream != true)
                {
                    string[] count1 = sr.ReadLine().Split(';');
                    string[] count2 = count1[0].Split('-');
                    Debug.WriteLine(count2[0] + " - " + count2[1] + "; " + count1[1]);
                    l.Add(new ofPP { punkt1 = Convert.ToInt32(count2[0]), punkt2 = Convert.ToInt32(count2[1]), dlina = Convert.ToInt32(count1[1]) });
                }

            }
            return l;
        }






    }
}
