/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：IStack
* 创 建 者：Qing
* 创建时间：2018-05-06 15:04:26
* CLR 版本：4.0.30319.42000
* 保存的文件名：IStack
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
    /**
     * 数据结构C#版笔记--堆栈(Stack) - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/10/30/1865212.html
     */
    public interface IStack<T>
    {
        /// <summary>
        /// 返回堆栈的实际元素个数
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// 判断堆栈是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 清空堆栈里的元素
        /// </summary>
        void Clear();

        /// <summary>
        /// 入栈：将元素压入堆栈中
        /// </summary>
        /// <param name="item"></param>
        void Push(T item);

        /// <summary>
        /// 出栈：从堆栈顶取一个元素，并从堆栈中删除
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// 取堆栈顶部的元素(但不删除)
        /// </summary>
        /// <returns></returns>
        T Peek();
    }
}
