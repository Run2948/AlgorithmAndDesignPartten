/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：SeqStack
* 创 建 者：Qing
* 创建时间：2018-05-06 15:05:04
* CLR 版本：4.0.30319.42000
* 保存的文件名：SeqStack
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
    /// 顺序堆栈(SeqStack)的实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SeqStack<T> : IStack<T>
    {
        private int maxsize;
        private T[] data;
        private int top;


        public SeqStack(int size)
        {
            data = new T[size];
            maxsize = size;
            top = -1;
        }

        #region //接口实现部分
        public int Count()
        {
            return top + 1;
        }

        public void Clear()
        {
            top = -1;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public void Push(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack is full");
                return;
            }
            data[++top] = item;
        }


        public T Pop()
        {
            T tmp = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return tmp;
            }
            tmp = data[top];
            top--;
            return tmp;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return default(T);
            }
            return data[top];
        }
        #endregion

        public bool IsFull()
        {
            return top == maxsize - 1;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = top; i >= 0; i--)
            {
                sb.Append(data[i] + ",");
            }
            return sb.ToString().Trim(',');
        }


        static void Test(string[] args)
        {
            #region 顺序堆栈
            Console.WriteLine("顺序堆栈测试开始...");
            SeqStack<int> seqStack = new SeqStack<int>(10);
            seqStack.Push(1);
            seqStack.Push(2);
            seqStack.Push(3);

            Console.WriteLine(seqStack);
            Console.WriteLine(seqStack.Peek());
            Console.WriteLine(seqStack);
            Console.WriteLine(seqStack.Pop());
            Console.WriteLine(seqStack);

            #endregion
        }

    }
}
