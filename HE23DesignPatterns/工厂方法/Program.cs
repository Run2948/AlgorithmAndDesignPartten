//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Program
// created by 朱锦润
// created time 2017/07/02 18:09:55
//--------------------------------------------
using System;

namespace DesignMethod.工厂方法
{
    public class Program : OpenDesign
    {
        public override void Open()
        {
            //初始化工厂类
            Creator shrFactory = new ShreddedPorkWithPotatoesFactory();
            Creator tomFactory = new TomatoScrambledEggsFactory();

            //开始西红柿
            Food tom = tomFactory.CreateFoodFactory();
            tom.Print();

            //开始土豆
            Food shr = shrFactory.CreateFoodFactory();
            shr.Print();

            Console.Read();
        }
    }
}