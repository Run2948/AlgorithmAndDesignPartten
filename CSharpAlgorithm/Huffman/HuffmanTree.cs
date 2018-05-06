/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：HuffmanTree
* 创 建 者：Qing
* 创建时间：2018-05-06 15:50:53
* CLR 版本：4.0.30319.42000
* 保存的文件名：HuffmanTree
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

/**
 * 数据结构C#版笔记--啥夫曼树(Huffman Tree)与啥夫曼编码(Huffman Encoding) - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/12/03/1895840.html
 */
namespace CSharpAlgorithm
{
    /// <summary>
    /// 哈夫曼树Huffman tree 又称最优完全二叉树
    /// </summary>
    public class HuffmanTree
    {
        private List<HuffNode> _tmp;
        private List<HuffNode> _nodes;

        public HuffmanTree(params int[] weights)
        {
            if (weights.Length < 2)
            {
                throw new Exception("叶节点不能少于2个!");
            }

            int n = weights.Length;

            Array.Sort(weights);

            //先生成叶子节点，并按weight从小到大排序
            List<HuffNode> lstLeafs = new List<HuffNode>(n);
            for (int i = 0; i < n; i++)
            {
                var node = new HuffNode();
                node.Weight = weights[i];
                node.Index = i;
                lstLeafs.Add(node);
            }


            //创建临时节点容器
            _tmp = new List<HuffNode>(2 * n - 1);

            //真正存放所有节点的容器
            _nodes = new List<HuffNode>(_tmp.Capacity);

            _tmp.AddRange(lstLeafs);
            _nodes.AddRange(_tmp);
        }

        /// <summary>
        /// 构造Huffman树
        /// </summary>
        public void Create()
        {
            while (this._tmp.Count > 1)
            {
                var tmp = new HuffNode(this._tmp[0].Weight + this._tmp[1].Weight, _tmp[0].Index, _tmp[1].Index,
                    this._tmp.Max(c => c.Index) + 1);
                this._tmp.Add(tmp);
                this._nodes.Add(tmp);

                //删除已经处理过的二个节点
                this._tmp.RemoveAt(0);
                this._tmp.RemoveAt(0);


                //重新按权重值从小到大排序
                this._tmp = this._tmp.OrderBy(c => c.Weight).ToList();
            }
        }

        /// <summary>
        /// 测试输出各节点的关键值(调试用)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _nodes.Count; i++)
            {
                var n = _nodes[i];
                sb.AppendLine("index:" + i + "，weight:" + n.Weight.ToString().PadLeft(2, ' ') + "，lChild_index:" +
                              n.LChild.ToString().PadLeft(2, ' ') + "，rChild_index:" +
                              n.RChild.ToString().PadLeft(2, ' '));
            }

            return sb.ToString();
        }


        static void Test(string[] args)
        {
            #region 哈夫曼
            HuffmanTree huffTree = new HuffmanTree(2, 1, 4, 3);
            huffTree.Create();

            Console.WriteLine("最终树的节点值如下：");
            Console.WriteLine(huffTree.ToString()); 
            // 输出结果也许并不直观，对照下面这张图就明白了：
            // https://pic002.cnblogs.com/images/2010/27612/2010120513101331.png
            Console.ReadLine();
            #endregion

        }
    }
}
