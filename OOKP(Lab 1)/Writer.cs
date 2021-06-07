using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OOKP_Lab_1_
{
    class Writer
    {
        public void Write()
        {
            try
            {
                //Заголовок в текстовом файле
                string Output = @"Имя: " + Data.Name + "\nФамилия: " + Data.Surname + "\nГруппа: " + Data.Group+"\nКоличество ошибок: "+Data.AmountofMistakes+" в 10 заданиях"+"\nВ заданиях: "+Data.Mistakes+"\nОтветы: ";
                //Имя созданного текстового файла
                string OutputName = Data.Name+"_"+Data.Surname+"_"+Data.Group+".txt";
                Output += "\n"+Data.RecText+"\n";

                //Создание файла или открытие для записи данных
                using (FileStream sstream = new FileStream(Data.Mark+@"\"+OutputName, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(Output); //Массив байтов для записи
                    sstream.Write(array, 0, array.Length);
                }
                
            }
            catch { }
        }
    }
}
