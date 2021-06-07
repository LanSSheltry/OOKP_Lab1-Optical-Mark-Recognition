using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOKP_Lab_1_
{
    public partial class Form1 : Form //Основная форма, которую открывает программа при запуске
    {
        Form2 dialogwindow;
        public Form1()
        {
            InitializeComponent();
        }
        private void CheckButton_Click(object sender, EventArgs e) //Нажатие на кнопку "Проверить"
        {
            try
            {
                Recognizer recognizer = new Recognizer();
                recognizer.GetPixels(); //Метод для получения значений цветов по пикселям
                recognizer.OutputArrayInit(); //Инициализация выходного массива и заполнение начальными значениями
                recognizer.CalculateRate(); //Вычисление коэффициента для подсчета и сдвига
                recognizer.RecognizeVariants(); //Анализ загруженного в массив изображения

                checkBoxChecker(); //Заполняет исходный массив, синхронизированный с массивом типа чекбокс
                recognizer.CheckAnswers(); //Сверяет значения с выставленными в меню
                dialogwindow = new Form2();
                dialogwindow.Show();
                TryAgain();
            }
            catch (Exception ex) { PathField.Text = ex.ToString(); }
        }

        private void BrowseButton_Click(object sender, EventArgs e) //Нажатие на кнопку "Обзор..."
        {
            DialogResult result = openFileDialog1.ShowDialog(); //Открывает диалоговое окно для выбора объекта
            if (result==DialogResult.OK) //Проверка на существование
            {
                Data.ImagePath = openFileDialog1.FileName;
                
            }
            try //Предотвращение многих ошибок, связанных с несоответствием типа, формата и т.д. файла
            {
                MainImageBox.ImageLocation = Data.ImagePath;
                PathField.Text = Data.ImagePath;
                TryAgain();
            }
            catch { MainImageBox.Image=MainImageBox.ErrorImage;
                PathField.Text = "Данный файл не удалось открыть!";
            }
        }

        private void TryAgain()
        {
            Data.AmountofMistakes = 0;
            Data.RecText = "0";
            Data.Mark = "Default.txt";
            Data.Name = "None";
            Data.Surname = "None";
            Data.Group = "None";
            Data.Mistakes = "";
        }

        private void checkBoxChecker() //Заполняет исходный массив в соответствии с чекбоксом значениями для дальнейшего использования
        {
            Data.CheckBox[0] = checkBox1;
            Data.CheckBox[1] = checkBox2;
            Data.CheckBox[2] = checkBox3;
            Data.CheckBox[3] = checkBox4;
            Data.CheckBox[4] = checkBox5;
            Data.CheckBox[5] = checkBox6;
            Data.CheckBox[6] = checkBox7;
            Data.CheckBox[7] = checkBox8;
            Data.CheckBox[8] = checkBox9;
            Data.CheckBox[9] = checkBox10;
            Data.CheckBox[10] = checkBox11;
            Data.CheckBox[11] = checkBox12;
            Data.CheckBox[12] = checkBox13;
            Data.CheckBox[13] = checkBox14;
            Data.CheckBox[14] = checkBox15;
            Data.CheckBox[15] = checkBox16;
            Data.CheckBox[16] = checkBox17;
            Data.CheckBox[17] = checkBox18;
            Data.CheckBox[18] = checkBox19;
            Data.CheckBox[19] = checkBox20;
            Data.CheckBox[20] = checkBox21;
            Data.CheckBox[21] = checkBox22;
            Data.CheckBox[22] = checkBox23;
            Data.CheckBox[23] = checkBox24;
            Data.CheckBox[24] = checkBox25;
            Data.CheckBox[25] = checkBox26;
            Data.CheckBox[26] = checkBox27;
            Data.CheckBox[27] = checkBox28;
            Data.CheckBox[28] = checkBox29;
            Data.CheckBox[29] = checkBox30;
            for (int i=0;i<30; i++)
            {
                if (Data.CheckBox[i].Checked==true)
                {
                    Data.InputData[i] = true;
                }
                else
                {
                    Data.InputData[i] = false;
                }
            }
        }
        
        //События, обрабатывающие нажатие(флажок), далее править по количеству вариантов и заданий + алгоритм
        private void check1(object sender, EventArgs e)
        {

        }

        private void check2(object sender, EventArgs e)
        {

        }

        private void check3(object sender, EventArgs e)
        {

        }

        private void check4(object sender, EventArgs e)
        {

        }

        private void check5(object sender, EventArgs e)
        {

        }

        private void check6(object sender, EventArgs e)
        {

        }

        private void check7(object sender, EventArgs e)
        {

        }

        private void check8(object sender, EventArgs e)
        {

        }

        private void check9(object sender, EventArgs e)
        {

        }

        private void check10(object sender, EventArgs e)
        {

        }

        private void check11(object sender, EventArgs e)
        {

        }

        private void check12(object sender, EventArgs e)
        {

        }

        private void check13(object sender, EventArgs e)
        {

        }

        private void check14(object sender, EventArgs e)
        {

        }

        private void check15(object sender, EventArgs e)
        {

        }

        private void check16(object sender, EventArgs e)
        {

        }

        private void check17(object sender, EventArgs e)
        {

        }

        private void check18(object sender, EventArgs e)
        {

        }

        private void check19(object sender, EventArgs e)
        {

        }

        private void check20(object sender, EventArgs e)
        {

        }

        private void check21(object sender, EventArgs e)
        {

        }

        private void check22(object sender, EventArgs e)
        {

        }

        private void check23(object sender, EventArgs e)
        {

        }

        private void check24(object sender, EventArgs e)
        {

        }

        private void check25(object sender, EventArgs e)
        {

        }

        private void check26(object sender, EventArgs e)
        {

        }

        private void check27(object sender, EventArgs e)
        {

        }

        private void check28(object sender, EventArgs e)
        {

        }

        private void check29(object sender, EventArgs e)
        {

        }

        private void check30(object sender, EventArgs e)
        {

        }
    }
}
