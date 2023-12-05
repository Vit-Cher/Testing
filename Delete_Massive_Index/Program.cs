using System;

namespace Delete_Massive_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите текст:\n"); //по полям, по полям, синий трактор едет к нам!

            string text = Console.ReadLine();

            char[] myArray = text.ToCharArray();

            Console.Write("\nВведите номер символа который хотите удалить: ");
            int del = int.Parse(Console.ReadLine());

            RemoveAt(myArray, del);
        }

        static void RemoveAt(char[] array, int del)
        {
           
            char[] newArray= new char[array.Length-1];

            for (int i = 0; i <= del; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = del + 1; i < array.Length; i++)
            {
                newArray[i-1] = array[i]; 
            }

            array = newArray;

            Console.WriteLine();

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }

            Console.WriteLine();
        }

    }
}