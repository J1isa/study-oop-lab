using System;

namespace StudentApplication // namespace - как папка, где хранятся классы приложения.
{
    class Student // объявление класса
    {
        private string name; // закрытое поле для хранения имени
        private int grade; // закрытое поле для хранения оценки

        // свойство для доступа к имени (get - чтение, set - запись)
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // свойство для доступа к оценке (get - чтение, set - запись)
        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        // конструктор без параметров
        public Student()
        {
            name = "";
            grade = 0;
        }

        // конструктор с параметрами (инициализация имени и оценки)
        public Student(string name, int grade)
        {
            this.name = name; // this обозначает, что это поле класса, а не локальная переменная
            this.grade = grade;
        }

        // метод для вывода информации о студенте на экран
        public void ShowData()
        {
            Console.WriteLine("Имя: " + name);
            Console.WriteLine("Оценка: " + grade);
        }
    }

    class Program // главный класс программы
    {
        static void Main(string[] args) // главная функция программы
        {
            Student[] students = new Student[3]; // объявление массива объектов класса

            // создание объектов и добавление их в массив
            students[0] = new Student("Иванов", 3);
            students[1] = new Student("Сидоров", 4);
            students[2] = new Student("Петров", 5);

            // вывод информации о каждом из объектов
            for (int i = 0; i < students.Length; i++)
            {
                students[i].ShowData();
            }

            float avgGrade = 0; // переменная для хранения средней оценки

            // цикл для подсчета суммы оценок
            for (int i = 0; i < students.Length; i++)
            {
                avgGrade += students[i].Grade;
            }

            avgGrade /= students.Length; // вычисление средней оценки

            Console.WriteLine("Средняя оценка: " + avgGrade); // вывод средней оценки на экран
            Console.ReadKey(); // ожидание нажатия клавиши
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}