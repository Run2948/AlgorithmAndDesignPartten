//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/08 9:55:07
//--------------------------------------------
using System;
using System.Collections.Generic;

namespace DesignMethod.观察者模式
{
    //委托--------------------------------------------------------------------------------------------------------------------------------------------------
    public delegate void NotifyEventHandler(object sender);

    //订阅者接口
    public interface IObserver
    {
        void ReceiveAndPrint(TenXun tenxun);
    }

    //具体订阅类
    public class Subscriber : IObserver
    {
        public Subscriber(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void ReceiveAndPrint(TenXun tenxun)
        {
            Console.WriteLine("Notified {0} of {1} 's" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
        }
    }

    //委托
    public class SubscriberWt
    {
        public SubscriberWt(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void ReceiveAndPrint(Object ob)
        {
            TenXunWt tenxun = ob as TenXunWt;
            if (tenxun != null)
                Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
        }
    }

    //订阅号抽象类
    public abstract class TenXun
    {
        //保留订阅号列表
        private List<IObserver> observers = new List<IObserver>();

        public TenXun(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public string Info { get; set; }
        public string Symbol { get; set; }

        #region 新增对订阅号列表的维护操作

        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }

        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }

        #endregion 新增对订阅号列表的维护操作

        public void Update()
        {
            //遍历订阅者列表进行通知
            foreach (IObserver ob in observers)
            {
                if (ob != null)
                    ob.ReceiveAndPrint(this);
            }
        }
    }

    //具体订阅号
    public class TenXunGame : TenXun
    {
        public TenXunGame(string symbol, string info)
            : base(symbol, info)
        { }
    }

    //委托
    public class TenXunGameWt : TenXunWt
    {
        public TenXunGameWt(string symbol, string info)
            : base(symbol, info) { }
    }

    //委托
    public class TenXunWt
    {
        //保留订阅号列表
        public NotifyEventHandler NotifyEvent;

        public TenXunWt(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        public string Info { get; set; }
        public string Symbol { get; set; }

        #region 新增对订阅号列表的维护操作

        public void AddObserver(NotifyEventHandler ob)
        {
            NotifyEvent += ob;
        }

        public void RemoveObserver(NotifyEventHandler ob)
        {
            NotifyEvent -= ob;
        }

        #endregion 新增对订阅号列表的维护操作

        public void Update()
        {
            if (NotifyEvent != null)
                NotifyEvent(this);
        }
    }
}