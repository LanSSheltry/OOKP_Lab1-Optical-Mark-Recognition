using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOKP_Lab_1_
{
    public partial class Form2 : Form
    {
        public Form2() //Форма, появляющаяся после проверки данных
        {
            InitializeComponent();
            //Установка текста для отображения результатов сканирования и проверки
            label2.Text = Convert.ToString(Data.AmountofMistakes);
            label4.Text = Data.Mistakes;
  
        }

        private void button1_Click(object sender, EventArgs e) //Событие нажатия на кнопку "Сохранить как..."
        {

            //Считываем данные с полей textBox
            Data.Name = textBox1.Text;
            Data.Surname = textBox2.Text;
            Data.Group = textBox3.Text;

            Writer writer = new Writer(); //Создание экземпляра класса для записи в файл
            folderBrowserDialog1.ShowDialog(); //Открытие браузера
            Data.Mark = folderBrowserDialog1.SelectedPath; //Выбор пути, по которому файл будет сохранен
            writer.Write(); //Вызов метода экземпляра класса writer для записи
            //Перезапуск программы с целью корректной очистки введенных данных (Не удалось настроить без рестарта)
        }

        private void change(object sender, EventArgs e)
        {
            
        }
    }
}
