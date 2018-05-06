/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：Node
* 创 建 者：Qing
* 创建时间：2018-05-06 14:27:52
* CLR 版本：4.0.30319.42000
* 保存的文件名：Node
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
 * 数据结构C#版笔记--树与二叉树 - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/12/01/1892403.html
 */
namespace CSharpAlgorithm
{
    public class Node<T>
    {
        private T data;
        private Node<T> lChild;//左子节点
        private Node<T> rChild;//右子节点

        public Node(T data, Node<T> ln, Node<T> rn)
        {
            this.data = data;
            this.lChild = ln;
            this.rChild = rn;
        }

        public Node(Node<T> ln, Node<T> rn)
        {
            this.data = default(T);
            this.lChild = ln;
            this.rChild = rn;
        }

        public Node(T data)
        {
            this.data = data;
            lChild = null;
            rChild = null;
        }

        public Node()
        {
            data = default(T);
            lChild = null;
            rChild = null;
        }

        public T Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public Node<T> LChild
        {
            get { return this.lChild; }
            set { this.lChild = value; }
        }

        public Node<T> RChild
        {
            get { return this.rChild; }
            set { this.rChild = value; }
        }
    }
}
