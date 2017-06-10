using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;

namespace RegularExpressions
{
    public partial class Form1 : Form
    {
        private static String str;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // Задаём первоначальные параметры
        {
            this.CenterToScreen();
            this.Text = "Regex поиск";
            textBox3.Text = @"\d{4,}";
            textBox2.Clear();
            textBox1.Clear();
            label1.Text = "Код поиска:";
            label2.Text = "Текст:";
            label3.Text = "Найденое:";
            label4.Text = null;
            button1.Text = "Начать поиск";
            button2.Text = "Команды";
            button1_Click(1,null);
            button3.Text = "Очистить";
        }

        private void button1_Click(object sender, EventArgs e) // Начинаем поиск
        {
            if (textBox3.Text == "") // Если ничего не введено, открывает помощь
            {
                button2_Click(null,null);
            }
            textBox2.Clear();
            label4.Text = "\tCовпадений: ";
            try
            {
                Regex reg = new Regex(str); // Создаём Рег для поиска
                MatchCollection m = reg.Matches(textBox1.Text); // Где взять текст для поиска
                foreach (Match mat in m) // Выводим всё что нашли
                {
                    textBox2.Text += Convert.ToString(mat.Value + "     "); // \u2122
                }
                label4.Text += m.Count; // Говорим сколько найдено совпадений
            }
            catch (Exception Exept)
            {
                MessageBox.Show(Exept.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // Заносим текст в переменную
        {
            str = textBox3.Text;
        }

        private void button2_Click(object sender, EventArgs e) // Вывод окна помощи
        {
            // le="\w{0,}"|_\d{8}|\d\d:\d\d\s-\sResults|\d\d:\d\d\s-\sStarted|\d\d:\d\d\s*
            MessageBox.Show("\\d - Цифра (0-9)\n\\D - Не цифра (любой символ кроме (0-9)" +
                "\n\\s - Пустой символ (обычно пробел или табуляция)\n\\S - Не пустой символ" +
                "\n\\w - 'Словесный' символ (символ, который используется в словах. Обычно все буквы, все цифры и знак подчёркивания '_'" +
                "\n\\W - Всё что не входит в '\\w'" + "\n(?i) - Не чувствительность к регистру, а (?-i) - Временно отключить" +
                "\n\\b - Символ обозначающий границы (\\bcat\\b будет искать только 'cat')" +
                "\n\\B - Символ обозначающий границы (\\Bcat\\B будет искать 'madcats', но не 'cat')" +
                "\n[ ] - Символьный класс. В нем работает: '-', для перечисления (0-9). '^', (в начале)для отрицания. А так же, '\\'" +
                "\n . - Любой символ, кроме символа перевода строки" +
                "\n^alpha | \\Aalpha - В начале испытуемого текста" + "\nomega$ | omega\\Z - В конце испытуемого текста" +
                "\n^begin - В начале строки , end$ - В конце строки" + "\n| - используется для поиска нескольких значений" +
                "\n( ) - Сохранение фрагментов в группы. (?: ) - Не сохранять группу." +
                "\n(?<name> ) \\<name> - Именованное сохранение группы и обратная ссылка. Ещё < > - можно заменить на ' ' ", 
                "Команды:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e) // Очитска текста в котором проводили поиск
        {
            textBox1.Clear();
        }
    }
}
