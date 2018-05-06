/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：LinkQueue
* 创 建 者：Qing
* 创建时间：2018-05-06 15:21:19
* CLR 版本：4.0.30319.42000
* 保存的文件名：LinkQueue
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
    public class LinkQueue<T> : IQueue<T>
    {
        private LinkNode<T> front;//队列头
        private LinkNode<T> rear;//队列尾
        private int num;//队列元素个数

        /// 
        /// 构造器
        /// 
        public LinkQueue()
        {
            //初始时front,rear置为null，num置0
            front = rear = null;
            num = 0;
        }

        public int Count()
        {
            return this.num;
        }


        public void Clear()
        {
            front = rear = null;
            num = 0;
        }

        public bool IsEmpty()
        {
            return (front == rear && num == 0);
        }

        //入队
        public void Enqueue(T item)
        {
            LinkNode<T> q = new LinkNode<T>(item);

            if (rear == null)//第一个元素入列时
            {
                front = rear = q;
            }
            else
            {
                //把新元素挂到链尾
                rear.Next = q;
                //修正rear指向为最后一个元素
                rear = q;
            }
            //元素总数+1
            num++;
        }

        //出队
        public T Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty!");
                return default(T);
            }

            //取链首元素
            LinkNode<T> p = front;

            //链头指向后移一位
            front = front.Next;

            //如果此时链表为空，则同步修正rear
            if (front == null)
            {
                rear = null;
            }

            num--;//个数-1

            return p.Data;
        }


        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty!");
                return default(T);
            }

            return front.Data;
        }


        public override string ToString()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty!");
            }

            StringBuilder sb = new StringBuilder();

            LinkNode<T> node = front;

            sb.Append(node.Data.ToString());

            while (node.Next != null)
            {
                sb.Append("," + node.Next.Data.ToString());
                node = node.Next;
            }

            return sb.ToString().Trim(',');
        }



        static void Test(string[] args)
        {
            #region 链式队列

            LinkQueue<int> Lqueue = new LinkQueue<int>();
            Lqueue.Enqueue(1);
            Lqueue.Enqueue(2);
            Lqueue.Enqueue(3);
            Lqueue.Enqueue(4);
            Console.WriteLine(Lqueue);
            Lqueue.Dequeue();
            Console.WriteLine(Lqueue);
            Console.WriteLine(Lqueue.Count());

            #endregion
        }

    }
}
