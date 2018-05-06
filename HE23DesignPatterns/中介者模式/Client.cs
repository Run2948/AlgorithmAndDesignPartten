//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Client
// created by 朱锦润
// created time 2017/07/07 13:17:45
//--------------------------------------------
using System;
using System.Collections.Generic;

namespace DesignMethod.中介者模式
{
    #region 未使用观察者模式和状态模式

    ////抽象类
    //public abstract class AbstractCardPartner
    //{
    //    public int MoneyCount { get; set; }
    //    public AbstractCardPartner()
    //    {
    //        MoneyCount = 0;
    //    }
    //    public abstract void ChangeCount(int Count, AbstractMediator other);
    //}

    ////A
    //public class ParterA : AbstractCardPartner
    //{
    //    public override void ChangeCount(int Count, AbstractMediator other)
    //    {
    //        other.AWin(Count);
    //    }
    //}

    ////B
    //public class ParterB : AbstractCardPartner
    //{
    //    public override void ChangeCount(int Count, AbstractMediator other)
    //    {
    //        other.BWin(Count);
    //    }
    //}

    ////抽象中介者
    //public abstract class AbstractMediator
    //{
    //    protected AbstractCardPartner A;
    //    protected AbstractCardPartner B;
    //    public AbstractMediator(AbstractCardPartner a, AbstractCardPartner b)
    //    {
    //        A = a;
    //        B = b;
    //    }

    //    public abstract void AWin(int count);
    //    public abstract void BWin(int count);
    //}

    //public class Mediator : AbstractMediator
    //{
    //    public Mediator(AbstractCardPartner a, AbstractCardPartner b) : base(a, b) { }
    //    public override void AWin(int count)
    //    {
    //        A.MoneyCount += count;
    //        B.MoneyCount -= count;
    //    }

    //    public override void BWin(int count)
    //    {
    //        B.MoneyCount += count;
    //        A.MoneyCount -= count;
    //    }
    //}

    #endregion 未使用观察者模式和状态模式

    #region 使用观察者模式和状态模式完善中介者模式

    //抽象牌友类
    public abstract class AbstractCardPartner
    {
        public AbstractCardPartner()
        {
            MoneyCount = 0;
        }

        public int MoneyCount { get; set; }

        public abstract void ChangeCount(int Count, AbstractMediator mediator);
    }

    //抽象中介者
    public abstract class AbstractMediator
    {
        public List<AbstractCardPartner> list = new List<AbstractCardPartner>();

        public AbstractMediator(State state)
        {
            this.State = state;
        }

        public State State { get; set; }

        public void ChangeCount(int Count)
        {
            State.ChangeCount(Count);
        }

        public void Enter(AbstractCardPartner partner)
        {
            list.Add(partner);
        }

        public void Exit(AbstractCardPartner partner)
        {
            list.Remove(partner);
        }
    }

    //A赢状态
    public class AWinState : State
    {
        public AWinState(AbstractMediator concretemediator)
        {
            this.mediator = concretemediator;
        }

        public override void ChangeCount(int Count)
        {
            foreach (AbstractCardPartner p in mediator.list)
            {
                ParterA a = p as ParterA;
                if (a != null)
                {
                    a.MoneyCount += Count;
                }
                else
                {
                    p.MoneyCount -= Count;
                }
            }
        }
    }

    //B赢状态
    public class BWinState : State
    {
        public BWinState(AbstractMediator concretemediator)
        {
            this.mediator = concretemediator;
        }

        public override void ChangeCount(int Count)
        {
            foreach (AbstractCardPartner p in mediator.list)
            {
                ParterB b = p as ParterB;
                if (b != null)
                {
                    b.MoneyCount += Count;
                }
                else
                {
                    p.MoneyCount -= Count;
                }
            }
        }
    }

    public class InitState : State
    {
        public InitState()
        {
            Console.WriteLine("游戏才刚刚开始，暂时还没有玩家胜出");
        }

        public override void ChangeCount(int Count)
        {
            return;
        }
    }

    //具体中介者
    public class MediatorPater : AbstractMediator
    {
        public MediatorPater(State initState)
            : base(initState)
        {
        }
    }

    //牌友A类
    public class ParterA : AbstractCardPartner
    {
        //依赖与抽象中介者对象
        public override void ChangeCount(int Count, AbstractMediator mediator)
        {
            mediator.ChangeCount(Count);
        }
    }

    //牌友B类
    public class ParterB : AbstractCardPartner
    {
        public override void ChangeCount(int Count, AbstractMediator mediator)
        {
            mediator.ChangeCount(Count);
        }
    }

    //抽象状态类
    public abstract class State
    {
        protected AbstractMediator mediator;

        public abstract void ChangeCount(int Count);
    }

    #endregion 使用观察者模式和状态模式完善中介者模式
}