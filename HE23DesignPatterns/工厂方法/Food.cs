//--------------------------------------------
// Copyright (C) 武汉一世计科软件有限公司
// filename :Food
// created by 朱锦润
// created time 2017/07/02 17:58:57
//--------------------------------------------
using System;

namespace DesignMethod.工厂方法
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class Creator
    {
        //定义工厂类
        public abstract Food CreateFoodFactory();
    }

    /// <summary>
    /// 食物抽象类
    /// </summary>
    public abstract class Food
    {
        /// <summary>
        /// 输出
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 土豆
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("土豆");
        }
    }

    /// <summary>
    /// 土豆工厂类
    /// </summary>
    public class ShreddedPorkWithPotatoesFactory : Creator
    {
        /// <summary>
        /// 创建土豆
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoodFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }

    /// <summary>
    /// 西红柿
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("西红柿");
        }
    }

    /// <summary>
    /// 西红柿工厂类
    /// </summary>
    public class TomatoScrambledEggsFactory : Creator
    {
        /// <summary>
        /// 创建西红柿
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoodFactory()
        {
            return new TomatoScrambledEggs();
        }
    }
}