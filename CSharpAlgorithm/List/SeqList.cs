/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：SeqList
* 创 建 者：Qing
* 创建时间：2018-05-06 14:41:06
* CLR 版本：4.0.30319.42000
* 保存的文件名：SeqList
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
 * 顺序表(SeqList)的实现
 * 数据结构C#版笔记--顺序表(SeqList) - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/10/17/1853376.html
 */
namespace CSharpAlgorithm
{
    /// <summary>
    /// 顺序表
    ///     优点：读取元素时可直接定位，所以在某些操作(比如将顺序表元素反转合围)中，不需要完全遍历，循环次数(即时间复杂度)相对完全遍历而言能减少一半。
    ///     缺点：插入/删除元素，因为要保持其顺序性，所以后续元素需要移动，增加了时间开销。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SeqList<T> : IListDS<T>
    {
        private int maxsize;
        private T[] data;
        private int last;

        //类索引器
        public T this[int index]
        {
            get
            {
                return this.GetItemAt(index);
            }
            set
            {
                if (index < 0 || index > last + 1)
                {
                    Console.WriteLine("Position is error");
                    return;
                }
                data[index] = value;
            }
        }

        //最后一个元素的下标
        public int Last
        {
            get { return last; }
        }

        //最大容量
        public int Maxsize
        {
            get { return this.maxsize; }
            set { this.maxsize = value; }
        }

        //构造函数
        public SeqList(int size)
        {
            data = new T[size];
            maxsize = size;
            last = -1;
        }

        //返回链表的实际长度
        public int Count()
        {
            return last + 1;
        }

        //清空
        public void Clear()
        {
            last = -1;
        }

        //是否空
        public bool IsEmpty()
        {
            return last == -1;
        }

        //是否满
        public bool IsFull()
        {
            return last == maxsize - 1;
        }

        //(在最后位置)追加元素
        public void Append(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("List is full");
                return;
            }
            data[++last] = item;
        }

        /// <summary>
        ///前插
        /// </summary>
        /// <param name="item">要插入的元素</param>
        /// <param name="i">要插入的位置索引</param>
        public void InsertBefore(T item, int i)
        {
            if (IsFull())
            {
                Console.WriteLine("List is full");
                return;
            }

            if (i < 0 || i > last + 1)
            {
                Console.WriteLine("Position is error");
                return;
            }

            if (i == last + 1)
            {
                data[last + 1] = item;
            }
            else
            {
                //位置i及i以后的元素，全部后移
                for (int j = last; j >= i; j--)
                {
                    data[j + 1] = data[j];
                }
                data[i] = item;
            }
            ++last;
        }

        /// <summary>
        /// 后插
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        public void InsertAfter(T item, int i)
        {
            if (IsFull())
            {
                Console.WriteLine("List is full");
                return;
            }

            if (i < 0 || i > last)
            {
                Console.WriteLine("Position is error");
                return;
            }

            if (i == last)
            {
                data[last + 1] = item;
            }
            else
            {
                //位置i以后的元素(不含位置i)，全部后移
                for (int j = last; j > i; j--)
                {
                    data[j + 1] = data[j];
                }
                data[i + 1] = item;
            }
            ++last;
        }

        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="i">要删除的元素索引</param>
        /// <returns></returns>
        public T RemoveAt(int i)
        {
            T tmp = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("List is empty");
                return tmp;
            }

            if (i < 0 || i > last)
            {
                Console.WriteLine("Position is error!");
                return tmp;
            }

            if (i == last)
            {
                tmp = data[last];
            }
            else
            {
                tmp = data[i];
                //位置i以及i以后的元素前移
                for (int j = i; j <= last; j++)
                {
                    data[j] = data[j + 1];
                }
            }
            --last;
            return tmp;
        }

        /// <summary>
        /// 获取第几个位置的元素
        /// </summary>
        /// <param name="i">第几个位置</param>
        /// <returns></returns>
        public T GetItemAt(int i)
        {
            if (IsEmpty() || (i < 0) || (i > last))
            {
                Console.WriteLine("List is empty or Position is error!");
                return default(T);
            }
            return data[i];
        }

        /// <summary>
        /// 定位元素的下标索引
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is Empty!");
                return -1;
            }
            int i = 0;
            for (i = 0; i <= last; i++)
            {
                if (value.Equals(data[i]))
                {
                    break;
                }
            }
            if (i > last)
            {
                return -1;
            }
            return i;
        }

        /// <summary>
        /// 元素反转
        /// </summary>
        public void Reverse()
        {
            T tmp = default(T);
            for (int i = 0; i <= last / 2; i++)
            {
                tmp = data[i];
                data[i] = data[last - i];
                data[last - i] = tmp;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= last; i++)
            {
                sb.Append(data[i].ToString() + "，");
            }
            return sb.ToString().TrimEnd('，');
        }


        static void Test(string[] args)
        {
            #region 顺序表
            Console.WriteLine("顺序表测试开始...");
            SeqList<string> seq = new SeqList<string>(10);

            seq.Append("x");
            seq.InsertBefore("w", 0);
            seq.InsertBefore("v", 0);
            seq.Append("y");
            seq.InsertBefore("z", seq.Count());
            Console.WriteLine(seq.Count());//5
            Console.WriteLine(seq.ToString());//v,w,x,y,z
            Console.WriteLine(seq[1]);//w
            Console.WriteLine(seq[0]);//v
            Console.WriteLine(seq[4]);//z
            Console.WriteLine(seq.IndexOf("z"));//4
            Console.WriteLine(seq.RemoveAt(2));//x
            Console.WriteLine(seq.ToString());//v,w,y,z
            seq.InsertBefore("x", 2);
            Console.WriteLine(seq.ToString());//v,w,x,y,z
            Console.WriteLine(seq.GetItemAt(2));//x
            seq.Reverse();
            Console.WriteLine(seq.ToString());//z,y,x,w,v

            seq.InsertAfter("z_1", 0);
            seq.InsertAfter("y_1", 2);
            seq.InsertAfter("v_1", seq.Count() - 1);
            Console.WriteLine(seq.ToString());//z，z_1，y，y_1，x，w，v，v_1
            #endregion
        }

    }
}
