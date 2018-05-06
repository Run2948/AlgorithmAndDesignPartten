/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：HuffNode
* 创 建 者：Qing
* 创建时间：2018-05-06 15:49:57
* CLR 版本：4.0.30319.42000
* 保存的文件名：HuffNode
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
    public class HuffNode
    {
        private int weight;//权重值
        private int lChild;//左子节点的序号
        private int rChild;//右子节点的序号
        private int index;//本节点的序号

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int LChild
        {
            get { return this.lChild; }
            set { lChild = value; }
        }

        public int RChild
        {
            get { return this.rChild; }
            set { rChild = value; }
        }

        public int Index
        {
            get { return this.index; }
            set { index = value; }
        }

        public HuffNode()
        {
            weight = 0;
            lChild = -1;
            rChild = -1;
            index = -1;
        }

        public HuffNode(int w, int lc, int rc, int p)
        {
            weight = w;
            lChild = lc;
            rChild = rc;
            index = p;
        }
    }
}
