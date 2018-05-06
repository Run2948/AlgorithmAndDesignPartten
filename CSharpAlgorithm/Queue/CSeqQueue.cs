/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：CSeqQueue
* 创 建 者：Qing
* 创建时间：2018-05-06 14:59:52
* CLR 版本：4.0.30319.42000
* 保存的文件名：CSeqQueue
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
    /// 循环顺序队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CSeqQueue<T> :IQueue<T>
    {
        private int maxsize;
        private T[] data;
        private int front;
        private int rear;


        public CSeqQueue(int size)
        {
            data = new T[size];
            maxsize = size;
            front = rear = -1;
        }

        public int Count()
        {
            if (rear > front)
            {
                return rear - front;
            }
            else
            {
                return (rear - front + maxsize) % maxsize;
            }
        }


        public void Clear()
        {
            front = rear = -1;
        }

        public bool IsEmpty()
        {
            return front == rear;
        }

        public bool IsFull()
        {
            if (front != -1) //如果已经有元素出队过
            {
                return (rear + 1) % maxsize == front;//为了区分与IsEmpty的区别，有元素出队过以后，就只有浪费一个位置来保持逻辑正确性.
            }
            else
            {
                return rear == maxsize - 1;
            }
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full");
                return;
            }
            if (rear == maxsize - 1) //如果rear到头了，则循环重来（即解决伪满问题）
            {
                rear = 0;
            }
            else
            {
                rear++;
            }
            data[rear] = item;
        }


        public T Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return default(T);
            }
            if (front == maxsize - 1) //如果front到头了，则重新置0
            {
                front = 0;
            }
            else
            {
                front++;
            }
            return data[front];
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty!");
                return default(T);
            }
            return data[(front + 1) % maxsize];
        }

        public override string ToString()
        {
            if (IsEmpty()) { return "queue is empty."; }

            StringBuilder sb = new StringBuilder();

            if (rear > front)
            {
                for (int i = front + 1; i <= rear; i++)
                {
                    sb.Append(this.data[i].ToString() + ",");
                }
            }
            else
            {
                for (int i = front + 1; i < maxsize; i++)
                {
                    sb.Append(this.data[i].ToString() + ",");
                }

                for (int i = 0; i <= rear; i++)
                {
                    sb.Append(this.data[i].ToString() + ",");
                }
            }
            return "front = " + this.front + " \t rear = " + this.rear + "\t count = " + this.Count() + "\t data = " + sb.ToString().Trim(',');
        }


        static void Test(string[] args)
        {
            #region 循环队列
            CSeqQueue<int> queue = new CSeqQueue<int>(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine(queue);//front = -1       rear = 3        count = 4       data = 1,2,3,4
            queue.Dequeue();
            Console.WriteLine(queue);//front = 0        rear = 3        count = 3       data = 2,3,4
            queue.Dequeue();
            Console.WriteLine(queue);//front = 1        rear = 3        count = 2       data = 3,4
            queue.Enqueue(5);
            Console.WriteLine(queue);//front = 1        rear = 4        count = 3       data = 3,4,5
            queue.Enqueue(6);
            Console.WriteLine(queue);//front = 1        rear = 0        count = 4       data = 3,4,5,6
            queue.Enqueue(7);        //Queue is full
            Console.WriteLine(queue);//front = 1        rear = 0        count = 4       data = 3,4,5,6
            queue.Dequeue();
            queue.Enqueue(7);
            Console.WriteLine(queue);//front = 2        rear = 1        count = 4       data = 4,5,6,7

            queue.Clear();
            Console.WriteLine(queue);//queue is empty.

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine(queue);//front = -1       rear = 3        count = 4       data = 1,2,3,4
            queue.Enqueue(5);
            Console.WriteLine(queue);//front = -1       rear = 4        count = 5       data = 1,2,3,4,5
            queue.Enqueue(6);        //Queue is full
            Console.WriteLine(queue);//front = -1       rear = 4        count = 5       data = 1,2,3,4,5
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine(queue);//front = 3        rear = 4        count = 1       data = 5
            queue.Dequeue();
            Console.WriteLine(queue);//queue is empty.
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);        //Queue is full
            Console.WriteLine(queue);//front = 4        rear = 3        count = 4       data = 0,1,2,3
            Console.WriteLine(queue.Peek());//0
            queue.Dequeue();
            Console.WriteLine(queue);//front = 0        rear = 3        count = 3       data = 1,2,3
            queue.Dequeue();
            Console.WriteLine(queue);//front = 1        rear = 3        count = 2       data = 2,3
            queue.Dequeue();
            Console.WriteLine(queue);//front = 2        rear = 3        count = 1       data = 3
            queue.Dequeue();
            Console.WriteLine(queue);//queue is empty.
            queue.Enqueue(9);
            Console.WriteLine(queue);//front = 3        rear = 4        count = 1       data = 9
            Console.ReadLine();
            #endregion
        }
    }
}
