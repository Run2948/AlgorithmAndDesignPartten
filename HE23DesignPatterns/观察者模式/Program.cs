//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/08 9:54:37
//--------------------------------------------
using System;

namespace DesignMethod.观察者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            #region 观察者模式

            //TenXun tenXun = new TenXunGame("TenXun Game", "Have a new game published ....");
            ////添加订阅者
            //tenXun.AddObserver(new Subscriber("Learning Hard"));
            //tenXun.AddObserver(new Subscriber("Tom"));
            //tenXun.Update();
            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine("移除Tom订阅者");
            //tenXun.RemoveObserver(new Subscriber("Tom"));
            //tenXun.Update();

            #endregion 观察者模式

            #region 观察者模式使用委托

            TenXunWt tenXun = new TenXunGameWt("TenXun Game", "Have a new game published ....");
            //添加订阅者
            SubscriberWt lh = new SubscriberWt("Learning Hard");
            SubscriberWt tom = new SubscriberWt("Tom");
            tenXun.AddObserver(new 观察者模式.NotifyEventHandler(lh.ReceiveAndPrint));
            tenXun.AddObserver(new 观察者模式.NotifyEventHandler(tom.ReceiveAndPrint));
            tenXun.Update();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("移除Tom订阅者");
            tenXun.RemoveObserver(new 观察者模式.NotifyEventHandler(tom.ReceiveAndPrint));
            tenXun.Update();

            #endregion 观察者模式使用委托

            Console.ReadLine();
        }
    }
}