/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：LinkStack
* 创 建 者：Qing
* 创建时间：2018-05-06 15:05:37
* CLR 版本：4.0.30319.42000
* 保存的文件名：LinkStack
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
    /// 链式堆栈(LinkStack)的实现
    /// </summary>
    public class LinkStack<T> : IStack<T>
    {
        private LinkNode<T> top;
        private int num;//节点个数

        /// <summary>
        /// 顶部节点
        /// </summary>
        public LinkNode<T> Top
        {
            get { return top; }
            set { top = value; }
        }


        public LinkStack()
        {
            top = null;
            num = 0;
        }

        public int Count()
        {
            return num;
        }

        public void Clear()
        {
            top = null;
            num = 0;
        }

        public bool IsEmpty()
        {
            if (top == null && num == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Push(T item)
        {
            LinkNode<T> q = new LinkNode<T>(item);
            if (top == null)
            {
                top = q;
            }
            else
            {
                q.Next = top;
                top = q;
            }
            num++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return default(T);
            }
            LinkNode<T> p = top;
            top = top.Next;
            num--;

            return p.Data;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return default(T);
            }
            return top.Data;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (top != null)
            {
                sb.Append(top.Data.ToString() + ",");
                LinkNode<T> p = top;
                while (p.Next != null)
                {
                    sb.Append(p.Next.Data.ToString() + ",");
                    p = p.Next;
                }
            }

            return sb.ToString();
        }



        static void Test(string[] args)
        {
            #region 链堆栈
            Console.WriteLine("链堆栈测试开始...");
            LinkStack<int> linkStack = new LinkStack<int>();
            linkStack.Push(1);
            linkStack.Push(2);
            linkStack.Push(3);

            Console.WriteLine(linkStack);
            Console.WriteLine(linkStack.Peek());
            Console.WriteLine(linkStack);
            Console.WriteLine(linkStack.Pop());
            Console.WriteLine(linkStack);

            Console.ReadLine();
            #endregion
        }
    }
}
