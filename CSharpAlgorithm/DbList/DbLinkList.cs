/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：DbLinkList
* 创 建 者：Qing
* 创建时间：2018-05-06 15:16:04
* CLR 版本：4.0.30319.42000
* 保存的文件名：DbLinkList
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
 * 数据结构C#版笔记--双向链表(DbLinkList) - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/10/24/1859689.html
 */
namespace CSharpAlgorithm
{
    public class DbLinkList<T> : IListDS<T>
    {
        private DbNode<T> head;

        public DbNode<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public DbLinkList()
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
            DbNode<T> p = head;
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
            DbNode<T> d = new DbNode<T>(item);
            DbNode<T> n = new DbNode<T>();

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
            d.Prev = n;
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
                DbNode<T> q = new DbNode<T>(item);
                q.Next = head;//把"头"改成第二个元素
                head.Prev = q;
                head = q;//把自己设置为"头"
                return;
            }

            DbNode<T> n = head;
            DbNode<T> d = new DbNode<T>();
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
                DbNode<T> q = new DbNode<T>(item);
                n.Next = q;
                q.Prev = n;
                q.Next = null;
            }
            else
            {
                if (j == i)
                {
                    DbNode<T> q = new DbNode<T>(item);
                    d.Next = q;
                    q.Prev = d;
                    q.Next = n;
                    n.Prev = q;
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
                DbNode<T> q = new DbNode<T>(item);
                q.Next = head.Next;
                head.Next.Prev = q;
                head.Next = q;
                q.Prev = head;
                return;
            }

            DbNode<T> p = head;
            int j = 0;

            while (p != null && j < i)
            {
                p = p.Next;
                j++;
            }
            if (j == i)
            {
                DbNode<T> q = new DbNode<T>(item);
                q.Next = p.Next;
                if (p.Next != null)
                {
                    p.Next.Prev = q;
                }
                p.Next = q;
                q.Prev = p;
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

            DbNode<T> q = new DbNode<T>();
            if (i == 0)
            {
                q = head;
                head = head.Next;
                head.Prev = null;
                return q.Data;
            }

            DbNode<T> p = head;
            int j = 0;

            while (p.Next != null && j < i)
            {
                j++;
                q = p;
                p = p.Next;
            }

            if (j == i)
            {
                p.Next.Prev = q;
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

            DbNode<T> p = new DbNode<T>();
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
            DbNode<T> p = new DbNode<T>();
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
            DbLinkList<T> result = new DbLinkList<T>();
            DbNode<T> t = this.head;
            result.Head = new DbNode<T>(t.Data);
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

        //得到某个指定的节点(为了下面测试从后向前遍历)
        private DbNode<T> GetNodeAt(int i)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty!");
                return null;
            }

            DbNode<T> p = new DbNode<T>();
            p = head;

            if (i == 0)
            {
                return p;
            }

            int j = 0;

            while (p.Next != null && j < i)
            {
                j++;
                p = p.Next;
            }

            if (j == i)
            {
                return p;
            }
            else
            {
                Console.WriteLine("The node is not exist!");
                return null;
            }
        }

        /// <summary>
        /// 测试用prev属性从后面开始遍历
        /// </summary>
        /// <returns></returns>
        public string TestPrevErgodic()
        {
            DbNode<T> tail = GetNodeAt(Count() - 1);
            StringBuilder sb = new StringBuilder();
            sb.Append(tail.Data.ToString() + ",");
            while (tail.Prev != null)
            {
                sb.Append(tail.Prev.Data.ToString() + ",");
                tail = tail.Prev;
            }
            return sb.ToString().TrimEnd(',');
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            DbNode<T> n = this.head;
            sb.Append(n.Data.ToString() + ",");
            while (n.Next != null)
            {
                sb.Append(n.Next.Data.ToString() + ",");
                n = n.Next;
            }
            return sb.ToString().TrimEnd(',');
        }


        static void Test(string[] args)
        {
            #region 双链表
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("双链表测试开始...");
            DbLinkList<string> dblink = new DbLinkList<string>();
            dblink.Head = new DbNode<string>("x");
            dblink.InsertBefore("w", 0);
            dblink.InsertBefore("v", 0);
            dblink.Append("y");
            dblink.InsertBefore("z", dblink.Count());
            Console.WriteLine(dblink.Count());//5
            Console.WriteLine(dblink.ToString());//v,w,x,y,z
            Console.WriteLine(dblink[1]);//w
            Console.WriteLine(dblink[0]);//v
            Console.WriteLine(dblink[4]);//z
            Console.WriteLine(dblink.IndexOf("z"));//4
            Console.WriteLine(dblink.RemoveAt(2));//x
            Console.WriteLine(dblink.ToString());//v,w,y,z
            dblink.InsertBefore("x", 2);
            Console.WriteLine(dblink.ToString());//v,w,x,y,z
            Console.WriteLine(dblink.GetItemAt(2));//x
            dblink.Reverse();
            Console.WriteLine(dblink.ToString());//z,y,x,w,v
            dblink.InsertAfter("1", 0);
            dblink.InsertAfter("2", 1);
            dblink.InsertAfter("6", 5);
            dblink.InsertAfter("8", 7);
            dblink.InsertAfter("A", 10);//Position is error!
            Console.WriteLine(dblink.ToString()); //z,1,2,y,x,w,6,v,8  

            string _tail = dblink.GetItemAt(dblink.Count() - 1);
            Console.WriteLine(_tail);

            Console.WriteLine(dblink.TestPrevErgodic());//8
            Console.ReadKey(); //8,v,6,w,x,y,2,1,z
            #endregion


        }
    }
}
