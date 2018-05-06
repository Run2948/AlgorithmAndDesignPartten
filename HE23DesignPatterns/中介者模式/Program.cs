//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/07 13:16:31
//--------------------------------------------
using System;

namespace DesignMethod.中介者模式
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            #region 未使用观察者模式与状态者模式

            //AbstractCardPartner A = new ParterA();
            //A.MoneyCount = 20;
            //AbstractCardPartner B = new ParterB();
            //B.MoneyCount = 20;
            //AbstractMediator mediator = new Mediator(A, B);
            //mediator.AWin(5);
            //Console.WriteLine("A:{0}", A.MoneyCount);
            //Console.WriteLine("B:{0}", B.MoneyCount);
            //mediator.BWin(5);
            //Console.WriteLine("B:{0}", B.MoneyCount);
            //Console.WriteLine("A:{0}", A.MoneyCount);
            //Console.Read();

            #endregion 未使用观察者模式与状态者模式

            #region 完善中介者模式

            AbstractCardPartner A = new ParterA();
            AbstractCardPartner B = new ParterB();
            // 初始钱
            A.MoneyCount = 20;
            B.MoneyCount = 20;
            AbstractMediator mediator = new MediatorPater(new InitState());
            // A,B玩家进入平台进行游戏
            mediator.Enter(A);
            mediator.Enter(B);
            // A赢了
            mediator.State = new AWinState(mediator);
            mediator.ChangeCount(5);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);
            // 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount);
            // 应该是15
            // B 赢了
            mediator.State = new BWinState(mediator);
            mediator.ChangeCount(10);
            Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);
            // 应该是25
            Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount);
            // 应该是15
            Console.Read();

            #endregion 完善中介者模式
        }
    }
}