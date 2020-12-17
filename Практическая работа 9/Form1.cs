using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_работа_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Структура Фильмы
        struct Films
        {//описание переменных
            public string Name, Genre, Duration;
        }

        Films[] films;
        //Кнопка Добавить
        private void add_Click(object sender, EventArgs e)
        {
            int pos = (int)numericUpDown1.Value - 1;
            if (Int32.TryParse(textBox1.Text, out int Number));//если номер введен верно, присваиваем
            else
            {
                MessageBox.Show("Ошибка!");//иначе завеершаем
                return;
            }
            films[pos].Name = textBox2.Text;//название
            films[pos].Genre = textBox3.Text;//жанр
            if (Int32.TryParse(textBox4.Text, out int Year));//год
            else MessageBox.Show("Ошибка!");
            films[pos].Duration = textBox5.Text;//продолжительность
            dataGridView1[0, pos].Value = textBox1.Text;
            dataGridView1[1, pos].Value = textBox2.Text;
            dataGridView1[2, pos].Value = textBox3.Text;
            dataGridView1[3, pos].Value = textBox4.Text;
            dataGridView1[4, pos].Value = textBox5.Text;
        }
        //при загрузке формы 
        private void Form1_Shown(object sender, EventArgs e)
        {
            films = new Films[7];//массив
            dataGridView1.ColumnCount = 5;//столбцы
            dataGridView1.RowCount = 7;//строки
        }
        //Кнопка ПОИСК
        private void button1_Click(object sender, EventArgs e)
        {
            //bool isSearch = false;
            string genre = textBox6.Text;
            for (int i = 0; i <= dataGridView1.RowCount; i++)//Ячейки таблицы
                if (genre == films[i].Genre)//если жанр совпадает
                {
                    dataGridView1.Rows[i].Selected = true;//выделяем строку
                    break;
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                    return;
                }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Практическая работа №9\n" +
                "Монахов Андрей ИСП-31\n" +
                "Заполнить таблицу фильмотеки на  7 кассет с полями: " +
                "фильм, жанр, год выпуска, продолжительность просмотра. Вывести результат на экран. " +
                "Вывести список фильмов заданного жанра.");
        }
    }
}
