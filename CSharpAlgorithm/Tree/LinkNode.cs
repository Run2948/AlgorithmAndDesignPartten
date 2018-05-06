/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：LinkNode
* 创 建 者：Qing
* 创建时间：2018-05-06 15:09:13
* CLR 版本：4.0.30319.42000
* 保存的文件名：LinkNode
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
 * 数据结构C#版笔记--堆栈(Stack) - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/10/30/1865212.html
 */
namespace CSharpAlgorithm
{
    /// <summary>
    /// 定义节点 LinkNode
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkNode<T>
    {
        private T data;

        private LinkNode<T> next;

        public LinkNode(T data, LinkNode<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public LinkNode(LinkNode<T> next)
        {
            this.next = next;
            this.data = default(T);

        }

        public LinkNode(T data)
        {
            this.data = data;
            this.next = null;
        }

        public LinkNode()
        {
            this.data = default(T);
            this.next = null;
        }

        public T Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public LinkNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
