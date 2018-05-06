/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：SearchExtention
* 创 建 者：Qing
* 创建时间：2018-05-06 13:49:47
* CLR 版本：4.0.30319.42000
* 保存的文件名：SearchExtention
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

/** 数据结构与算法C#版查找 
 *    https://www.imooc.com/article/26567
 */
namespace CSharpAlgorithm
{
    public static class SearchExtention
    {
        #region 一、静态查找 -- 因为静态查找中不需要删除或新增记录，所以用顺序表比较适合。

        #region 顺序查找(Sequnce Search)
        /// <summary>
        /// 顺序查找
        ///     因为查找表为线性结构，所以也被称为线性查找(Linear Search)。
        /// 实现思路：从顺序表的一端向另一端逐个扫描，找到要的记录就返回其位置，找不到则返回失败信息(通常为-1)。
        /// </summary>
        /// <param name="arr">要查找的顺序表(比如数组)</param>
        /// <param name="key">要查找的值</param>
        /// <returns>找到返回元素的下标+1，否则返回-1</returns>
        public static int SeqSearch(int[] arr, int key)
        {
            int i = -1;
            if (arr.Length <= 1) { return i; }
            arr[0] = key;//第一个元素约定用来存放要查找的值，这个位置也称为“监视哨”，当然这并不是必须的，只是为了遵守原书的约定而已(以下同)
            bool flag = false;
            for (i = 1; i < arr.Length; i++)
            {
                if (arr[i] == key)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag) { i = -1; }
            return i;
        }
        #endregion

        #region 二分查找(Binary Search)
        /// <summary>
        /// 二分查找(适用于有序表)
        ///     这种全表扫描的方法，虽然很容易理解，但是效率是很低的，特别是表中记录数很多时。如果查找表的记录本身是有序的，则可以用下面的办法改进效率
        /// 实现思路：因为查找表本身是有序的(比如从小到大排列)，所以不必傻傻的遍历每个元素，可以取中间的元素与要查找的值比较，比如查找值大于中间元素，则要查找的元素肯定在后半段；反之如果查找值小于中间元素，则要查找的元素在前半段；然后继续二分，如此反复处理，直到找到要找的元素。
        /// </summary>
        /// <param name="arr">要查找的有序表</param>
        /// <param name="key">要查找的值</param>
        /// <returns>找到则返回元素的下标+1，否则返回-1</returns>
        public static int BinarySearch(int[] arr, int key)
        {
            arr[0] = key;//同样约定第一个位置存放要查找的元素值(仅仅只是约定而已)
            int flag = -1;
            int low = 1;
            int high = arr.Length - 1;

            while (low <= high)
            {
                //取中点
                var mid = (low + high) / 2;

                //查找成功，记录位置存放到flag中
                if (key == arr[mid])
                {
                    flag = mid;
                    break;
                }
                else if (key < arr[mid]) //调整到左半区
                {
                    high = mid - 1;
                }
                //调整到右半区
                else
                {
                    low = mid + 1;
                }
            }
            if (flag > 0)
            {
                return flag;//找到了
            }
            else
            {
                return -1;//没找到
            }
        }

        #endregion

        #region 索引查找(Index Search)
        /**
         *  思路：可以在查找表中选取一些关键记录，创建一个小型的有序表（该表中的每个元素除了记录自身值外，还记录了对应主查找表中的位置），即索引表。查找时，先到索引表中通过索引记录大致判断要查找的记录在主表的哪个区域，然后定位到主表的相应区域中，仅搜索这一个区块即可。
         */
        // C# 自带 indexOf 索引查找
        

        #endregion

        #region 折半搜索，也称二分查找算法、二分搜索，是一种在有序数组中查找某一特定元素的搜索算法。
        /**********************************************************************************************
         *  A 搜素过程从数组的中间元素开始，如果中间元素正好是要查找的元素，则搜素过程结束；
         *  B 如果某一特定元素大于或者小于中间元素，则在数组大于或小于中间元素的那一半中查找，而且跟开始一样从中间元素开始比较。
         *  C 如果在某一步骤数组为空，则代表找不到。这种搜索算法每一次比较都使搜索范围缩小一半。
         *  时间复杂度折半搜索每次把搜索区域减少一半，时间复杂度为O(log n)。
         *  （n代表集合中元素的个数）空间复杂度O(1 )
         */

        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low">开始索引 0</param>
        /// <param name="high">结束索引 </param>
        /// <param name="key">要查找的对象</param>
        /// <returns></returns>
        public static int BinarySearch(int[] arr, int low, int high, int key)
        {
            int mid = (low + high) / 2;
            if (low > high)
                return -1;
            if (arr[mid] == key)
                return mid;
            if (arr[mid] > key)
                return BinarySearch(arr, low, mid - 1, key);
            return BinarySearch(arr, mid + 1, high, key);
        }
        #endregion

        #endregion

        #region 二、动态查找 -- 动态查找中因为会经常要插入或删除元素，如果用数组来顺序存储，会导致大量的元素频繁移动，所以出于性能考虑，这次我们采用链式存储，并介绍一种新的树：二叉排序树(Binary Sort Tree)

        #region 二叉排序树的查找
        /// <summary>
        /// 二叉排序树查找
        /// 实现思路：
        /// 从根节点开始遍历，如果正好该根节点就是要找的值，则返回true，如果要查找的值比根节点大，则调整到右子树查找，反之调整到左子树。
        /// </summary>
        /// <param name="bTree"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool BiSortTreeSearch(BiTree<int> bTree, int key)
        {
            Node<int> p;

            //如果树为空，则直接返回-1
            if (bTree.IsEmpty())
            {
                return false;
            }

            p = bTree.Root;

            while (p != null)
            {
                //如果根节点就是要找的
                if (p.Data == key)
                {
                    return true;
                }
                else if (key > p.Data)
                {
                    //调整到右子树
                    p = p.RChild;
                }
                else
                {
                    //调整到左子树
                    p = p.LChild;
                }
            }
            return false;
        }

        #endregion

        #region 二叉排序树的插入
        /// <summary>
        /// 二插排序树的插入(即：先查找，如果找不到，则插入要查找的值)
        /// 逻辑：先在树中查找指定的值，如果找到，则不插入，如果找不到，则把要查找的值插入到最后一个节点下做为子节点（即：先查找，再插入）
        /// </summary>
        /// <param name="bTree"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool BiSortTreeInsert(BiTree<int> bTree, int key)
        {
            Node<int> p = bTree.Root;
            Node<int> last = null;//用来保存查找过程中的最后一个节点            

            while (p != null)
            {
                if (p.Data == key)
                {
                    return true;
                }
                last = p;

                if (key > p.Data)
                {
                    p = p.RChild;
                }
                else
                {
                    p = p.LChild;
                }
            }

            //如果找了一圈，都找不到要找的节点，则将目标节点插入到最后一个节点下面
            p = new Node<int>(key);
            if (last == null)
            {
                bTree.Root = p;
            }
            else if (p.Data < last.Data)
            {
                last.LChild = p;
            }
            else
            {
                last.RChild = p;
            }

            return false;
        }
        #endregion

        #region 二叉排序树的创建
        /// <summary>
        /// 创建一颗二插排序树
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="arr"></param>
        public static void CreateBiSortTree(BiTree<int> tree, int[] arr)
        {
            foreach (var t in arr)
            {
                BiSortTreeInsert(tree, t);
            }
        }
        #endregion

        #region 二叉排序树的节点删除
        /// <summary>
        /// 删除二叉排序树的节点
        /// 这也是动态查询的一种情况，找到需要的节点后，如果存在，则删除该节点。
        /// 可以分为几下四种情况：
        ///     a.待删除的节点，本身就是叶节点：这种情况下最简单，只要把这个节点删除掉，然后父节点的LChild或RChild设置为null即可
        ///     b.待删除的节点，只有左子树：将本节点的左子树上移，挂到父节点下的LChild，然后删除自身即可
        ///     c.待删除的节点,只有右子树：将自身节点的右子树挂到父节点的左子树,然后删除自身即可
        ///     d.待删除的节点,左、右子树都有：这个要复杂一些，先找出自身节点右子树中的左分支的最后一个节点（最小左节点），然后将它跟自身对调，同时将“最小左节点”下的分支上移。
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool DeleteBiSort(BiTree<int> tree, int key)
        {
            //二叉排序树为空
            if (tree.IsEmpty())
            {
                return false;
            }

            Node<int> p = tree.Root;
            Node<int> parent = p;

            while (p != null)
            {
                if (p.Data == key)
                {
                    if (tree.IsLeaf(p))//如果待删除的节点为叶节点
                    {
                        #region
                        if (p == tree.Root)
                        {

                            tree.Root = null;
                        }
                        else if (p == parent.LChild)
                        {

                            parent.LChild = null;
                        }
                        else
                        {

                            parent.RChild = null;
                        }
                        #endregion
                    }
                    else if ((p.RChild == null) && (p.LChild != null)) //仅有左分支 
                    {
                        #region
                        if (p == parent.LChild)
                        {

                            parent.LChild = p.LChild;
                        }
                        else
                        {
                            parent.RChild = p.LChild;
                        }
                        #endregion
                    }
                    else if ((p.LChild == null) && (p.RChild != null)) //仅有右分支
                    {
                        #region
                        if (p == parent.LChild)
                        {
                            parent.LChild = p.RChild;
                        }
                        else
                        {
                            parent.RChild = p.RChild;
                        }
                        #endregion
                    }
                    else //左，右分支都有
                    {
                        //原理：先找到本节点右子树中的最小节点(即右子树的最后一个左子节点)
                        #region
                        Node<int> q = p;
                        Node<int> s = p.RChild;
                        while (s.LChild != null)
                        {
                            q = s;
                            s = s.LChild;
                        }
                        Console.WriteLine("s.Data=" + s.Data + ",p.Data=" + p.Data + ",q.Data=" + q.Data);

                        //然后将找到的最小节点与自己对调(因为最小节点是从右子树中找到的，所以其值肯定比本身要大)
                        p.Data = s.Data;


                        if (q != p)
                        {
                            //将q节点原来的右子树挂左边(这样最后一个节点的子树就调整到位了)
                            q.LChild = s.RChild;
                        }
                        else //s节点的父节点就是p时,将s节点原来的右树向上提(因为s已经换成p点的位置了，所以这个位置就不需要了，直接把它的右树向上提升即可)
                        {
                            q.RChild = s.RChild;
                        }
                        #endregion
                    }
                    return true;
                }
                else if (key > p.Data)
                {
                    parent = p;
                    p = p.RChild;
                }
                else
                {
                    parent = p;
                    p = p.LChild;
                }
            }
            return false;
        }
        #endregion

        #endregion
      
        #region KMP算法
        /// <summary>
        /// 失效函数：
        /// 
        /// 如果子串中标号为j的字符同主串失配，那么将子串回溯到next[j]继续与主串匹配，如果next[j]=-1,则主串的匹配点后移一位，同子串的第一个元素开始匹配。
        /// 同一般的模式匹配算法相比，kmp通过失效函数在失配的情况下跳过了若干轮匹配(向右滑动距离可能大于1)
        /// kmp算法保证跳过去的这些轮匹配一定是失配的，这一点可以证明
        /// </summary>
        /// <param name="pattern">模式串，上面的注释里将其称为子串</param>
        /// <returns>失效函数是kmp算法的核心，本函数依照其定义求出回溯函数，KMP函数依照其意义使用回溯函数。</returns>
        public static int[] Next(string pattern)//返回类型：整形数组。
        {
            int[] next = new int[pattern.Length];//定义一个整形数组，长度为字符串长度。
            next[0] = -1;
            if (pattern.Length < 2) //如果只有1个元素不用kmp效率会好一些
            {
                return next;
            }

            next[1] = 0;    //第二个元素的回溯函数值必然是0，可以证明：
            //1的前置序列集为{空集,L[0]}，L[0]的长度不小于1，所以淘汰，空集的长度为0，故回溯函数值为0
            int i = 2;  //正被计算next值的字符的索引
            int j = 0;  //计算next值所需要的中间变量，每一轮迭代初始时j总为next[i-1]
            while (i < pattern.Length)    //很明显当i==pattern.Length时所有字符的next值都已计算完毕，任务已经完成
            { //状态点
                if (pattern[i - 1] == pattern[j])   //首先必须记住在本函数实现中，迭代计算next值是从第三个元素开始的
                {   //如果L[i-1]等于L[j]，那么next[i] = j + 1
                    next[i++] = ++j;
                }
                else
                {   //如果不相等则检查next[i]的下一个可能值----next[j]
                    j = next[j];
                    if (j == -1)    //如果j == -1则表示next[i]的值是1
                    {   //可以把这一部分提取出来与外层判断合并
                        //书上的kmp代码很难理解的一个原因就是已经被优化，从而遮蔽了其实际逻辑
                        next[i++] = ++j;
                    }
                }
            }
            return next;
        }

        /// <summary>
        /// KMP函数同普通的模式匹配函数的差别在于使用了next函数来使模式串一次向右滑动多位称为可能
        /// next函数的本质是提取重复的计算
        /// </summary>
        /// <param name="source">主串</param>
        /// <param name="pattern">用于查找主串中一个位置的模式串</param>
        /// <returns>-1表示没有匹配，否则返回匹配的标号</returns>
        public static int StringIndex_KMP(string source, string pattern)//kmp模式匹配
        {
            int[] next = Next(pattern);
            int i = 0;  //主串指针
            int j = 0;  //模式串指针
            //如果子串没有匹配完毕并且主串没有搜索完成
            while (j < pattern.Length && i < source.Length)
            {
                if (source[i] == pattern[j])    //i和j的逻辑意义体现于此，用于指示本轮迭代中要判断是否相等的主串字符和模式串字符
                {
                    i++;
                    j++;
                }
                else
                {
                    j = next[j];    //依照指示迭代回溯
                    if (j == -1)    //回溯有情况，这是第二种
                    {
                        i++;
                        j++;
                    }
                }
            }
            //如果j==pattern.Length则表示循环的退出是由于子串已经匹配完毕而不是主串用尽
            return j < pattern.Length ? -1 : i - j;

        }

        /// <summary>
        /// 蛮力模式匹配 -- 只是为了和KMP算法对比，实际是不会拿来使用的。
        /// </summary>
        /// <param name="T">主串</param>
        /// <param name="P">用于查找主串中一个位置的模式串</param>
        /// <returns></returns>
        public static int StringIndex_ML(string T, string P)//蛮力模式匹配
        {
            int i;
            var n = T.Length;
            var m = P.Length;
            for (i = 0; i <= (n - m); i++)//n-m是避免 当比较时，母串剩下未比较的字符个数小于子串的个数，避免了没必要的比较。
            {
                var j = 0;
                while (j < m)//控制P的遍历下标
                {
                    if (T[i + j] == P[j])//如果有相等的元素，则使其指向下一个元素进行比较
                    {
                        j = j + 1;//用j来记录相等的次数
                    }
                    else//如果当前两个元素不相等，则跳出循环，使T指向下一个比较元素
                    {
                        break;
                    }
                }
                if (j == m)//如果上面的if语句遍历完p数组，说明J=M，即找到了子字符串。反回其位置。
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}
