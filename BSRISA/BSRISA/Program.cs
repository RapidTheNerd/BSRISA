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
            int[] array = new int[10] { 5, 6, 7, 8, 9, 10, 12, 15, 20, 30 };
            int numberToFind = 10;
            int index = FindIndexRecursive(numberToFind, array, 0, array.Length - 1);
            Console.WriteLine("the number " + numberToFind + "is located at index: " + index);
            index = FindIndexIterative(numberToFind, array, 0, array.Length - 1);
            Console.WriteLine("the number " + numberToFind + "is located at index: " + index);
            int[] shiftedArray = new int[6] { 10, 20, 1, 2, 3, 4 };

            index = FindShiftedArray(numberToFind, shiftedArray, 0, array.Length - 1);
        }

        private int FindShiftedArray(int numberToFind, int[] shiftedArray, int indexMin, int indexMax)
        {
            int pivot = FindPivot(shiftedArray, 0, shiftedArray.Length - 1);
      
            if (shiftedArray[pivot] == numberToFind)
                return pivot;
            if (shiftedArray[0] <= numberToFind)
            {
                return FindIndexRecursive(numberToFind, shiftedArray, 0, pivot - 1);
            }
            else
            {
                return FindIndexRecursive(numberToFind, shiftedArray, pivot + 1, shiftedArray.Length - 1);
            }
        }

        private int FindPivot(int[] array, int indexMin, int indexMax)
        {

            if (indexMax < indexMin)
            {
                return -1;
            }
            if (indexMax == indexMin)
            {
                return indexMin;
            }
            int mid = (indexMin + indexMax) / 2; 
            if (mid < indexMax && array[mid] > array[mid + 1])
            {
                return mid;
            }
            if (mid > indexMin && array[mid] < array[mid - 1])
            {
                return (mid - 1);
            }
            if (array[indexMin] >= array[mid])
            {
                return FindPivot(array, indexMin, mid - 1);
            }
            else
            {
                return FindPivot(array, mid + 1, indexMax);
            }
        }

        public int FindIndexRecursive(int numberToFind, int[] array, int indexMin, int indexMax)
        {
            if (indexMin > indexMax)
            {
                return -1;
            }

            int mid = ((indexMax - indexMin) / 2) + indexMin;

            if (array[mid] < numberToFind)
            {
                return FindIndexRecursive(numberToFind, array, mid, indexMax);
            }
            else if (numberToFind < array[mid])
            {
                return FindIndexRecursive(numberToFind, array, indexMin, mid);
            }
            else
            {
                return mid;
            }
        }

        public int FindIndexIterative(int numberToFind, int[] array, int indexMin, int indexMax)
        {
            while (indexMin < indexMax)
            {
                int mid = ((indexMax - indexMin) / 2) + indexMin;
                if (array[mid] < numberToFind)
                {
                    indexMin = mid;
                }
                else if (numberToFind < array[mid])
                {
                    indexMax = mid;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}