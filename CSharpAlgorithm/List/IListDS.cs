/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：IListDS
* 创 建 者：Qing
* 创建时间：2018-05-06 14:39:55
* CLR 版本：4.0.30319.42000
* 保存的文件名：IListDS
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
 * 数据结构C#版笔记--顺序表(SeqList) - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/10/17/1853376.html
 */
namespace CSharpAlgorithm
{
    /// <summary>
    /// 定义线性表的通用接口IListDS(注：DS为DataStructure的缩写)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IListDS<T>
    {
        //取得线性表的实际元素个数
        int Count();

        //清空线性表
        void Clear();

        //判断线性表是否为空
        bool IsEmpty();

        //（在末端）追加元素
        void Append(T item);

        //在位置i“前面”插入元素item
        void InsertBefore(T item, int i);

        //在位置i“后面”插入元素item
        void InsertAfter(T item, int i);

        //删除索引i处的元素
        T RemoveAt(int i);

        //获得索引位置i处的元素
        T GetItemAt(int i);

        //返回元素value的索引
        int IndexOf(T value);

        //反转线性表的所有元素
        void Reverse();
    }
}
