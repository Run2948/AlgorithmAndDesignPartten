/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：DbNode
* 创 建 者：Qing
* 创建时间：2018-05-06 15:15:15
* CLR 版本：4.0.30319.42000
* 保存的文件名：DbNode
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
 *  数据结构C#版笔记--双向链表(DbLinkList) - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/10/24/1859689.html
 */
namespace CSharpAlgorithm
{
    /// <summary>
    /// DbNode定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbNode<T>
    {
        private T data;
        private DbNode<T> prev;
        private DbNode<T> next;


        public DbNode(T data, DbNode<T> next, DbNode<T> prev)
        {
            this.data = data;
            this.next = next;
            this.prev = prev;
        }

        public DbNode(T data, DbNode<T> next)
        {
            this.data = data;
            this.next = next;
            this.prev = null;
        }

        public DbNode(DbNode<T> next)
        {
            this.data = default(T);
            this.next = next;
            this.prev = null;
        }

        public DbNode(T data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }

        public DbNode()
        {
            data = default(T);
            next = null;
            prev = null;
        }

        public T Data
        {
            set { this.data = value; }
            get { return this.data; }
        }

        public DbNode<T> Prev
        {
            get { return prev; }
            set { prev = value; }
        }

        public DbNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
