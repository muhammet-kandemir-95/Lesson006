using System;

namespace Lesson006
{
    public class Program_ModifyArray
    {
        public static int[] Add(int[] arr, int item)
        {
            int[] newArr = new int[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            newArr[newArr.Length - 1] = item;

            return newArr;
        }

        public static int[] RemoveAt(int[] arr, int index)
        {
            int[] newArr = new int[arr.Length - 1];

            for (int i = 0; i < arr.Length; i++)
            {
                if (i != index && i < index)
                {
                    newArr[i] = arr[i];
                }
                else if (i != index && i > index)
                {
                    newArr[i - 1] = arr[i];
                }
            }

            return newArr;
        }

        public static int[] RemoveInterval(int[] arr, int startIndex, int endIndex)
        {
            int itemCountToBeRemoved = (endIndex - startIndex) + 1;
            int[] newArr = new int[arr.Length - itemCountToBeRemoved];

            for (int i = 0; i < arr.Length; i++)
            {
                if (i < startIndex)
                {
                    newArr[i] = arr[i];
                }
                else if (i > endIndex)
                {
                    newArr[i - itemCountToBeRemoved] = arr[i];
                }
            }

            return newArr;
        }

        public static int[] RemoveInterval(int[] arr, int[] removedIndexes)
        {
            int removedItemCount = removedIndexes.Length;
            int[] newArr = new int[arr.Length - removedItemCount];

            int passedItemCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                bool isRemovedIndex = false;
                for (int j = 0; j < removedIndexes.Length; j++)
                {
                    if (i == removedIndexes[j])
                    {
                        isRemovedIndex = true;
                        break;
                    }
                }

                if (isRemovedIndex)
                {
                    passedItemCount++;
                }
                else
                {
                    newArr[i - passedItemCount] = arr[i];
                }
            }

            return newArr;
        }

        public static void Main_ModifyArray(string[] args)
        {
            int[] arr = { 1, 2, 3, 4 };
            int[] newArr = Add(arr, 23); // { 1, 2, 3, 4, 23 }
            newArr = RemoveAt(newArr, 1); // { 1, 3, 4, 23 }
            newArr = RemoveInterval(newArr, 0, 2); // { 23 }
            newArr = Add(newArr, 5); // { 23, 5 }
            newArr = Add(newArr, 7); // { 23, 5, 7 }
            newArr = Add(newArr, 2); // { 23, 5, 7, 2 }
            newArr = Add(newArr, 11); // { 23, 5, 7, 2, 11 }
            newArr = Add(newArr, 39); // { 23, 5, 7, 2, 11, 39 }
            newArr = RemoveInterval(newArr, new int[] { 0, 2, 3, 5 }); // { 5, 11 }
        }
    }
}