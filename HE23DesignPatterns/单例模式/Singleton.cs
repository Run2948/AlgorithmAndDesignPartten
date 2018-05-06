//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Singleton
// created by 朱锦润
// created time 2017/07/02 16:58:35
//--------------------------------------------
using System;

namespace DesignMethod.单例模式
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public class Singleton
    {
        //#region 单线程
        ////保存类的实例
        //private static Singleton uniqueInstance;
        ////禁止实例化
        //private Singleton() { }
        ///// <summary>
        ///// 提供全局访问点
        ///// </summary>
        ///// <returns></returns>
        //public static Singleton GetInstance()
        //{
        //    //不存在就创建，存在就返回
        //    if (uniqueInstance == null)
        //        uniqueInstance = new Singleton();
        //    return uniqueInstance;
        //}
        //#endregion

        #region 多线程 双重加锁

        //定义一个标示确保线程同步
        private static readonly object locker = new object();

        //定义静态实例
        private static Singleton uniqueInstance;

        //禁止实例
        private Singleton() { }

        //定义全局访问点
        public static Singleton GetInstance()
        {
            //第一个线程运行，此时会对locker对象“加锁”
            //第二个线程运行，首先检测locker对象为“加锁”状态，该线程就会挂起等待第一个线程解锁
            //lock语句运行完后，会对该对象“解锁”
            //双重锁定只需要一句话判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton();
                    }
                }
            }
            return uniqueInstance;
        }

        #endregion 多线程 双重加锁

        public void Co()
        {
            Console.Write("单例模式启动");
            Console.Read();
        }
    }
}