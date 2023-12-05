using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace случайная_перестановка_элементов_массива
{
    internal class случайная_перестановка_элементов_массива
    {
        static void RandMove(ref int[] array, int l)
        {
            Console.WriteLine("\n\n");

            Random rand = new Random();

            for (int i = l - 1; i >= 1; i--)
            {
                int j = rand.Next(i);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            for (int i = 0; i < l; i++)
            {
                Console.Write(" " + array[i] + "\t");
            }
               
            Console.WriteLine("\n\n");
        }


        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");

            int l = int.Parse(Console.ReadLine());

            Console.Write("Введите ограничение по элементам массива(цифру): ");
            int ogr = int.Parse(Console.ReadLine());

            Random rand = new Random();
            int[] arr = new int[l];

            for (int i = 0; i < l; i++)

                arr[i] = rand.Next(ogr);

            Console.WriteLine("\n");

            for (int i = 0; i < l; i++)

                Console.Write(" " + arr[i] + "\t");

            Console.WriteLine("\n\n");


            RandMove(ref arr, l);

        }
    }
}