using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите размер массива строк: ");
        int size = int.Parse(Console.ReadLine());

        string[] array = new string[size];

        // заполнение массива строк с клавиатуры
        for (int i = 0; i < size; i++)
        {
            Console.Write("Введите строку № {0}: ", i + 1);
            array[i] = Console.ReadLine();
        }

        Console.Write("Введите строковый фрагмент, который необходимо найти в массиве строк: ");
        string fragment = Console.ReadLine();

        // поиск строки, содержащей заданный фрагмент
        for (int i = 0; i < size; i++)
        {
            if (array[i].IndexOf(fragment) != -1)
            {
                Console.WriteLine("Строка '{0}' содержит заданный фрагмент.", array[i]);
            }
        }
        Console.ForegroundColor = ConsoleColor.Black;
    }
}