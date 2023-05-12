using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace События_и_делигаты
{
    public partial class Form1 : Form
    {
        
        
            public static bool flag = false; // Запретить/разрешить смену цвета 
            char[] symb = { 'R', 'G', 'B', 'X' }; // массив символов, см.comboBox1 
            int[] heigth = { 150, 200, 250, 300 };
            public Form1()
            {
                InitializeComponent();
            }
            // Переключатель флага: Разрешить/Запретить смену цвета формы
           
            // Изменение цвета (4 цвета) и размеров формы
            
            // Реакция на изменение выбора цвета формы


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                button1.Text = "Изменение цвета формы разрешить!";
            }
            else
            {
                flag = true;
                button1.Text = "Изменение цвета формы запретить!";
            }

        }
        private void ChangeBackColor(object sender, MyEA e)
        {
            switch (e.ch)
            {
                case 'R':
                    {
                        this.BackColor = Color.Red;
                        this.Height = heigth[0];
                        this.Width = 350 + heigth[0];
                        break;
                    }
                case 'G':
                    {
                        this.BackColor = Color.Green;
                        this.Height = heigth[1];
                        this.Width = 350 + heigth[1];
                        break;
                    }
                case 'B':
                    {
                        this.BackColor = Color.Blue;
                        this.Height = heigth[2];
                        this.Width = 350 + heigth[2];
                        break;
                    }
                case 'Y':
                    {
                        this.BackColor = Color.Yellow;
                        this.Height = heigth[3];
                        this.Width = 350 + heigth[3];
                        break;
                    }
                default: // оставить без изменений
                    break;
            }; // end switch
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            MyEH met2 = new MyEH(); // новый объект-событие и пр.
            MyEA e2 = new MyEA(); // новый объект-аргументы:
            e2.ch = 'Y'; // первый
            e2.htw = heigth[3]; // второй
            met2.Ez += ChangeBackColor; // связывание события с методом 
                                        // (его аргументы класса MyEA)
            met2.OnEz(e2); // вызов метода

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            MyEH met = new MyEH(); // объект класса Моя обработка событий
                                   // Получить аргументы: букву цвета и высоту формы - в объект e1:
            int i = comboBox1.SelectedIndex;// номер цвета в массиве symb[]
            MyEA e1 = new MyEA(); // объект класса Мои Аргументы Событий
            e1.ch = symb[i]; // буква цвета
            e1.htw = heigth[i]; // высота формы
            if (flag)
                met.Ez += ChangeBackColor; // Событие Ez связать с методом
            else
                met.Ez -= ChangeBackColor; // Или разорвать связь
                                           // вызов метода обработки события, связанного с met.Ez
            met.OnEz(e1);

        }
    } // end класса Form1
      // Класс Моих Событий Аргументы
    class MyEA : EventArgs
        {
            public char ch; // буква цвета
            public int htw; // высота формы
        }
        // Мой класс Обработка события
        class MyEH
        {
            public event EventHandler<MyEA> Ez; // мое событие
            public void OnEz(MyEA c) // и его метод
            {
                if (Ez != null) // Есть ли событие?
                    Ez(this, c); // Старт события
            }
        } // end класса
    } // end namespace!

