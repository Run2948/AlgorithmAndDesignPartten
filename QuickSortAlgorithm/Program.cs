using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortAlgorithm
{
    class Program
    {
        /* 今天介绍快速排序，这也是在实际中最常用的一种排序算法，速度快，效率高。就像名字一样，快速排序是最优秀的一种排序算法。
         * *********************************************************************************************************************************************************************************
         * 
         * 思想
         * 快速排序采用的思想是分治思想。
         * 快速排序是找出一个元素（理论上可以随便找一个）作为基准(pivot),然后对数组进行分区操作,使基准左边元素的值都不大于基准值,基准右边的元素值 都不小于基准值，如此作为基准的元素调整到排序后的正确位置。递归快速排序，将其他n-1个元素也调整到排序后的正确位置。最后每个元素都是在排序后的正 确位置，排序完成。所以快速排序算法的核心算法是分区操作，即如何调整基准的位置以及调整返回基准的最终位置以便分治递归。
         * 举例说明一下吧，这个可能不是太好理解。假设要排序的序列为
         * 2 2 4 9 3 6 7 1 5 首先用2当作基准，使用i j两个指针分别从两边进行扫描，把比2小的元素和比2大的元素分开。首先比较2和5，5比2大，j左移
         * 
         * 2 2 4 9 3 6 7 1 5 比较2和1，1小于2，所以把1放在2的位置
         * 
         * 2 1 4 9 3 6 7 1 5 比较2和4，4大于2，因此将4移动到后面
         * 
         * 2 1 4 9 3 6 7 4 5 比较2和7，2和6，2和3，2和9，全部大于2，满足条件，因此不变
         * 
         * 经过第一轮的快速排序，元素变为下面的样子
         * 
         * [1] 2 [4 9 3 6 7 5]
         * 
         * 之后，在把2左边的元素进行快排，由于只有一个元素，因此快排结束。右边进行快排，递归进行，最终生成最后的结果。
        ***********************************************************************************************************************************************************************************/

        static void Main(string[] args)
        {
            int[] arr = { 5, 1, 3, 99, -5, 4, 2, 7, 9, 100 };
            QuickSort(arr, 0, arr.Length - 1);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }


        private static int FindPos(int[] arr, int low, int hi)
        {
            var val = arr[low];
            while (low < hi)
            {
                while (low < hi && arr[hi] >= val)
                {
                    hi--;
                }
                arr[low] = arr[hi];
                while (low < hi && arr[low] <= val)
                {
                    low++;
                }
                arr[hi] = arr[low];
            }
            arr[low] = val;
            return low;
        }


        private static void QuickSort(int[] arr, int low, int hi)
        {
            int pos = 0;
            if (hi > low)
            {
                pos = FindPos(arr, low, hi);
                QuickSort(arr, low, pos - 1);
                QuickSort(arr, pos + 1, hi);
            }
        }

    }
}
