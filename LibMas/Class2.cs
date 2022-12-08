using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using Microsoft.Win32;

namespace LibMas
{
    public class Class2
    {

        /// <summary>
        /// Заполнение массива
        /// </summary>
        /// <param name="arr">Заполняемый массив</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        public static void FillArr(ref int[] arr, int min, int max)
        {
            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
                arr[i] = rand.Next(min, max);
        }

        /// <summary>
        /// Заполнение матрицы
        /// </summary>
        /// <param name="arr">Заполняемая матрица</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        public static void FillArr(ref int[,] arr, int min, int max)
        {
            Random rand = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
                for(int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = rand.Next(min, max);
        }

        /// <summary>
        /// Очистка(обнуление) массива
        /// </summary>
        /// <param name="arr">Массив</param>
        public static void ClearArr(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = 0;
        }

        /// <summary>
        /// Очистка(обнуление) массива
        /// </summary>
        /// <param name="arr">Массив</param>
        public static void ClearArr(ref bool[] arr)
        {
            for (int i = 0; i < arr.Length; i++) arr[i] = false;
        }

        /// <summary>
        /// Очистка(обнуление) Матрицы
        /// </summary>
        /// <param name="arr">Матрица</param>
        public static void ClearArr(ref int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for(int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = 0;
        }

        /// <summary>
        /// Сохранение массива
        /// </summary>
        /// <param name="arr">Сохраняемый массив</param>
        public static void SaveArr(int[] arr)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение массива";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.WriteLine(arr.Length);
                for (int i = 0; i < arr.Length; i++) file.WriteLine(arr[i]);

                file.Close();
            }
        }

        /// <summary>
        /// Сохранение Матрицы
        /// </summary>
        /// <param name="arr">Сохраняемая матрица</param>
        public static void SaveArr(int[,] arr)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение массива";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.WriteLine(arr.GetLength(0));
                file.WriteLine(arr.GetLength(1));
                for (int i = 0; i < arr.GetLength(0); i++) 
                    for(int j = 0; j < arr.GetLength(1); j++)
                        file.WriteLine(arr[i, j]);

                file.Close();
            }
        }

        /// <summary>
        /// Чтение массива из файла
        /// </summary>
        /// <param name="arr">Массив</param>
        public static void OpenArr(ref int[] arr)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие массива";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);

                int len = Convert.ToInt32(file.ReadLine());
                arr = new int[len];

                for (int i = 0; i < arr.Length; i++) arr[i] = Convert.ToInt32(file.ReadLine());

                file.Close();
            }
        }

        /// <summary>
        /// Чтение Матрицы из файла
        /// </summary>
        /// <param name="arr">Матрица</param>
        public static void OpenArr(ref int[,] arr)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие массива";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new StreamReader(open.FileName);

                int rows = Convert.ToInt32(file.ReadLine());
                int cols = Convert.ToInt32(file.ReadLine());
                arr = new int[rows, cols];

                for (int i = 0; i < rows; i++) 
                    for(int j = 0; j < cols; j++)
                        arr[i, j] = Convert.ToInt32(file.ReadLine());

                file.Close();
            }
        }
    }
}
