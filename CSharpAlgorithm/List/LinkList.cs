/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：LinkList
* 创 建 者：Qing
* 创建时间：2018-05-06 14:39:15
* CLR 版本：4.0.30319.42000
* 保存的文件名：LinkList
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
 * 数据结构C#版笔记--单链表(LinkList) - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/10/17/1853562.html
 */
namespace CSharpAlgorithm
{
    public class LinkList<T> : IListDS<T>
    {
        private LinkNode<T> head;

        public LinkNode<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public LinkList()
        {
            head = null;
        }

        /// <summary>
        /// 类索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                return this.GetItemAt(index);
            }
        }

        /// <summary>
        /// 返回单链表的长度
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            LinkNode<T> p = head;
            int len = 0;
            while (p != null)
            {
                len++;
                p = p.Next;
            }
            return len;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            head = null;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == null;
        }

        /// <summary>
        /// 在最后附加元素
        /// </summary>
        /// <param name="item"></param>
        public void Append(T item)
        {
            LinkNode<T> d = new LinkNode<T>(item);
            LinkNode<T> n = new LinkNode<T>();

            if (head == null)
            {
                head = d;
                return;
            }

            n = head;
            while (n.Next != null)
            {
                n = n.Next;
            }
            n.Next = d;
        }

        //前插
        public void InsertBefore(T item, int i)
        {
            if (IsEmpty() || i < 0)
            {
                Console.WriteLine("List is empty or Position is error!");
                return;
            }

            //在最开头插入
            if (i == 0)
            {
                LinkNode<T> q = new LinkNode<T>(item);
                q.Next = Head;//把"头"改成第二个元素
                head = q;//把自己设置为"头"
                return;
            }

            LinkNode<T> n = head;
            LinkNode<T> d = new LinkNode<T>();
            int j = 0;

            //找到位置i的前一个元素d
            while (n.Next != null && j < i)
            {
                d = n;
                n = n.Next;
                j++;
            }

            if (n.Next == null) //说明是在最后节点插入(即追加)
            {
                LinkNode<T> q = new LinkNode<T>(item);
                n.Next = q;
                q.Next = null;
            }
            else
            {
                if (j == i)
                {
                    LinkNode<T> q = new LinkNode<T>(item);
                    d.Next = q;
                    q.Next = n;
                }
            }
        }

        /// <summary>
        /// 在位置i后插入元素item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        public void InsertAfter(T item, int i)
        {
            if (IsEmpty() || i < 0)
            {
                Console.WriteLine("List is empty or Position is error!");
                return;
            }

            if (i == 0)
            {
                LinkNode<T> q = new LinkNode<T>(item);
                q.Next = head.Next;
                head.Next = q;
                return;
            }

            LinkNode<T> p = head;
            int j = 0;

            while (p != null && j < i)
            {
                p = p.Next;
                j++;
            }
            if (j == i)
            {
                LinkNode<T> q = new LinkNode<T>(item);
                q.Next = p.Next;
                p.Next = q;
            }
            else
            {
                Console.WriteLine("Position is error!");
            }
        }

        /// <summary>
        /// 删除位置i的元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T RemoveAt(int i)
        {
            if (IsEmpty() || i < 0)
            {
                Console.WriteLine("Link is empty or Position is error!");
                return default(T);
            }

            LinkNode<T> q = new LinkNode<T>();
            if (i == 0)
            {
                q = head;
                head = head.Next;
                return q.Data;
            }

            LinkNode<T> p = head;
            int j = 0;

            while (p.Next != null && j < i)
            {
                j++;
                q = p;
                p = p.Next;
            }

            if (j == i)
            {
                q.Next = p.Next;
                return p.Data;
            }
            else
            {
                Console.WriteLine("The node is not exist!");
                return default(T);
            }
        }

        /// <summary>
        /// 获取指定位置的元素
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T GetItemAt(int i)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return default(T);
            }

            LinkNode<T> p = new LinkNode<T>();
            p = head;

            if (i == 0)
            {
                return p.Data;
            }

            int j = 0;

            while (p.Next != null && j < i)
            {
                j++;
                p = p.Next;
            }

            if (j == i)
            {
                return p.Data;
            }
            else
            {
                Console.WriteLine("The node is not exist!");
                return default(T);
            }
        }

        //按元素值查找索引
        public int IndexOf(T value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is Empty!");
                return -1;
            }
            LinkNode<T> p = new LinkNode<T>();
            p = head;
            int i = 0;
            while (!p.Data.Equals(value) && p.Next != null)
            {
                p = p.Next;
                i++;
            }
            return i;
        }

        /// <summary>
        /// 元素反转
        /// </summary>
        public void Reverse()
        {
            LinkList<T> result = new LinkList<T>();
            LinkNode<T> t = this.head;
            result.Head = new LinkNode<T>(t.Data);
            t = t.Next;

            //(把当前链接的元素从head开始遍历，逐个插入到另一个空链表中，这样得到的新链表正好元素顺序跟原链表是相反的)
            while (t != null)
            {
                result.InsertBefore(t.Data, 0);
                t = t.Next;
            }
            this.head = result.head;//将原链表直接挂到"反转后的链表"上
            result = null;//显式清空原链表的引用，以便让GC能直接回收
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            LinkNode<T> n = this.head;
            sb.Append(n.Data.ToString() + ",");
            while (n.Next != null)
            {
                sb.Append(n.Next.Data.ToString() + ",");
                n = n.Next;
            }
            return sb.ToString().TrimEnd(',');

        }
    }
}
