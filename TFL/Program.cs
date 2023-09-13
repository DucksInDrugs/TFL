//На вход получает определение автомата
//Состояние - натуральное число, входной алфавит - латинский алфавит
//Входной файл
//


using System.IO;
using TFL;

public class Program
{ 
    private static void Main(string[] args)
    {
        FirstTask task = new FirstTask();
        task.ShowDFA();
        task.Run(Console.ReadLine());
    }
}