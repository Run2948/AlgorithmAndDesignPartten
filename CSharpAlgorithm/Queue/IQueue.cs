/* ==============================================================================
* 命名空间：CSharpAlgorithm
* 类 名 称：IQuene
* 创 建 者：Qing
* 创建时间：2018-05-06 14:58:17
* CLR 版本：4.0.30319.42000
* 保存的文件名：IQuene
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
     * 数据结构C#版笔记--队列(Quene) - 菩提树下的杨过 - 博客园 http://www.cnblogs.com/yjmyzz/archive/2010/11/04/1865733.html
     */
    public interface IQueue<T>
    {
        /// <summary>
        /// 取得队列实际元素的个数
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// 判断队列是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 清空队列
        /// </summary>
        void Clear();

        /// <summary>
        /// 入队（即向队列尾部添加一个元素）
        /// </summary>
        /// <param name="item"></param>
        void Enqueue(T item);

        /// <summary>
        /// 出队(即从队列头部删除一个元素)
        /// </summary>
        /// <returns></returns>
        T Dequeue();

        /// <summary>
        /// 取得队列头部第一元素
        /// </summary>
        /// <returns></returns>
        T Peek();
    }
}
