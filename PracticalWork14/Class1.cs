using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork14
{
    internal class Class1
    {
        /// <summary>
        /// По массиву A(n,m) получить массив В(m), присвоив его j-элементу значение true, 
        /// если все элементы j-столбца массива А нулевые, и значение false иначе
        /// </summary>
        /// <param name="matr">Массив A(n,m)</param>
        /// <param name="colIndex">Номер столбца</param>
        /// <returns>True, если все значения столбца равны 0; Иначе false</returns>
        public static bool ColumnOfZeros(int[,] matr, int colIndex)
        {
            bool isZero = true;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                if (matr[i, colIndex] != 0)
                {
                    isZero = false;
                    break;
                }
            }
            return isZero;
        }
    }
}
