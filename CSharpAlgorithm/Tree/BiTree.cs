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



        static void Test(string[] args)
        {
            #region 二叉树
            BiTree<string> tree = new BiTree<string>("A");
            Node<string> root = tree.Root;
            tree.InsertL("B", root);
            tree.InsertR("C", root);

            Node<string> b = root.LChild;
            Node<string> c = root.RChild;

            tree.InsertL("D", b);
            tree.InsertR("E", b);

            tree.InsertL("F", c);
            tree.InsertR("G", c);

            Node<string> d = b.LChild;
            Node<string> e = b.RChild;

            tree.InsertL("H", d);
            tree.InsertR("I", d);
            tree.InsertL("J", e);

            Console.WriteLine("前序遍历开始>>>\n");
            //前序遍历
            PreOrder(root);

            Console.WriteLine("\n------------------------\n");


            Console.WriteLine("中序遍历开始>>>\n");
            //中序遍历
            InOrder(root);

            Console.WriteLine("\n------------------------\n");
            Console.WriteLine("后序遍历开始>>>\n");
            //后序遍历
            PostOrder(root);


            Console.WriteLine("\n------------------------\n");
            Console.WriteLine("层序遍历开始>>>\n");
            //后序遍历
            LevelOrder(root);

            Console.Read();

            #endregion
        }


        #region 二叉树的前序、中序、后序遍历
        /// <summary>
        /// 前序遍历(即 root-->left-->right )
        /// </summary>
        /// <param name="root"></param>
        static void PreOrder(Node<string> root)
        {
            if (root != null)
            {
                //先处理root
                Console.Write("{0} ", root.Data);

                //再处理root的左子节点
                PreOrder(root.LChild);

                //再处理root的右子节点
                PreOrder(root.RChild);
            }


        }

        /// <summary>
        /// 中序遍历(left-->root-->right)
        /// </summary>
        /// <param name="root"></param>
        static void InOrder(Node<string> root)
        {
            if (root == null)
            {
                return;
            }

            //先左子节点
            InOrder(root.LChild);

            //再根节点
            Console.Write("{0} ", root.Data);

            //再右子节点
            InOrder(root.RChild);
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="root"></param>
        static void PostOrder(Node<string> root)
        {
            if (root == null)
            {
                return;
            }

            PostOrder(root.LChild);
            PostOrder(root.RChild);
            Console.Write("{0} ", root.Data);
        }

        /// <summary>
        /// 层顺遍历
        /// </summary>
        /// <param name="root"></param>
        static void LevelOrder(Node<string> root)
        {
            if (root != null)
            {
                Queue<Node<string>> q = new Queue<Node<string>>();

                q.Enqueue(root);

                while (q.Count > 0)
                {
                    Node<string> tmp = q.Dequeue();

                    //先处理根节点
                    Console.Write("{0} ", tmp.Data);

                    if (tmp.LChild != null)
                    {
                        //左子节点入队
                        q.Enqueue(tmp.LChild);
                    }

                    if (tmp.RChild != null)
                    {
                        //右子节点入队
                        q.Enqueue(tmp.RChild);
                    }
                }
            }
        }
        #endregion

    }
}
