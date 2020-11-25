using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba_4
{
    public class Animals
    {
        public int weight = 0; //вес
        public static Random rnd = new Random();
        public virtual String GetInfo()
        {
            return "Я животное";
        }
    }
    public class Cow : Animals
    {
        public int hornLenght = 0; //длинна рогов
        public int milkValue = 0; //кол-во молока в сутки

        public override String GetInfo()
        {
            var str = "Корова";
            str += String.Format("\nВес - {0} кг", this.weight);
            str += String.Format("\nДлинна рогов - {0} см", this.hornLenght);
            str += String.Format("\nМолоки/сутки - {0} л", this.milkValue);

            return str;
        }

        // добавили статический метод генерации случайной коровы
        public static Cow Generate()
        {
            
            return new Cow
            {
                weight = rnd.Next(20 , 150), // вес от 20 до 150
                hornLenght = 5 + rnd.Next() % 20, // длинна рогов от 5 до 25 см
                milkValue = 5 + rnd.Next() % 20 // кол-во молока в сутки от 5 до 25 литров
            };
        }


    }


    // породы собак
    public enum DogType { toller, pug }; 
    
    public class Dog : Animals
    {
        public int distance = 0; //расстояние начиная с которого начинает игнорировать команды хозяина
        public int tail = 0; // длина хвоста
        public DogType type = DogType.toller; // порода

        public override String GetInfo()
        {
            var str = "Собака";
            str += String.Format("\nВес - {0} кг", this.weight);
            str += String.Format("\nРаст.нач.не.слыш - {0} м", this.distance);
            str += String.Format("\nДлинна хвоста - {0} см", this.tail);
            str += String.Format("\nПорода - {0}", this.type);

            return str;
        }

        public static Dog Generate()
        {

            return new Dog
            {
                weight = rnd.Next(1 , 100), // вес от 1 до 100
                distance = 5 + rnd.Next() % 20, // количество долек от 5 до 25 метров
                tail = 5 + rnd.Next() % 20, // длинна хвоста от 5 до 25 см
                type = (DogType)rnd.Next(2) //порода
            };
        }

    }

    // Кошки
    public class Cat : Animals
    {
       
        public bool wool = false; //наличие шерсти
        public int count = 0; //улов мышей в день

        public override String GetInfo()
        {
            var str = "Кошка";
            str += String.Format("\nВес - {0} кг", this.weight);
            str += String.Format("\nКол-во мышей - {0} шт", this.count);
            str += String.Format("\nШерсть - {0}", this.wool == true ? "Да" : "Нет" );

            return str;
        }

        public static Cat Generate()
        {

            return new Cat
            {
                weight = rnd.Next(1, 25), //вес от 1 до 25
                count = 5 + rnd.Next() % 20, // улов мышей в день от 5 до 25
                wool = rnd.Next(2) == 0 
            };
        }
    }
}
