/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：GraphTraverse
* 创 建 者：Qing
* 创建时间：2018-05-06 16:40:53
* CLR 版本：4.0.30319.42000
* 保存的文件名：GraphTraverse
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
    /// 图的遍历算法
    /// </summary>
    public class GraphTraverse
    {
        //图的邻接矩阵
        private int[,] L { get; set; }
        //顶点数组
        private string[] Vertexs { get; set; }
        //顶点的数量
        private int VerNum { get; set; }
        //已访问的数组
        private bool[] Visited { get; set; }

        public GraphTraverse(string[] vers, int[,] l)
        {
            Vertexs = vers;
            L = l;
            VerNum = vers.Length;
            Visited = new bool[VerNum];
        }

        /// <summary>
        /// 深度优先遍历
        /// </summary>
        public void DFS()
        {

            for (int i = 0; i < Visited.Length; i++)
            {
                if (!Visited[i])
                {
                    DFS(i);
                }
            }

        }


        /// <summary>
        /// 广度优先遍历
        /// </summary>
        public void BFS()
        {
            var queue = new Queue<int>();
            for (int i = 0; i < VerNum; i++)
            {
                if (!Visited[i])
                {
                    Visited[i] = true;
                    queue.Enqueue(i);
                }
                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    Console.WriteLine(Vertexs[node]);
                    for (int j = FindFirstVertex(node); j >= 0; j = FindNextVertex(node, j))
                    {
                        if (!Visited[j])
                        {
                            Visited[j] = true;
                            queue.Enqueue(j);
                        }
                    }
                }
            }
        }


        private void DFS(int i)
        {
            Visited[i] = true;
            Console.WriteLine(Vertexs[i]);
            for (int j = FindFirstVertex(i); j >= 0; j = FindNextVertex(i, j))
            {
                if (!Visited[j])
                {
                    DFS(j);
                }
            }
        }

        /// <summary>
        /// 找到与i相邻的下一个顶点
        /// </summary>
        /// <param name="i"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private int FindNextVertex(int i, int k)
        {
            for (int j = k + 1; j < VerNum; j++)
            {
                if (L[i, j] > 0)
                {
                    return j;
                }
            }
            return -1;
        }


        /// <summary>
        /// 找到与i相邻的第一个顶点
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int FindFirstVertex(int i)
        {
            for (int j = 0; j < VerNum; j++)
            {
                if (L[i, j] > 0)
                {
                    return j;
                }
            }
            return -1;
        }

    }
}
