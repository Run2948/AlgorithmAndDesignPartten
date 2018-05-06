/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：BiTree
* 创 建 者：Qing
* 创建时间：2018-05-06 14:26:42
* CLR 版本：4.0.30319.42000
* 保存的文件名：BiTree
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
    public class BiTree<T>
    {
        private Node<T> root;

        /// <summary>
        /// 根节点(属性)
        /// </summary>
        public Node<T> Root
        {
            get { return root; }
            set { root = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BiTree()
        {
            root = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        public BiTree(T data)
        {
            Node<T> p = new Node<T>(data);
            root = p;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ln"></param>
        /// <param name="rn"></param>
        public BiTree(T data, Node<T> ln, Node<T> rn)
        {
            Node<T> p = new Node<T>(data, ln, rn);
            root = p;
        }

        /// <summary>
        /// 判断树是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (root == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取节点p的左子节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> GetLChild(Node<T> p)
        {
            return p.LChild;
        }

        /// <summary>
        /// 获取节点p的右子节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> GetRChild(Node<T> p)
        {
            return p.RChild;
        }

        /// <summary>
        /// 节点p下插入左子节点data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="p"></param>
        public void InsertL(T data, Node<T> p)
        {
            Node<T> tmp = new Node<T>(data);
            tmp.LChild = p.LChild;
            p.LChild = tmp;
        }

        /// <summary>
        /// 节点p下插入右子节点data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="p"></param>
        public void InsertR(T data, Node<T> p)
        {
            Node<T> tmp = new Node<T>(data);
            tmp.RChild = p.RChild;
            p.RChild = tmp;
        }

        /// <summary>
        /// 删除节点p的左子节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> DeleteL(Node<T> p)
        {
            if ((p == null) || (p.LChild == null))
            {
                return null;
            }

            Node<T> tmp = p.LChild;
            p.LChild = null;
            return tmp;
        }

        /// <summary>
        /// 删除节点p的右子节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Node<T> DeleteR(Node<T> p)
        {
            if ((p == null) || (p.RChild == null))
            {
                return null;
            }

            Node<T> tmp = p.RChild;
            p.RChild = null;

            return tmp;
        }

        /// <summary>
        /// 判断节点p是否为叶节点
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsLeaf(Node<T> p)
        {
            if ((p != null) && (p.LChild == null) && (p.RChild == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
