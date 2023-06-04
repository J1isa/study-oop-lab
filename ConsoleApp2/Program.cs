using System;
using System.Text;

class Program
{
    static void Main()
    {
        // заданный текст
        string text = "тевирп ревирп ревирп кетсон ят ежедневно";

        // разделитель слов
        char[] separators = { ' ', '.', ',', '!', '?', ';' };

        // разбиваем текст на слова
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        // создаем StringBuilder для хранения расшифрованного текста
        StringBuilder decryptedText = new StringBuilder(text.Length);

        // расшифруем каждое слово и добавляем его в StringBuilder
        foreach (string word in words)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            string decryptedWord = new string(chars);
            decryptedText.Append(decryptedWord + " ");
        }

        // выводим расшифрованный текст на экран
        Console.WriteLine(decryptedText);

        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Black;

    }
}
