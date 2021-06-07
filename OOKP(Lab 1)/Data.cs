using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOKP_Lab_1_
{
    public static class Data //Данный класс был создан с целью обмена данными классов между формами
    {
        public static bool[] InputData=new bool[30]; //Массив данных, полученных с чекбокса
        public static bool[] BaseData=new bool[30]; //Массив данных, полученный при сканировании изображения
        public static CheckBox[] CheckBox=new CheckBox[30]; //Масссив типа чекбокс для дальнейшего сравнения
        public static int AmountofMistakes; //Количество ошибок
        public static string ImagePath; //Адрес изображения
        public static string RecText; //Строка для записи ответов
        public static string Mark; //Конечное имя файла, установленное по умолчанию воизбежании ошибки
        public static string Name="None", Surname="None", Group="None"; //Данные для текстового файла и имени файла

        public static string Mistakes; //Строка для отображения неправильных заданий
    }
}
