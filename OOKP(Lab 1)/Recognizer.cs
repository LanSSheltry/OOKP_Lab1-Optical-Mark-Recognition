using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace OOKP_Lab_1_
{
    class Recognizer
    {
        static Bitmap inputimage;// = new Bitmap(Data.ImagePath); //Загружаем изображение по указанному адресу
        static int width, height; //Устанавливаем ширину и высоту изображения по пикселям
        static byte[,,] res; //Массив, созданный для чтения значений RGB значений для каждой координаты
        static int Acounter; //Счётчик "тёмных" пикселей
        static int Bcount, Shift; //Счётчик "тёмных" пикселей для рассматриваемой зоны и переменная, хранящая значение сдвига
        static double BlackC; //Коэффициент для деления изображения на зоны, в зависимости от количества "тёмных пикселей", размера изображения и 
        static int p = 80; //Нижнее значение "светлых пикселей"
        static int TaskCounterA; //Счётчик задания
        string s; //Строка для перечисления неправильных заданий
        static int XPos, YPos; //Позиция рассматриваемой зоны по двум осям
        int cnt; //Для сравнения массивов входных и полученных данных
        bool Check; //Проверка на совпадение

        public Recognizer()
        {
            inputimage = new Bitmap(Data.ImagePath);
            width = inputimage.Width;
            height = inputimage.Height;
            res = new byte[3, height, width];
            Acounter = 0;
            Bcount = 0;
            TaskCounterA = 0;
            XPos = 0;
            YPos = 0;
            cnt = 0;
            Check = true;
        }

            public void CheckAnswers() //Метод для проверки ответов
        {
            Data.AmountofMistakes = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Data.InputData[cnt] != Data.BaseData[cnt]) Check = false;
                    cnt++;
                }

                if (Check == false)
                {
                    Data.Mistakes += Convert.ToString(i + 1 + ", ");
                    Data.AmountofMistakes++;
                    Check = true;
                }
            }
        }
        public void GetPixels() //Метод для получения значений RGB по пикселям
        {
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    Color color = inputimage.GetPixel(x, y);
                    res[0, y, x] = color.R;
                    res[1, y, x] = color.G;
                    res[2, y, x] = color.B;
                    if (color.R < p & color.G < p & color.B < p) Acounter++;
                }
            }
        }



        public void CalculateRate() //Метод для получения коэффициента и значения сдвига
        { 
            BlackC = Convert.ToDouble(Acounter) * 0.9 / 20;
            Shift = Convert.ToInt32(Math.Sqrt(BlackC));
        }

        public void OutputArrayInit()
        {
            for (int i = 0; i < 30; i++)
            {
                Data.BaseData[i] = false;
            }
        }

        public void RecognizeVariants() //Метод для распознавания
        {
            while (true)
            {
                for (int i = YPos; i <= YPos + Shift; i++)
                {
                    for (int j = XPos; j <= XPos + Shift; j++)
                    {
                        if (j <= width - 1) { if (res[0, i, j] < p & res[1, i, j] < p & res[2, i, j] < p) Bcount++; }
                    }
                }
                if (Bcount >= 0.5 * BlackC) //Если в рассматриваемой зоне обнаружено минимум 50% "тёмных" пикселей - значение засчитывается в зависимости от расположения на странице, по У сдвиг производится на 2 значения
                                            //для предотвращения повторного прочтения вхождения
                {
                    if (XPos <= width / 2) {s += Convert.ToString("\n"+(1+TaskCounterA/3)+". A"); Data.BaseData[TaskCounterA] = true;} //Первая половина страницы, где должны располагаться варианты А
                    if (XPos < width * 3 / 4 & XPos >= width / 2) { s += Convert.ToString("\n" + (1 + TaskCounterA / 3)+". B"); Data.BaseData[TaskCounterA + 1] = true; } //Третья четверть страницы (И)
                    if (XPos < width & XPos >= width * 3 / 4) { s += Convert.ToString("\n" + (1 + TaskCounterA / 3)+". C"); Data.BaseData[TaskCounterA + 2] = true; } //Четвертая четверть страницы (С)
                    TaskCounterA += 3;
                    YPos += 2 * Shift; XPos = 0; Bcount = 0;
                }
                else //Если соответствующих зон не обнаружено
                {
                    if (XPos + Shift > width - 1) { XPos = 0; YPos += Shift; Bcount = 0; } //Если строка закончилась без единого совпадения - сдвигаем позицию на полученное значение
                    else { XPos += Shift; Bcount = 0; } //Если строка не закончилась и вхождение не обнаружено - сдвигаем рассматриваемую зону на одно значение сдвига по Х
                }
                if (YPos + Shift > height - 1) break; //Если значения по У закончились в массиве
            }
            Data.RecText = s; //Обеспечение общего доступа классов к значению строки
        }
    }
}
