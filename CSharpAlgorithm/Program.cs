using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignMethod;

namespace CSharpAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 排列
            // 求排列：5个数取3个的任意排列
            //int[] IntArr = new int[] { 1, 2, 3, 4, 5 }; //整型数组
            //List<int[]> ListCombination = PermutationAndCombination<int>.GetPermutation(IntArr, 3); //求全部的5取3排列
            //foreach (int[] arr in ListCombination)
            //{
            //    foreach (int item in arr)
            //    {
            //        Console.Write(item + " ");
            //    }
            //    Console.WriteLine("");
            //}
            #endregion

            #region 组合
            // 求组合：求5个数里任意3个数的组合
            //int[] IntArr = new int[] { 1, 2, 3, 4, 5 }; //整型数组
            //List<int[]> ListCombination = PermutationAndCombination<int>.GetCombination(IntArr, 3); //求全部的3-3组合
            //foreach (int[] arr in ListCombination)
            //{
            //    foreach (int item in arr)
            //    {
            //        Console.Write(item + " ");
            //    }
            //    Console.WriteLine("");
            //}
            //Console.ReadKey();
            #endregion

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

            #region 单链表
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("单链表测试开始...");
            LinkList<string> link = new LinkList<string>();
            link.Head = new LinkNode<string>("x");
            link.InsertBefore("w", 0);
            link.InsertBefore("v", 0);
            link.Append("y");
            link.InsertBefore("z", link.Count());
            Console.WriteLine(link.Count());//5
            Console.WriteLine(link.ToString());//v,w,x,y,z
            Console.WriteLine(link[1]);//w
            Console.WriteLine(link[0]);//v
            Console.WriteLine(link[4]);//z
            Console.WriteLine(link.IndexOf("z"));//4
            Console.WriteLine(link.RemoveAt(2));//x
            Console.WriteLine(link.ToString());//v,w,y,z
            link.InsertBefore("x", 2);
            Console.WriteLine(link.ToString());//v,w,x,y,z
            Console.WriteLine(link.GetItemAt(2));//x
            link.Reverse();
            Console.WriteLine(link.ToString());//z,y,x,w,v
            link.InsertAfter("1", 0);
            link.InsertAfter("2", 1);
            link.InsertAfter("6", 5);
            link.InsertAfter("8", 7);
            link.InsertAfter("A", 10);//Position is error!

            Console.WriteLine(link.ToString()); //z,1,2,y,x,w,6,v,8
            #endregion

            #region 队列
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

            #region 哈夫曼
            HuffmanTree huffTree = new HuffmanTree(2, 1, 4, 3);
            huffTree.Create();

            Console.WriteLine("最终树的节点值如下：");
            Console.WriteLine(huffTree.ToString()); 
            // 输出结果也许并不直观，对照下面这张图就明白了：
                // https://pic002.cnblogs.com/images/2010/27612/2010120513101331.png
            Console.ReadLine();
            #endregion

            #region 23种设计模式
            //执行23种设计模式中的一种
            StartDesign design = new StartDesign();
            design.Go();
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
