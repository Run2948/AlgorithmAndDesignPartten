/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：Dijkstra
* 创 建 者：Qing
* 创建时间：2018-05-06 16:39:18
* CLR 版本：4.0.30319.42000
* 保存的文件名：Dijkstra
* 文件版本：V1.0.0.0
*
* 功能描述：N/A 
*
* 修改历史：
*
*
* ==============================================================================
*         CopyRight @ 班纳工作室 2018. All rights reserved
* ==============================================================================*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAlgorithm
{
    /// <summary>
    /// Dijkstra(迪杰斯特拉)最短路径算法
    /// </summary>
    public class Dijkstra
    {
        public int Rank { get; set; }
        public int[] D { get; set; }
        public int[] C { get; set; }
        public int[,] L { get; set; }

        public Dijkstra(int rankparam, int[,] paramarr)
        {
            Rank = rankparam;
            C = new int[rankparam];
            D = new int[rankparam];
            L = paramarr;
            for (int i = 0; i < rankparam; i++)
            {
                C[i] = i;
            }
            C[0] = -1;
            for (int j = 1; j < rankparam; j++)
            {
                D[j] = L[0, j];
            }
        }

        public void Display()
        {
            for (int i = 1; i < Rank; i++)
            {
                Console.WriteLine($"第{i}次遍历：");
                DijkstraSolving();
                foreach (int t in D)
                {
                    Console.Write(t + " ");
                }
                Console.WriteLine();
                foreach (var t in C)
                {
                    Console.Write(t + " ");
                }
                Console.WriteLine();
            }
        }

        public void DijkstraSolving()
        {
            int minValue = int.MaxValue;
            int minNode = 0;
            for (int i = 0; i < this.Rank; i++)
            {
                if (C[i] == -1)
                {
                    continue;
                }
                if (D[i] > 0 && D[i] < minValue)
                {
                    minValue = D[i];
                    minNode = i;
                }
            }
            C[minNode] = -1;
            for (int i = 0; i < Rank; i++)
            {
                if (L[minNode, i] < 0)
                {
                    continue;
                }
                if (D[i] < 0)
                {
                    D[i] = minValue + L[minNode, i];
                    continue;
                }
                if (minValue + L[minNode, i] < D[i])
                {
                    D[i] = minValue + L[minNode, i];
                }
            }
        }
    }
}
