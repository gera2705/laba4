using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba_4
{
    public partial class Form1 : Form
    {
        List<Animals> animalsList = new List<Animals>();
        Graphics g , g2;
        Bitmap field1 , field2;

        public Form1()
        {
            this.BackgroundImage = new Bitmap(Properties.Resources.bgFarm);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            InitializeComponent();
            imageList1.Images.Add(Properties.Resources.cow);
            imageList1.Images.Add(Properties.Resources.dog);
            imageList1.Images.Add(Properties.Resources.cat);

            field1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(field1);

            field2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g2 = Graphics.FromImage(field2);

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;

            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            turn.Text = "";
            this.animalsList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) // генерирую случайное число от 0 до 2 (ну остаток от деления на 3)
                {
                    case 0: // если 0, то корова
                        this.animalsList.Add(Cow.Generate());
                        break;
                    case 1: // если 1 то собака
                        this.animalsList.Add(Dog.Generate());
                        break;
                    case 2: // если 2 то кошка
                        this.animalsList.Add(Cat.Generate());
                        break;
                }
            }
            foreach (Animals animal in animalsList)
            {
                turn.Text += animal.GetInfo().Substring(0, 6).Trim() + "\n";
            }
            
            ShowInfo();
            Drawing();


        }

        int cowsCount;
        int dogsCount;
        int catsCount;

        private void ShowInfo()
        {
            // заведем счетчики под каждый тип
            cowsCount = 0;
            dogsCount = 0;
            catsCount = 0;

            // пройдемся по всему списку
            foreach (var animal in this.animalsList)
            {
                
                if (animal is Cow) 
                {
                    cowsCount += 1;
                   
                }
                else if (animal is Dog)
                {
                    dogsCount += 1;
                }
                else if (animal is Cat)
                {
                    catsCount += 1;
                }
            }

            
           
            txtInfo.Text = "Коровы\tСобаки\tКошки"; // буквы экнмлю, чтобы влезло на форму
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", cowsCount, dogsCount, catsCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            turn.Text = "";
            g2.Clear(Color.Transparent);
            // если список пуст, то напишем что пусто и выйдем из функции
            if (this.animalsList.Count == 0)
            {
                g2.Clear(Color.Transparent);
                pictureBox2.Image = field2;
                txtOut.Text = "Животные закончились";
                return;
            }

            // взяли первое животное
            var animal = this.animalsList[0];

          

            if (animal.GetInfo().Substring(0 , 6) == "Корова")
            {
                imageList1.Draw(g2, new Point(0, 0), 0);
            }

            if (animal.GetInfo().Substring(0, 6) == "Собака")
            {              
                imageList1.Draw(g2, new Point(0, 0), 1);
            }

            if (animal.GetInfo().Substring(0, 5) == "Кошка")
            {
                imageList1.Draw(g2, new Point(0, 0), 2);
            }
            // тут вам не реальность, взятие это на самом деле создание указателя на область в памяти где хранится экземпляр класса
            this.animalsList.RemoveAt(0);

            // ну а теперь предложим покупателю его фрукт
            txtOut.Text = animal.GetInfo();

            foreach (Animals anima in animalsList)
            {
                turn.Text += anima.GetInfo().Substring(0, 6).Trim() + "\n";
            }

            pictureBox2.Image = field2;
            // обновим информацию о количестве товара на форме
            ShowInfo();
            Drawing();
        }

      
        public void Drawing()
        {
            g.Clear(Color.Transparent);
            int x = 0;
            int y = 0;

            for (int i = 1; i <= cowsCount; i++)
            {
                imageList1.Draw(g, new Point(x, y), 0);
                x += 60;
                
            }

            x += 40;

            for (int i = 1; i <= dogsCount; i++)
            {
                imageList1.Draw(g, new Point(x, y), 1);
                x += 60;
                
            }

            x += 40;

            for (int i = 1; i <= catsCount; i++)
            {
                imageList1.Draw(g, new Point(x, y), 2);
                x += 60;

            }

            pictureBox1.Image = field1;

        }


    }
}
