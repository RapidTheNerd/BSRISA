using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSRISA
{
    class Program
    {
        public Program()
        {
            int[] array = new int[10] { 5, 6, 7, 8, 9, 10, 12, 28, 30, 2 };
            int numToFind = 10;
        }

        private int findInShiftedArray(int numberToFind, int[] shiftedArray, int indexMin, int indexMax)
        {
            
        }

        private int findPivot(int[] array, int indexMin, int indexMax)
        {
            if(indexMax < indexMin)
            {
                return -1;
            }
            if(indexMax == indexMin)
            {
                return indexMin;
            }
            int mid = (indexMin + indexMax) / 2;
            if(mid < indexMax && array[mid] > array[mid + 1])
            {
                return (mid - 1);
            }
            if(array[indexMin] >= array[mid])
            {
                return findPivot(array, indexMin, mid - 1);
            } else
            {
                return findPivot(array, mid + 1, indexMax);
            }
        }
    }

}
